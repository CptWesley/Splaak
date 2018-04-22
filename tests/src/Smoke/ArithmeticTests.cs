using Splaak.Core;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Smoke
{
    public class ArithmeticTests
    {
        [Fact]
        public void IntegerIntegerAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ 3 4)"), new IntV(7));
        }

        [Fact]
        public void IntegerFloatAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ 3 4.5)"), new FloatV(7.5f));
        }

        [Fact]
        public void FloatIntegerAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ 7.0 2)"), new FloatV(9));
        }

        [Fact]
        public void FloatFloatAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ 7.5 5.5)"), new FloatV(13));
        }

        [Fact]
        public void LeftNestedAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ (+ 2 1) 4)"), new IntV(7));
        }

        [Fact]
        public void RightNestedAdditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(+ 2 (+ 4 5))"), new IntV(11));
        }

        [Fact]
        public void IntegerIntegerSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- 3 4)"), new IntV(-1));
        }

        [Fact]
        public void IntegerFloatSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- 3 4.5)"), new FloatV(-1.5f));
        }

        [Fact]
        public void FloatIntegerSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- 7.0 2)"), new FloatV(5));
        }

        [Fact]
        public void FloatFloatSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- 7.5 5.5)"), new FloatV(2));
        }

        [Fact]
        public void LeftNestedSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- (+ 2 1) 4)"), new IntV(-1));
        }

        [Fact]
        public void RightNestedSubtractionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(- 2 (+ 4 5))"), new IntV(-7));
        }

        [Fact]
        public void IntegerIntegerMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* 3 4)"), new IntV(12));
        }

        [Fact]
        public void IntegerFloatMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* 3 4.5)"), new FloatV(13.5f));
        }

        [Fact]
        public void FloatIntegerMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* 7.0 2)"), new FloatV(14));
        }

        [Fact]
        public void FloatFloatMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* 3.0 4.0)"), new FloatV(12));
        }

        [Fact]
        public void LeftNestedMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* (+ 2 1) 4)"), new IntV(12));
        }

        [Fact]
        public void RightNestedMultiplicationTest()
        {
            Assert.Equal(SInterpreter.Interpret("(* 2 (+ 4 5))"), new IntV(18));
        }

        [Fact]
        public void IntegerIntegerDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ 10 3)"), new IntV(3));
        }

        [Fact]
        public void IntegerFloatDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ 9 4.5)"), new FloatV(2));
        }

        [Fact]
        public void FloatIntegerDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ 7.0 2)"), new FloatV(3.5f));
        }

        [Fact]
        public void FloatFloatDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ 40.0 4.0)"), new FloatV(10));
        }

        [Fact]
        public void LeftNestedDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ (+ 9 1) 2)"), new IntV(5));
        }

        [Fact]
        public void RightNestedDivisionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(/ 20 (* 5 2))"), new IntV(2));
        }
    }
}
