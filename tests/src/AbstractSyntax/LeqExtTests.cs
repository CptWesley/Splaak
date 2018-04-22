using Splaak.Core.AbstractSyntax;
using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.AbstractSyntax
{
    public class LeqExtTests
    {
        private static IntExt _1 = new IntExt(10);
        private static IntExt _2 = new IntExt(2);
        private LeqExt _obj = new LeqExt(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Argument1, _1);
            Assert.Equal(_obj.Argument2, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new LeqExt(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new LeqExt(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new LeqExt(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "LeqExt(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(),
                new IfC(new LtC(_1.Desugar(), _2.Desugar()),
                new BoolC(true), new EqC(_1.Desugar(), _2.Desugar())));
        }
    }
}
