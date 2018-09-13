using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonitoR.Common.Utilities
{
    public static class JsonUtils
    {
        public static string Serialize<T>(T entity, bool prettyPrint = true)
        {
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T),new DataContractJsonSerializerSettings {  UseSimpleDictionaryFormat = true });
            ser.WriteObject(stream1, entity);
            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

        public static T Deserialize<T>(String pJsonString)
        {
            var memoryStream = new MemoryStream(StringUtils.StringToUTF8ByteArray(pJsonString));
            var ser = new DataContractJsonSerializer(typeof(T));
            memoryStream.Position = 0;
            var result = (T)ser.ReadObject(memoryStream);
            return result;
        }
    }
}
