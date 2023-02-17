using DevExpress.XtraRichEdit.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Twilio.Types;

namespace U3A.BusinessRules
{
    public static partial class BusinessRule
    {
        /// <summary>
        ///  ref.: https://html.spec.whatwg.org/multipage/forms.html#valid-e-mail-address (HTML5 living standard, willful violation of RFC 3522)
        /// </summary>
        private static readonly string EmailValidation_Regex = @"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        private static readonly Regex EmailValidation_Regex_Compiled = new Regex(EmailValidation_Regex, RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks if the given e-mail is valid using various techniques
        /// </summary>
        /// <param name="email">The e-mail address to check / validate</param>
        /// <param name="useRegEx">TRUE to use the HTML5 living standard e-mail validation RegEx, FALSE to use the built-in validator provided by .NET (default: FALSE)</param>
        /// <param name="requireDotInDomainName">TRUE to only validate e-mail addresses containing a dot in the domain name segment, FALSE to allow "dot-less" domains (default: FALSE)</param>
        /// <returns>TRUE if the e-mail address is valid, FALSE otherwise.</returns>
        public static bool IsValidEmailAddress(string email, bool useRegEx = false, bool requireDotInDomainName = false) {
            var isValid = useRegEx
                // see RegEx comments
                ? email is not null && EmailValidation_Regex_Compiled.IsMatch(email)

                // ref.: https://stackoverflow.com/a/33931538/1233379
                : new EmailAddressAttribute().IsValid(email);

            if (isValid && requireDotInDomainName) {
                var arr = email.Split('@', StringSplitOptions.RemoveEmptyEntries);
                isValid = arr.Length == 2 && arr[1].Contains(".");
            }
            return isValid;
        }

        // 04 only
        public static bool IsValidAUMobileNumber(string mobileNumber) {
            string[] areaCodes = new string[] { "4" };
            return IsValidPhoneNumber(mobileNumber, areaCodes, true);
        }

        public static bool IsValidAUPhoneNumber(string phoneNumber) {
            string[] areaCodes = new string[] { "2", "3", "4", "7", "8" };
            return IsValidPhoneNumber(phoneNumber, areaCodes,false);
        }

        private static bool IsValidPhoneNumber(string phoneNumber, string[] areaCodes, bool IsMobileNumber) {
            var isValid = string.IsNullOrWhiteSpace(phoneNumber);
            if (!isValid) {
                long number;
                string strippedNumber = BusinessRule.strip(phoneNumber);
                if (strippedNumber.Length < 8) { return false; }
                if (!IsMobileNumber && strippedNumber.Length == 8) { return true; }
                if (phoneNumber.StartsWith("+")) strippedNumber = $"+{strippedNumber}";
                if (long.TryParse(strippedNumber, out number)) {
                    foreach (var areaCode in areaCodes) {
                        if (strippedNumber.StartsWith($"+610{areaCode}") && strippedNumber.Length == 13) { isValid = true; break; }
                        if (strippedNumber.StartsWith($"+61{areaCode}") && strippedNumber.Length == 12) { isValid = true; break; }
                        if (strippedNumber.StartsWith($"0{areaCode}") && strippedNumber.Length == 10) { isValid = true; break; }
                    }
                }
            }
            return isValid;
        }
    }
}