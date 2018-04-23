using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.BinOps
{
    public class LtCTests
    {
        private static IntC _1 = new IntC(10);
        private static IntC _2 = new IntC(2);
        private LtC _obj = new LtC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Argument1, _1);
            Assert.Equal(_obj.Argument2, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new LtC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new LtC(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new LtC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "LtC(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void InterpretIntIntTrueTest()
        {
            Assert.Equal(new LtC(new IntC(10), new IntC(30)).Interpret(), new BoolV(true));
        }

        [Fact]
        public void InterpretIntIntFalseTest()
        {
            Assert.Equal(new LtC(new IntC(10), new IntC(3)).Interpret(), new BoolV(false));
        }

        [Fact]
        public void InterpretFloatFloatTrueTest()
        {
            Assert.Equal(new LtC(new FloatC(10), new FloatC(50)).Interpret(), new BoolV(true));
        }

        [Fact]
        public void InterpretFloatFloatFalseTest()
        {
            Assert.Equal(new LtC(new FloatC(10), new FloatC(5)).Interpret(), new BoolV(false));
        }

        [Fact]
        public void InterpretFloatIntTrueTest()
        {
            Assert.Equal(new LtC(new FloatC(10), new IntC(50)).Interpret(), new BoolV(true));
        }

        [Fact]
        public void InterpretFloatIntFalseTest()
        {
            Assert.Equal(new LtC(new FloatC(10), new IntC(5)).Interpret(), new BoolV(false));
        }

        [Fact]
        public void InterpretIntFloatTrueTest()
        {
            Assert.Equal(new LtC(new IntC(10), new FloatC(50)).Interpret(), new BoolV(true));
        }

        [Fact]
        public void InterpretIntFloatFalseTest()
        {
            Assert.Equal(new LtC(new IntC(10), new FloatC(5)).Interpret(), new BoolV(false));
        }

        [Fact]
        public void InterpretLeftNaNExceptionTest()
        {
            Assert.Throws<InterpretException>(() => new DivC(new BoolC(true), new FloatC(5)).Interpret());
        }

        [Fact]
        public void InterpretRightNaNExceptionTest()
        {
            Assert.Throws<InterpretException>(() => new DivC(new FloatC(5), new BoolC(true)).Interpret());
        }
    }
}
