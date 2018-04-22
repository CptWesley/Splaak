using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.CoreSyntax
{
    public class SecondCTests
    {
        private static PairC Value = new PairC(new IntC(0), new IntC(1));
        private SecondC _obj = new SecondC(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Argument);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SecondC(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SecondC(new BoolC(false))));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SecondC(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SecondC(" + Value + ")");
        }

        [Fact]
        public void InterpretTest()
        {
            Assert.Equal(_obj.Interpret(), Value.Right.Interpret());
        }
    }
}
