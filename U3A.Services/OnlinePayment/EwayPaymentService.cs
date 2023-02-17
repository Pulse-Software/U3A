using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using U3A.Database;

using Eway.Rapid;
using Eway.Rapid.Abstractions;
using Eway.Rapid.Abstractions.Request;
using Eway.Rapid.Abstractions.Response;
using Eway.Rapid.Abstractions.Models;
using Eway.Rapid.Abstractions.Interfaces;
using DevExpress.Logify;
using U3A.Model;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using U3A.BusinessRules;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace U3A.Services
{
    public class EwayConnectionSingleton
    {
        public RapidClient EwayClient { get; private set; }
        public EwayConnectionSingleton(IServiceScopeFactory serviceScopeFactory) {
            using (var scope = serviceScopeFactory.CreateScope()) {
                var dbf = scope.ServiceProvider.GetService<IDbContextFactory<U3ADbContext>>();
                using (var dbc = dbf.CreateDbContext()) {
                    var info = (TenantInfoEx)dbc.TenantInfo;
                    HttpClient httpClient = new HttpClient();
                    RapidOptions options = new RapidOptions {
                        ApiKey = info.EwayAPIKey,
                        Password = info.EwayPassword,
                        RapidEndPoint = info.UseEwayTestEnviroment ? RapidEndpoints.SANDBOX : RapidEndpoints.PRODUCTION
                    };
                    options.ConfigureHttpClient(httpClient);
                    EwayClient = new RapidClient(httpClient);
                }
            }
        }

    }
    public class EwayPaymentService
    {

        readonly RapidClient ewayClient;
        public EwayPaymentService(EwayConnectionSingleton EwayCnn) {
            ewayClient = EwayCnn.EwayClient;
        }

        public async Task<string?> CreatePayment(U3ADbContext dbc,
                            string? AdminEmail,
                            string BaseUri,
                            Person person,
                            string PayerEmail,
                            string InvoiceNumber,
                            string InvoiceDescription,
                            string InvoiceReference,
                            decimal TotalFee) {

            string? result = null;
            CreateResponsiveSharedRequest request = new CreateResponsiveSharedRequest();
            request.HeaderText = "U3Admin.org.au";
            request.VerifyCustomerEmail = true;
            request.Capture = true;
            request.AllowedCards = AllowedCards.Visa | AllowedCards.Mastercard;

            request.RedirectUrl = Path.Combine(BaseUri, "EwaySuccess");
            request.CancelUrl = Path.Combine(BaseUri, "EwayFail");
            request.TransactionType = TransactionTypes.Purchase;
            request.TrackingID = Guid.NewGuid().ToString();

            var Customer = new DirectTokenCustomer() {
                Reference = person.PersonIdentity,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = PayerEmail,
                Street1 = person.Address,
                City = person.City,
                State = person.State,
                Country = "au",
                PostalCode = person.Postcode.ToString(),
                Phone = person.Mobile ?? person.HomePhone ?? string.Empty,
            };
            request.Customer = Customer;
            request.CustomerReadOnly = true;

            if (request.TransactionType == TransactionTypes.Purchase) {
                request.Payment = new Payment() {
                    TotalAmount = (int)(TotalFee * 100M),
                    InvoiceDescription = InvoiceDescription,
                    InvoiceNumber = InvoiceNumber,
                    InvoiceReference = InvoiceReference
                };
            }

            // Use the RapidClient to process the request.
            var response = await ewayClient.CreateTransaction(request);
            if (response.Errors == null) {
                var pay = new OnlinePaymentStatus() {
                    AdminEmail = AdminEmail,
                    AccessCode = response.AccessCode,
                    PersonID = person.ID,
                    Status = String.Empty
                };
                var previous = dbc.OnlinePaymentStatus.Where(x => x.PersonID == person.ID);
                dbc.RemoveRange(previous);
                await dbc.AddAsync(pay);
                await dbc.SaveChangesAsync();
                result = response.SharedPaymentUrl;
            }
            else {
                //TODO Figure out what to do with Eway errors.
            }
            return result;
        }


        bool IsProcessing = false;
        public async Task<PaymentResult?> ProcessPaymentResponse(U3ADbContext dbc, Person person) {
            if (IsProcessing) { return null; }
            IsProcessing = true;
            PaymentResult? result = null;
            var reqDetails = await BusinessRule.GetUnporcessedOnlinePayment(dbc, person);
            if (reqDetails != null) {
                var response = await ewayClient.QueryAccessCode(reqDetails.AccessCode);
                if (response.Errors == null) {
                    result = new PaymentResult() {
                        AccessCode = response.AccessCode,
                        AuthorisationCode = response.AuthorisationCode,
                        TransactionID = response.TransactionID.GetValueOrDefault(),
                        Amount = (decimal)(response.TotalAmount.GetValueOrDefault() / 100.00)
                    };
                }
            }
            IsProcessing = false;
            return result;
        }

        public async Task SetPaymentStatusProcessed(U3ADbContext dbc, Person person) {
            var details = await BusinessRule.GetUnporcessedOnlinePayment(dbc, person);
            if (details != null) {
                details.Status = "Processed";
                dbc.Update(details);
            }
        }
    }

    public record PaymentResult
    {
        public string AccessCode { get; set; }
        public string AuthorisationCode { get; set; }
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }

    }

}


