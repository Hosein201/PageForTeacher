using Newtonsoft.Json;
using System;

namespace Utility.Utilities
{
    public static class UtilityJsonConvert
    {
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static bool TryDeserializeObject<T>(string value)
        {
            try
            {
                JsonConvert.DeserializeObject<T>(value);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
