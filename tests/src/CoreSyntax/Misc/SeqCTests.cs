using Splaak.Core.CoreSyntax.Misc;
using Splaak.Core.CoreSyntax.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Misc
{
    public class SeqCTests
    {
        private static IntC _1 = new IntC(10);
        private static IntC _2 = new IntC(2);
        private SeqC _obj = new SeqC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Left, _1);
            Assert.Equal(_obj.Right, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SeqC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SeqC(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SeqC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SeqC(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void InterpretIntIntTest()
        {
            Assert.Equal(_obj.Interpret(), _2.Interpret());
        }
    }
}
