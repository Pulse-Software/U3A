using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.Utils.Filtering;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace U3A.Services
{
    public class ParseCSVService
    {
        Dictionary<string, int> headers;
        public ParseCSVService(string[] Headers) {
            headers = new Dictionary<string, int>();
            for (int i = 0; i < Headers.Length; i++) {
                headers[Headers[i].ToLower()] = i;
                headers.TryAdd(Headers[i].ToLower().Replace(" ", ""), i);
            }
        }

        public void ParseModel<T>(T Model, string[] Values) {
            //Get the type of source object
            Type typeSource = Model.GetType();
            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty);
            //Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo) {
                //Check whether property can be written to
                if (property.CanWrite) {
                    //check whether property type is value type, enum or string type
                    if (property.PropertyType.IsValueType || property.PropertyType.IsEnum || property.PropertyType.Equals(typeof(System.String))) {
                        var result = ParseField(property, Values);
                        if (result != null) { property.SetValue(Model, result, null); }
                    }
                }
            }
        }

        public string ParseField(string Name, string[] Values) {
            string result = string.Empty;
            int position;
            if (headers.TryGetValue(Name.ToLower(), out position)) {
                result = Values[position];
            }
            return result;
        }

        private object ParseField(PropertyInfo property, string[] Values) {
            object result = null;
            int position;
            if (headers.TryGetValue(property.Name.ToLower(), out position)) {
                string data = Values[position];
                try {
                    if (!string.IsNullOrEmpty(data)) {
                        string typeNmae = (property as PropertyInfo).PropertyType.FullName;
                        result = Convert.ChangeType(data, Type.GetType(typeNmae));
                    }
                }
                catch (Exception) {
                    result = null;
                }
            };
            return result;
        }

    }
}
