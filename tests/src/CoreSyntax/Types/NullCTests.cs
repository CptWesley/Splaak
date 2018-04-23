using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Types
{
    public class NullCTests
    {
        private NullC _obj = new NullC();

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new NullC()));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new NullC().GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("NullC()", _obj.ToString());
        }

        [Fact]
        public void InterpretTest()
        {
            Assert.Equal(_obj.Interpret(), new NullV());
        }
    }
}
