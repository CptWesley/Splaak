using Splaak.Core.AbstractSyntax;
using Splaak.Core.AbstractSyntax.Misc;
using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.CoreSyntax.Misc;
using Xunit;

namespace Splaak.Tests.AbstractSyntax.Misc
{
    public class SeqExtTests
    {
        private static IExprExt _1 = new IntExt(1);
        private static IExprExt _2 = new IntExt(2);
        private static IExprExt _3 = new IntExt(3);
        private SeqExt _obj = new SeqExt(_1, _2, _3);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Operations[0], _1);
            Assert.Equal(_obj.Operations[1], _2);
            Assert.Equal(_obj.Operations[2], _3);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SeqExt(_1, _2, _3)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualLengthTest()
        {
            Assert.False(_obj.Equals(new SeqExt(_1, _2)));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SeqExt(_1, _2, _2)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntExt(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SeqExt(_1, _2, _3).GetHashCode());
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new SeqC(_1.Desugar(), new SeqC(_2.Desugar(), _3.Desugar())));
        }
    }
}
