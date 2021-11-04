using Camefor.Cache.Base;
using Camefor.Cache.Factory;
using NUnit.Framework;

namespace Camefor.Cache.Tests
{
    public class Tests
    {

        ICache _cache;

        [SetUp]
        public void Setup()
        {
            _cache = CacheFactory.CaChe();

        }

        [Test]
        public void WriteSomething()
        {
            var testData = "hello world!";

            _cache.Write<string>("akey", testData, 1);
            var readResult = _cache.Read<string>("akey", 1);
            Assert.IsFalse(string.IsNullOrEmpty(readResult), "不应该为空");
            Assert.AreEqual(testData, readResult);
        }
    }
}