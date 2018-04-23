using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.CoreSyntax.Types;
using Xunit;

namespace Splaak.Tests.AbstractSyntax.Types
{
    public class NullExtTests
    {
        private NullExt _obj = new NullExt();

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new NullExt()));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new NullExt().GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("NullExt()", _obj.ToString());
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new NullC());
        }
    }
}
