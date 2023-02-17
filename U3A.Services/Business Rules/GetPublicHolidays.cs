using Microsoft.EntityFrameworkCore;
using U3A.Database;
using U3A.Model;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Finbuckle.MultiTenant;

namespace U3A.BusinessRules
{

    public static partial class BusinessRule
    {

        internal static string EndPoint = @"https://data.gov.au/data/api/3/action/datastore_search?resource_id=33673aca-0857-42e5-b8f0-9981b4755686";
        internal class PublicHolidayRecord
        {
            public int _id { get; set; }
            public string Date { get; set; }
            [JsonPropertyName("Holiday Name")]
            public string HolidayName { get; set; }
            public string Information { get; set; }
            public string MoreInformation { get; set; }
            public string Jurisdiction { get; set; }
        }

        public static async Task<List<PublicHoliday>> RebuildPublicHolidaysAsync(U3ADbContext dbc) {
            string state = ((TenantInfoEx)dbc.TenantInfo).State.ToLower();
            DateTime endOfYear = new DateTime(DateTime.Today.Year - 1, 12, 31);
            DateTime thisDate;
            PublicHolidayRecord? thisRecord;

            // Step 1: Delete old dates from the list
            dbc.RemoveRange(await dbc.PublicHoliday.Where(x => x.Date <= endOfYear).ToListAsync());
            
            // Step 2: Retrieve the API lits
            HttpClient client = new HttpClient();
            string responseBody = await client.GetStringAsync($"{EndPoint}&q={state}&limit=9999");
            JsonNode? rootNode = JsonNode.Parse(responseBody);
            JsonNode resultNode = rootNode!["result"]!;
            JsonArray records = resultNode!["records"]!.AsArray();
            
            // Step 3: Build the new list
            foreach (var record in records) {
                thisRecord = (PublicHolidayRecord?) record.Deserialize(typeof(PublicHolidayRecord));
                thisDate = new DateTime(int.Parse(thisRecord.Date.Substring(0,4)),
                                        int.Parse(thisRecord.Date.Substring(4,2)),
                                        int.Parse(thisRecord.Date.Substring(6,2)));
                if (thisDate > endOfYear) {
                    bool onFile = dbc.PublicHoliday.Where(x => x.Date == thisDate).Any();
                    if (!onFile) {
                        dbc.PublicHoliday.Add(new PublicHoliday() { Date = thisDate, Name = thisRecord.HolidayName });
                    }
                }
            }
            await dbc.SaveChangesAsync();
            return await dbc.PublicHoliday.OrderBy(x => x.Date).ToListAsync();
        }
    }
}