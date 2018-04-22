using Splaak.Core.AbstractSyntax.BinOps;
using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;
using Xunit;

namespace Splaak.Tests.AbstractSyntax.BinOps
{
    public class PlusExtTests
    {
        private static IntExt _1 = new IntExt(10);
        private static IntExt _2 = new IntExt(2);
        private PlusExt _obj = new PlusExt(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Argument1, _1);
            Assert.Equal(_obj.Argument2, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new PlusExt(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new PlusExt(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new PlusExt(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "PlusExt(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new PlusC(new IntC(_1.Value), new IntC(_2.Value)));
        }
    }
}
