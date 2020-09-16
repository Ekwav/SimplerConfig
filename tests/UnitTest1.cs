using NUnit.Framework;

namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomConf()
        {
            // get value from custom.conf.json
            Assert.AreEqual("exists",SimplerConfig.SimplerConfig.Instance["testVal"]);
        }
    }
}