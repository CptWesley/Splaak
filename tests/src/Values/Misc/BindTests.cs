using Splaak.Core.Values;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.Values.Misc
{
    public class BindTests
    {
        private static IValue _2 = new IntV(1);
        private Bind _obj = new Bind(_2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Value, _2);
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), $"Bind({_2})");
        }
    }
}
