using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.Values.Misc
{
    public class ThunkVTests
    {
        private static readonly Environment Environment = new Environment();
        private static readonly ExprC Expression = new IntC(3);
        private readonly ThunkV _obj = new ThunkV(Expression, new Environment());

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(Expression, _obj.Expression);
            Assert.Equal(Environment, _obj.Environment);
            Assert.Null(_obj.Value);
            Assert.False(_obj.IsInterpreted);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new ThunkV(Expression, Environment)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new ThunkV(new BoolC(false), Environment)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new FloatV(0)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new ThunkV(Expression, Environment).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), $"ThunkV({Expression}, {Environment})");
        }

        [Fact]
        public void StrictTest()
        {
            ExprC pair = new PairC(Expression, Expression);
            ThunkV thunk = new ThunkV(pair, Environment);
            Assert.Equal(thunk.Strict(), pair.Interpret());
            Assert.True(thunk.IsInterpreted);
            Assert.Equal(thunk.Value, pair.Interpret());
            Assert.Null(thunk.Environment);
            Assert.Null(thunk.Expression);
            Assert.NotEqual(thunk, _obj);
        }

        [Fact]
        public void ForceTest()
        {
            ExprC pair = new PairC(Expression, Expression);
            ThunkV thunk = new ThunkV(pair, Environment);
            Assert.Equal(thunk.Force(), pair.Interpret().Force());
            Assert.True(thunk.IsInterpreted);
            Assert.Equal(thunk.Value, pair.Interpret().Force());
            Assert.Null(thunk.Environment);
            Assert.Null(thunk.Expression);
            Assert.NotEqual(thunk, _obj);
        }
    }
}
