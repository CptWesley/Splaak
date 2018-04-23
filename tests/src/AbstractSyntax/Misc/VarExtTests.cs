using Splaak.Core.AbstractSyntax.Misc;
using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.CoreSyntax.Misc;
using Xunit;

namespace Splaak.Tests.AbstractSyntax.Misc
{
    public class VarExtTests
    {
        private const string Value = "fdsfdsfgdsfds";
        private VarExt _obj = new VarExt(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new VarExt(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new VarExt(Value + 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolExt(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new VarExt(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "VarExt(" + Value + ")");
        }

        [Fact]
        public void DesugarTest()
        {
            Assert.Equal(_obj.Desugar(), new VarC(Value));
        }
    }
}
