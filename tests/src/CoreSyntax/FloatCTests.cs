using Splaak.Core.CoreSyntax;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.CoreSyntax
{
    public class FloatCTests
    {
        private const float Value = 4325;
        private FloatC _obj = new FloatC(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new FloatC(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new FloatC(Value + 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntC(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new FloatC(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "FloatC(" + Value + ")");
        }

        [Fact]
        public void InterpretTest()
        {
            Assert.Equal(_obj.Interpret(), new FloatV(Value));
        }
    }
}
