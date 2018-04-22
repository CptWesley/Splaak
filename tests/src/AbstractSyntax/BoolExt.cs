using Splaak.Core.AbstractSyntax;
using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.AbstractSyntax
{
    public class BoolExtTests
    {
        private const bool Value = false;
        private BoolExt _obj = new BoolExt(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new BoolExt(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new BoolExt(!Value)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntExt(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new BoolExt(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "BoolExt(" + Value + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new BoolC(Value));
        }
    }
}
