using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.CoreSyntax.UnOps;
using Splaak.Core.Values.Misc;
using Xunit;

namespace Splaak.Tests.CoreSyntax.UnOps
{
    public class FirstCTests
    {
        private static PairC Value = new PairC(new IntC(0), new IntC(1));
        private FirstC _obj = new FirstC(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Argument);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new FirstC(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new FirstC(new BoolC(false))));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new FirstC(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "FirstC(" + Value + ")");
        }

        [Fact]
        public void InterpretTest()
        {
            Assert.Equal(_obj.Interpret(), new ThunkV(Value.Left, new Environment()));
        }
    }
}
