using Splaak.Core.AbstractSyntax.Misc;
using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.CoreSyntax.Misc;
using Xunit;

namespace Splaak.Tests.AbstractSyntax.Misc
{
    public class PlusExtTests
    {
        private static string _1 = "adsfa";
        private static IntExt _2 = new IntExt(2);
        private SetExt _obj = new SetExt(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Name, _1);
            Assert.Equal(_obj.Argument, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SetExt(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualNameTest()
        {
            Assert.False(_obj.Equals(new SetExt("", _2)));
        }

        [Fact]
        public void EqualsNotEqualArgumentTest()
        {
            Assert.False(_obj.Equals(new SetExt(_1, new BoolExt(false))));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SetExt(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SetExt(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new SetC(_1, _2.Desugar()));
        }
    }
}
