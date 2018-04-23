using Splaak.Core.AbstractSyntax;
using Splaak.Core.AbstractSyntax.Misc;
using Splaak.Core.AbstractSyntax.Types;
using Splaak.Core.Reader.Expressions;
using Xunit;

namespace Splaak.Tests.Reader.Expressions
{
    public class SSymTests
    {
        private const string Value = "blablabla";
        private SSym _obj = new SSym(Value);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Value, _obj.Value);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SSym(Value)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new SSym("")));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new SInt(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SSym(Value).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SSym(" + Value + ")");
        }

        [Fact]
        public void ParseExceptionTest()
        {
            Assert.Throws<ParseException>(() => new SSym("+").Parse());
        }

        [Fact]
        public void ParseTrueTest()
        {
            Assert.Equal(new SSym("true").Parse(), new BoolExt(true));
        }

        [Fact]
        public void ParseFalseTest()
        {
            Assert.Equal(new SSym("false").Parse(), new BoolExt(false));
        }

        [Fact]
        public void ParseNullTest()
        {
            Assert.Equal(new SSym("null").Parse(), new NullExt());
        }

        [Fact]
        public void ParseVarTest()
        {
            Assert.Equal(_obj.Parse(), new VarExt(Value));
        }
    }
}
