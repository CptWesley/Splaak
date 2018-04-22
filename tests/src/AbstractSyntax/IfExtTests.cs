using Splaak.Core.AbstractSyntax;
using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.AbstractSyntax
{
    public class IfExtTests
    {
        private static IntExt _1 = new IntExt(10);
        private static IntExt _2 = new IntExt(2);
        private static IntExt _3 = new IntExt(543);
        private IfExt _obj = new IfExt(_1, _2, _3);

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
            Assert.True(_obj.Equals(new IfExt(_1, _2, _3)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new IfExt(_1, _2, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new IfExt(_1, _2, _3).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "IfExt(" + _1 + ", " + _2 + ", " + _3 + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new IfC(_1.Desugar(), _2.Desugar(), _3.Desugar()));
        }
    }
}
