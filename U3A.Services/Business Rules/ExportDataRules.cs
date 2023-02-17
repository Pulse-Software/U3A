using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using U3A.Database;
using U3A.Model;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        public static async Task<List<ExportData>> GetExportDataAsync(U3ADbContext dbc) {
            var exportData = from s in dbc.SystemSettings
                             from p in dbc.Person
                             where p.DateCeased == null
                             select new ExportData {
                                 P_Key = p.ID,
                                 P_ID = p.PersonIdentity,
                                 P_ConversionID = p.ConversionID,
                                 P_FirstName = p.FirstName,
                                 P_LastName = p.LastName,
                                 P_Address = p.Address,
                                 P_City = p.City,
                                 P_State = p.State,
                                 P_Postcode = p.Postcode,
                                 P_Gender = p.Gender,
                                 P_BirthDate = (p.BirthDate == null) ? String.Empty : p.BirthDate.Value.ToString("D"),
                                 P_DateJoined = (p.DateJoined == null) ? string.Empty : p.DateJoined.Value.ToString("D"),
                                 P_Email = p.Email,
                                 P_HomePhone = p.HomePhone,
                                 P_Mobile = p.Mobile,
                                 P_SMSOptOut = p.SMSOptOut,
                                 P_ICEContact = p.ICEContact,
                                 P_ICEPhone = p.ICEPhone,
                                 P_VaxCertificateViewed = p.VaxCertificateViewed,
                                 P_Occupation = p.Occupation,
                                 P_Communication = p.Communication,
                                 P_IsLifeMember = p.IsLifeMember,
                                 P_FullName = $"{p.FirstName} {p.LastName}",

                                 // System Settings data

                                 S_U3AGroup = s.U3AGroup,
                                 S_OfficeLocation = s.OfficeLocation,
                                 S_PostalAddress = s.PostalAddress,
                                 S_StreetAddress = s.StreetAddress,
                                 S_ABN = s.ABN,
                                 S_Email = s.Email,
                                 S_Website = s.Website,
                                 S_Phone = s.Phone,
                                 S_MembershipFee = s.MembershipFee,
                                 S_MailSurcharge = s.MailSurcharge,
                                 S_fmtMembershipFee = s.MembershipFee.ToString("c2"),
                                 S_fmtMailSurcharge = s.MailSurcharge.ToString("c2")
                             };
            return await exportData.ToListAsync();
        }
        public static async Task<List<ExportData>> GetExportDataAsync(U3ADbContext dbc, IEnumerable<Person> ExportTo) {
            var result = (from exportData in await BusinessRule.GetExportDataAsync(dbc)
                         join exportTo in ExportTo
                         on exportData.P_Key equals exportTo.ID
                         select exportData).ToList();
            return result;
        }
    }
}