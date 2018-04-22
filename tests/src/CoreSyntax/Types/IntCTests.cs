using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Types
{
    public class IntCTests
    {
        private const int Value = 324;
        private IntC _obj = new IntC(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new IntC(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new IntC(Value + 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new IntC(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "IntC(" + Value + ")");
        }

        [Fact]
        public void InterpretTest()
        {
            Assert.Equal(_obj.Interpret(), new IntV(Value));
        }
    }
}
