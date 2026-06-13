using MD.PersianDateTime;
using MD.PersianDateTime.Standard;
//using PasswordHashing;

//using Spire.Xls;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Classicode.Utility
{
    public static class GlobalExtensions
    {
        public static string RemoveRegular(this string text, string regularExpression)
        {
            text = Regex.Replace(text, regularExpression, " ").Trim().ToString();
            return text;
        }
        public static string MySubstring(this string text, int charachterCount)
        {
            if (charachterCount >= text.Length)
            {

                return text.Substring(0, text.Length);
            }
            return text.Substring(0, charachterCount);
        }
        public static string GetEnumDescription<T>(this T value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                return "نامشخص";
            }
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Any() ? ((DescriptionAttribute)attributes.ElementAt(0)).Description
                        : "";
        }
        public static string ToFa(this DateTime date, string format)
        {
            var persianDateTime = new PersianDateTime(date);
            return persianDateTime.ToString(format);    
        }
        public static DateTime ToEn(this string persianDate)
        {
            var datetime =  PersianDateTime.Parse(persianDate);
            return datetime.ToDateTime();
        }

        //public static Workbook CreateExcelWorkbook()
        //{
        //    string key = "Idd65VXxKpEAgBvZ1nVhUN+w7vpItcbvurq9YsmKuDda+JAEE9qF2G4YzR3o0s96HLaSfKKXq8fmv/VifgjLP/ZHrAKRewKyimE+b1l5tI82tdsWa+W3TgkLfepngT3Ui+LuaUc8pxXYEPd/bacNeg6yvWi7xVPzxDsE/m3D+OyD1ifz4S4lkOhjUS4pJ9gIKv6eIx0aXzRyczi4c+55+yRRBjUsB3AUS5C4sGq4LaSbeVLRq52visiCeMQxIkO6G38uTOyJl3mplKPrB3tpSTpmDc0j1WLuce1KIA9GbtKqOgh5vJwnXnwR3qeVgEBY2Lgrt6Gu0RModahYN6N5ODyj526SSOsz50jUQsrjfnk2JYKq3D3GA+lshknDJsSyHHkqYNxXfha7GQ4e11FhxALPu81LBXLXez4l73XCV9n6cdvHnyOerI18clWh/g6lgfEG+N+ugko2oxET/WEeIVKoIvpEw9YMv5bQrD6oWlN5GthgiXawtPQ6kM41r0MKW75+6ojDqRbOqvyVwC4HNRf2MXjni/Bdo0KBG3SD119bQfa+4zBREiEz6X26Mv7Tc0n8YzGTcK7VZcRGqI06bp4RDiFvAMrn4Y83gJaVRX6MbSJqwpKXKugSrmf0ck6XzLmhQcjsznnLkToXxvBS2jh6Vy3JZXvt4l8JUF8zE9CPix+kpDcGedXA1MmN/dju6Ps4sgGGAnjrfl1YLHvbQR8kii+h9tKrUrjTT88xvjjwz5IXmC4MX2A6HjSqabQwLVm8wfwNF22Pp1nMuX5DVP2pyNMMYMHIewGlJRSQz3j/7gVbw264aeBJPGyVpxrZCRO7byu/Z8cKTk02S+vZTazhIjV4jmn8zLOsxH0wsbcEpDLw1XnrH4tUiIRDQxRO+EBtpPklyFx9Q8AYkIv91osUiQZ14MXfysJ8oHG8gqHa7uidcd+YgFc3FRlFlVXYqqQlABFg5/ZvUHUklZdiRLenTb2yfl3RffnzA1aevJcLy2sBoWUrTxZlAFu0u8D2+swu0V3juiLM8pO9VDB4gHtQh3n/cnvShuv8hls2fi0TTZvpxLdfBw==";
        //    //key = $@"<License Key=""{key}"" Version=""999.999""></License>";
        //    Spire.License.LicenseProvider.SetLicenseKey(key);
        //    Workbook workbook = new Workbook();
        //    workbook.Worksheets.Clear();
        //    return workbook;
        //}
        //public static Workbook CreateExcelWorkbook(MemoryStream stream)
        //{
        //    string key = "Idd65VXxKpEAgBvZ1nVhUN+w7vpItcbvurq9YsmKuDda+JAEE9qF2G4YzR3o0s96HLaSfKKXq8fmv/VifgjLP/ZHrAKRewKyimE+b1l5tI82tdsWa+W3TgkLfepngT3Ui+LuaUc8pxXYEPd/bacNeg6yvWi7xVPzxDsE/m3D+OyD1ifz4S4lkOhjUS4pJ9gIKv6eIx0aXzRyczi4c+55+yRRBjUsB3AUS5C4sGq4LaSbeVLRq52visiCeMQxIkO6G38uTOyJl3mplKPrB3tpSTpmDc0j1WLuce1KIA9GbtKqOgh5vJwnXnwR3qeVgEBY2Lgrt6Gu0RModahYN6N5ODyj526SSOsz50jUQsrjfnk2JYKq3D3GA+lshknDJsSyHHkqYNxXfha7GQ4e11FhxALPu81LBXLXez4l73XCV9n6cdvHnyOerI18clWh/g6lgfEG+N+ugko2oxET/WEeIVKoIvpEw9YMv5bQrD6oWlN5GthgiXawtPQ6kM41r0MKW75+6ojDqRbOqvyVwC4HNRf2MXjni/Bdo0KBG3SD119bQfa+4zBREiEz6X26Mv7Tc0n8YzGTcK7VZcRGqI06bp4RDiFvAMrn4Y83gJaVRX6MbSJqwpKXKugSrmf0ck6XzLmhQcjsznnLkToXxvBS2jh6Vy3JZXvt4l8JUF8zE9CPix+kpDcGedXA1MmN/dju6Ps4sgGGAnjrfl1YLHvbQR8kii+h9tKrUrjTT88xvjjwz5IXmC4MX2A6HjSqabQwLVm8wfwNF22Pp1nMuX5DVP2pyNMMYMHIewGlJRSQz3j/7gVbw264aeBJPGyVpxrZCRO7byu/Z8cKTk02S+vZTazhIjV4jmn8zLOsxH0wsbcEpDLw1XnrH4tUiIRDQxRO+EBtpPklyFx9Q8AYkIv91osUiQZ14MXfysJ8oHG8gqHa7uidcd+YgFc3FRlFlVXYqqQlABFg5/ZvUHUklZdiRLenTb2yfl3RffnzA1aevJcLy2sBoWUrTxZlAFu0u8D2+swu0V3juiLM8pO9VDB4gHtQh3n/cnvShuv8hls2fi0TTZvpxLdfBw==";
        //    //key = $@"<License Key=""{key}"" Version=""999.999""></License>";
        //    Spire.License.LicenseProvider.SetLicenseKey(key);
        //    Workbook workbook = new Workbook();
        //    workbook.LoadFromStream(stream);
        //    return workbook;
        //}
        //public static string Hash(this string text)
        //{
        //    var passwordHasher = PasswordHasherInstance.Create(HashAlgorithm.SHA256, 10);
        //    return passwordHasher.Hash(text);
        //}
        //public static bool ValidateHash(this string text, string hashText)
        //{
        //    var passwordHasher = PasswordHasherInstance.Create(HashAlgorithm.SHA256, 10);
        //    return passwordHasher.Validate(text, hashText);
        //}
        public static string FromBase64(this string base64Text)
        {
            byte[] data = Convert.FromBase64String(base64Text);
            string decodedString = System.Text.Encoding.UTF8.GetString(data);
            return decodedString;
        }
        public static string ToBase64(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}