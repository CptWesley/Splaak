﻿using Splaak.Core.CoreSyntax;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.CoreSyntax
{
    public class PairCTests
    {
        private static IntC _1 = new IntC(10);
        private static IntC _2 = new IntC(2);
        private PairC _obj = new PairC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Left, _1);
            Assert.Equal(_obj.Right, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new PairC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new PairC(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new PairC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "PairC(" + _1 + ", " + _2 + ")");
        }

        [Fact]
        public void InterpretIntIntTest()
        {
            Assert.Equal(_obj.Interpret(), new PairV(_1.Interpret(), _2.Interpret()));
        }
    }
}
