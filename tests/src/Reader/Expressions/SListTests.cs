using Splaak.Core.AbstractSyntax;
using Splaak.Core.Reader.Expressions;
using Xunit;

namespace Splaak.Tests.Reader.Expressions
{
    public class SListTests
    {
        private static SSym _1 = new SSym("bla");
        private static SInt _2 = new SInt(43);
        private SList _obj = new SList(new ISExpression[] { _1, _2 });

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(2, _obj.Expressions.Length);
            Assert.True(_obj.Expressions[0].Equals(_1));
            Assert.True(_obj.Expressions[1].Equals(_2));
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new SList(new ISExpression[] { _1, _2 })));
        }

        [Fact]
        public void EqualsNullListTest()
        {
            Assert.True(new SList(new ISExpression[] { null, null })
                .Equals(new SList(new ISExpression[] { null, null })));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualLengthTest()
        {
            Assert.False(_obj.Equals(new SList(new ISExpression[] { _1 })));
        }

        [Fact]
        public void EqualsNotEqualElementsTest()
        {
            Assert.False(_obj.Equals(new SList(new ISExpression[] { _1, null })));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new SSym("")));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new SList(new ISExpression[] { _1, _2 }).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "SList(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void ParseExceptionTest()
        {
            Assert.Throws<ParseException>(() => _obj.Parse());
        }
    }
}
