using Newtonsoft.Json;
using NUnit.Framework;

namespace OMDbApi.Test.Helpers
{
    public static class AssertHelper
    {
        public static void AreEqual(object obj1, object obj2)
        {
            string json1 = JsonConvert.SerializeObject(obj1);
            string json2 = JsonConvert.SerializeObject(obj2);

            Assert.AreEqual(json1, json2);
        }
    }
}
