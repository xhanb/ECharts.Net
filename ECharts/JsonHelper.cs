using System.Collections.Generic;
using Formatting = System.Xml.Formatting;

namespace ECharts.Net
{
    /// <summary>
    /// json辅助
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// object转json（包含日期格式处理）
        /// </summary>  
        /// <param name="obj">object</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
#if NETSTANDARD2_0
            var op = new System.Text.Json.Serialization.JsonSerializerOptions { IgnoreNullValues = true, WriteIndented = true };
            return System.Text.Json.Serialization.JsonSerializer.ToString(obj, op);
#else
            var jSetting = new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(obj, (Newtonsoft.Json.Formatting)Formatting.Indented, jSetting);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject(json, typeof(object), jSetting);
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd hh:mm" };
            json = Newtonsoft.Json.JsonConvert.SerializeObject(data, (Newtonsoft.Json.Formatting)Formatting.Indented, timeConverter);
            return json;
#endif

        }
    }
}
