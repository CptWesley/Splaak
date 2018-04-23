using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Values
{
    public class NullVTests
    {
        private NullV _obj = new NullV();

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new NullV()));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new FloatV(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new NullV().GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("NullV()", _obj.ToString());
        }
    }
}
