using Splaak.Core.AbstractSyntax;
using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.AbstractSyntax
{
    public class FloatExtTests
    {
        private const float Value = 256;
        private FloatExt _obj = new FloatExt(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new FloatExt(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new FloatExt(Value * 2)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new FloatExt(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "FloatExt(" + Value + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new FloatC(Value));
        }
    }
}
