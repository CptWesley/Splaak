using Splaak.Core.Values;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.Values.Types
{
    public class PairVTests
    {
        private static IValue _1 = new IntV(0);
        private static IValue _2 = new IntV(1);
        private PairV _obj = new PairV(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Left, _1);
            Assert.Equal(_obj.Right, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new PairV(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new PairV(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new IntV(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new PairV(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), $"PairV({_1}, {_2})");
        }
    }
}
