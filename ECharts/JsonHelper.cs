using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECharts.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeConverterUsingDateTimeParse : JsonConverter<DateTime>
    {
        /// <summary>
        /// 日期格式
        /// </summary>
        public string dateTimeFormat { get; }
        /// <summary>
        /// ctor
        /// </summary>      
        /// <param name="dateTimeFormat"></param>
        public DateTimeConverterUsingDateTimeParse(string dateTimeFormat)
        {
            this.dateTimeFormat = dateTimeFormat;
        }
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(dateTimeFormat));
        }
    }
    /// <summary>
    /// json辅助
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>Converts to json.</summary>
        /// <param name="obj">The object.</param>
        /// <param name="dateTimeFormat">The date time format.</param>
        /// <returns>System.String.</returns>
        public static string ToJson(this object obj, string dateTimeFormat = "yyyy-MM-dd")
        {
            var options = new JsonSerializerOptions() { IgnoreNullValues = true, WriteIndented = true };
            options.Converters.Add(new DateTimeConverterUsingDateTimeParse(dateTimeFormat));
            Configure?.Invoke(options);
            return JsonSerializer.Serialize(obj, options);
        }
        
		/// <summary>
		/// 修改配置的注入口
		/// </summary>
		public static Action<JsonSerializerOptions> Configure;
    }
}
