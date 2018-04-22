using Splaak.Core.AbstractSyntax;
using Splaak.Core.CoreSyntax;
using Xunit;

namespace Splaak.Tests.AbstractSyntax
{
    public class TupleExtTests
    {
        private static IExprExt _1 = new IntExt(1);
        private static IExprExt _2 = new IntExt(2);
        private static IExprExt _3 = new IntExt(3);
        private TupleExt _obj = new TupleExt(new[] { _1, _2, _3 });

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Elements[0], _1);
            Assert.Equal(_obj.Elements[1], _2);
            Assert.Equal(_obj.Elements[2], _3);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new TupleExt(new[] { _1, _2, _3 })));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualLengthTest()
        {
            Assert.False(_obj.Equals(new TupleExt(new[] { _1, _2 })));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new TupleExt(new[] { _1, _2, _2 })));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntExt(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new TupleExt(new[] { _1, _2, _3 }).GetHashCode());
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new PairC(_1.Desugar(), new PairC(_2.Desugar(), _3.Desugar())));
        }
    }
}
