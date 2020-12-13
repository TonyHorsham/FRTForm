// 13 12 2020 Created by Tony Horsham 13:35

using System.Text.Json;

namespace FRTForm.Utilities
{
    public static class FRTFormExtensions
    {
        public static T CloneObject<T>(this T obj) where T : class
        {
            string jsonString = JsonSerializer.Serialize(obj);
            object result = JsonSerializer.Deserialize<T>(jsonString);
            return (T)result;
        }
    }
}