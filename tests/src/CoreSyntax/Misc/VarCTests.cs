using Splaak.Core.CoreSyntax.Misc;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Misc
{
    public class VarCTests
    {
        private const string Value = "dfgnupwe4";
        private VarC _obj = new VarC(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new VarC(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new VarC(Value + 1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new VarC(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "VarC(" + Value + ")");
        }

        [Fact]
        public void InterpretFailureTest()
        {
            Assert.Throws<InterpretException>(() => _obj.Interpret());
        }

        [Fact]
        public void InterpretSuccessTest()
        {
            Environment env = new Environment().Add(Value, new FloatV(3.5f));
            Assert.Equal(_obj.Interpret(env), new FloatV(3.5f));
        }
    }
}
