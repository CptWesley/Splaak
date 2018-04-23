using Splaak.Core.CoreSyntax.Misc;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Misc
{
    public class IfCTests
    {
        private static BoolC _1 = new BoolC(true);
        private static IntC _2 = new IntC(10);
        private static IntC _3 = new IntC(2);
        private IfC _obj = new IfC(_1, _2, _3);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Condition, _1);
            Assert.Equal(_obj.Then, _2);
            Assert.Equal(_obj.Else, _3);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new IfC(_1, _2, _3)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new IfC(_1, _2, _2)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new IfC(_1, _2, _3).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "IfC(" + _1 + ", " + _2 + ", " + _3 +")");
        }

        [Fact]
        public void InterpretTrueTest()
        {
            Assert.Equal(new IfC(new BoolC(true), new IntC(1), new IntC(2)).Interpret(), new IntV(1));
        }

        [Fact]
        public void InterpretFalseTest()
        {
            Assert.Equal(new IfC(new BoolC(false), new IntC(1), new IntC(2)).Interpret(), new IntV(2));
        }

        [Fact]
        public void InterpretExceptionTest()
        {
            Assert.Throws<InterpretException>(() => new IfC(new IntC(1), new IntC(1), new IntC(2)).Interpret());
        }
    }
}
