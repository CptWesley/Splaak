using Splaak.Core.AbstractSyntax;
using Splaak.Core.Reader.Expressions;
using Xunit;

namespace Splaak.Tests.Reader.Expressions
{
    public class SFloatTests
    {
        private const int Value = 42;
        private SFloat _obj = new SFloat(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SFloat(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SFloat(Value - 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new SSym("")));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SFloat(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SFloat(" + Value + ")");
        }

        [Fact]
        public void ParseTest()
        {
            Assert.Equal(_obj.Parse(), new FloatExt(Value));
        }
    }
}