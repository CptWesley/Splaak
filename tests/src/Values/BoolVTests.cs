using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Values
{
    public class BoolVTests
    {
        private const bool Value = true;
        private BoolV _obj = new BoolV(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new BoolV(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new BoolV(!Value)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntV(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new BoolV(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "BoolV(" + Value + ")");
        }
    }
}
