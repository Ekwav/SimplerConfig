using NUnit.Framework;
using SimplerConfig;

namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Config.Instance = new Config();
        }

        [Test]
        public void CustomConf()
        {
            // get value from custom.conf.json
            Assert.AreEqual("exists",Config.Instance["testVal"]);
        }

        [Test]
        public void CommandLineArgsSimple()
        {
            Config.Instance.StartArgs = new string[]{"--testVal=overwritten"};
            Assert.AreEqual("overwritten",Config.Instance["testVal"]);
        }

        [Test]
        public void CommandLineArgsMultipleMinus()
        {
            Config.Instance.StartArgs = new string[]{"--testVal","custom"};
            Assert.AreEqual("custom",Config.Instance["testVal"]);
        }

        [Test]
        public void CommandLineArgsMultipleSlash()
        {
            Config.Instance.StartArgs = new string[]{"/testVal","custom"};
            Assert.AreEqual("custom",Config.Instance["testVal"]);
        }

        [Test]
        public void CommandLineArgs()
        {
            Config.Instance.StartArgs = new string[]{"testVal=custom"};
            Assert.AreEqual("custom",Config.Instance["testVal"]);
        }

        [Test]
        public void NotFound()
        {
            Assert.IsNull(Config.Instance["notExistingKey"]);
        }
    }
}