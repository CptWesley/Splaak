using Splaak.Core.CoreSyntax.Misc;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.Misc
{
    public class SetCTests
    {
        private static string _1 = "a";
        private static IntC _2 = new IntC(2);
        private SetC _obj = new SetC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Name, _1);
            Assert.Equal(_obj.Argument, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SetC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualNameTest()
        {
            Assert.False(_obj.Equals(new SetC("", _2)));
        }

        [Fact]
        public void EqualsNotEqualArgumentTest()
        {
            Assert.False(_obj.Equals(new SetC(_1, new BoolC(true))));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SetC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SetC(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void InterpretIntIntTest()
        {
            Assert.Equal(_obj.Interpret(new Environment().Add(_1, new BoolV(true))), _2.Interpret());
        }
    }
}
