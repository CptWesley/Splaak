using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Values
{
    public class BindTests
    {
        private static string _1 = "greatname";
        private static IValue _2 = new IntV(1);
        private Bind _obj = new Bind(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Id, _1);
            Assert.Equal(_obj.Value, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new Bind(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualIdTest()
        {
            Assert.False(_obj.Equals(new Bind("", _2)));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new Bind(_1, new IntV(0))));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntV(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new Bind(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), $"Bind({_1}, {_2})");
        }
    }
}
