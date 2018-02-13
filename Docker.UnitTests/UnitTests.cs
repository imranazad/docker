using System;
using NUnit.Framework;

namespace Docker.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void ShouldUppercase()
        {

            var output = Uppercaser.Uppercase("hello my name is imran");
            Assert.AreEqual("HELLO MY NAME IS IMRAN", output);
        }
    }
}
