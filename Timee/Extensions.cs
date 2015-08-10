using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Deployment.Application;
using System.Xml.Serialization;
using Timee.Services;

namespace Timee
{
    public static class Extensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }


        public static T Clone<T>(T source)
        {
            var serialized = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(serialized);
        }
/// <summary>
/// Serialize Generic List to string
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="toSerialize"></param>
/// <returns></returns>
        public static string SerializeObject<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
        /// <summary>
        /// Deserialize Generic List from string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="toDeserialize"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(this T toDeserialize, StringReader source)
        {
            XmlSerializer xmlDeserializer = new XmlSerializer(toDeserialize.GetType());

            var list  =  (T)xmlDeserializer.Deserialize(source);
            return list;
        }

 
    }
}
