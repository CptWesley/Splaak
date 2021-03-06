﻿using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;
using Splaak.Core.Values;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.CoreSyntax.BinOps
{
    public class DivCTests
    {
        private static IntC _1 = new IntC(10);
        private static IntC _2 = new IntC(2);
        private DivC _obj = new DivC(_1, _2);

        [Fact]
        public void ConstructorTest()
        {
            Assert.Equal(_obj.Argument1, _1);
            Assert.Equal(_obj.Argument2, _2);
        }

        [Fact]
        public void EqualsEqualTest()
        {
            Assert.True(_obj.Equals(new DivC(_1, _2)));
        }

        [Fact]
        public void EqualsNullTest()
        {
            Assert.False(_obj.Equals(null));
        }

        [Fact]
        public void EqualsNotEqualValueTest()
        {
            Assert.False(_obj.Equals(new DivC(_1, _1)));
        }

        [Fact]
        public void EqualsNotEqualTypeTest()
        {
            Assert.False(_obj.Equals(new BoolC(false)));
        }

        [Fact]
        public void HashCodeEqualTest()
        {
            Assert.Equal(_obj.GetHashCode(), new DivC(_1, _2).GetHashCode());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal(_obj.ToString(), "DivC(" + _1 + ", " + _2 +")");
        }

        [Fact]
        public void InterpretIntIntTest()
        {
            Assert.Equal(new DivC(new IntC(10), new IntC(3)).Interpret(), new IntV(3));
        }

        [Fact]
        public void InterpretFloatFloatTest()
        {
            Assert.Equal(new DivC(new FloatC(10), new FloatC(5)).Interpret(), new FloatV(2));
        }

        [Fact]
        public void InterpretFloatIntTest()
        {
            Assert.Equal(new DivC(new FloatC(10), new IntC(5)).Interpret(), new FloatV(2));
        }

        [Fact]
        public void InterpretIntFloatTest()
        {
            Assert.Equal(new DivC(new IntC(10), new FloatC(5)).Interpret(), new FloatV(2));
        }

        [Fact]
        public void InterpretLeftNaNExceptionTest()
        {
            Assert.Throws<InterpretException>(() => new DivC(new BoolC(true), new FloatC(5)).Interpret());
        }

        [Fact]
        public void InterpretRightNaNExceptionTest()
        {
            Assert.Throws<InterpretException>(() => new DivC(new FloatC(5), new BoolC(true)).Interpret());
        }
    }
}
