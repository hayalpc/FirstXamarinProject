using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.Extensions
{
    public static class ConvertExtension
    {
        public static T Convert<T>(this object source)
        {
            if (source == null)
            {
                return default(T);
            }
            var deserializeSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
    }
}
