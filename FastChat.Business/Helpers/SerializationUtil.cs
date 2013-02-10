using Newtonsoft.Json;

namespace CodeFiction.FastChat.Business.Helpers
{
    public static class SerializationUtil
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TObjectType Deserialize<TObjectType>(string text)
        {
            return JsonConvert.DeserializeObject<TObjectType>(text);
        }
    }
}
