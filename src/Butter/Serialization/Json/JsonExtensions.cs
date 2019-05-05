namespace Butter.Serialization.Json
{
    using System;
    using System.IO;
    using System.Text;
    using Data;
    using Newtonsoft.Json;

    public static class JsonExtensions
    {
        /// <summary>
        /// Takes an object and returns the JSON text representation of said object.
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToJsonString<T>(this T obj)
        {
            if (obj == null)
                return string.Empty;
            
            var encoding = new UTF8Encoding(false, true);
            
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding, 1024, true))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;

                SerializerCache.Serializer.Serialize(jsonWriter, obj, typeof(T));

                jsonWriter.Flush();
                writer.Flush();

                return encoding.GetString(stream.ToArray());
            }
        }

        public static string ToJsonString(this IFieldList fields)
        {
            if (fields == null)
                return String.Empty;
            
            var encoding = new UTF8Encoding(false, true);
            
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream, encoding, 1024, true))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                jsonWriter.Formatting = Formatting.Indented;

                SerializerCache.Serializer.Serialize(jsonWriter, fields, typeof(IFieldList));
//                for (int i = 0; i < fields.Count; i++)
//                {
//                    SerializerCache.Serializer.Serialize(jsonWriter, fields[i], typeof(IFieldList));
//                }

                jsonWriter.Flush();
                writer.Flush();

                return encoding.GetString(stream.ToArray());
            }
        }
    }
}