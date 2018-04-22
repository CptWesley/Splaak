using Splaak.Core.AbstractSyntax;
using Splaak.Core.Reader.Expressions;
using Xunit;

namespace Splaak.Tests.Reader.Expressions
{
    public class SIntTests
    {
        private const int Value = 42;
        private SInt _obj = new SInt(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SInt(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SInt(Value - 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new SSym("")));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SInt(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SInt(" + Value + ")");
        }

        [Fact]
        public void ParseTest()
        {
            Assert.Equal(_obj.Parse(), new IntExt(Value));
        }
    }
}
