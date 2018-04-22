using Splaak.Core.CoreSyntax;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.CoreSyntax
{
    public class EqCTests
    {
        private static IntC _1 = new IntC(10);
        private static IntC _2 = new IntC(2);
        private EqC _obj = new EqC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Argument1, _1);
            Assert.Equal(_obj.Argument2, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new EqC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new EqC(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new EqC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "EqC(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void InterpretFalseTest()
        {
            Assert.Equal(new EqC(new IntC(10), new IntC(3)).Interpret(), new BoolV(false));
        }

        [Fact]
        public void InterpretTrueTest()
        {
            Assert.Equal(new EqC(new IntC(12), new IntC(12)).Interpret(), new BoolV(true));
        }
    }
}
