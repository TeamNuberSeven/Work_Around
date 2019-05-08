using System;
using Xunit;

namespace XUnitTests
{
    public class MainUnitTest
    {
        [Fact]
        public void Test()
        {
            var expectedValue = true;
 
            Assert.True(expectedValue);
        }
    }
}
