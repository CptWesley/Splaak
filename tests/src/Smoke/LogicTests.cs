using Splaak.Core;
using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Smoke
{
    public class LogicTests
    {
        [Fact]
        public void IfTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(if true 42 20)"), new IntV(42));
        }

        [Fact]
        public void IfFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(if false 32 9)"), new IntV(9));
        }

        [Fact]
        public void IfNestedTrueConditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(if (or false true) 22 7)"), new IntV(22));
        }

        [Fact]
        public void IfNestedFalseConditionTest()
        {
            Assert.Equal(SInterpreter.Interpret("(if (and false true) 22 7)"), new IntV(7));
        }

        [Fact]
        public void IfNestedResultTest()
        {
            Assert.Equal(SInterpreter.Interpret("(if true (+ 3 6) 7)"), new IntV(9));
        }

        [Fact]
        public void AndTrueTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(and true true)"), new BoolV(true));
        }

        [Fact]
        public void AndFalseTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(and false true)"), new BoolV(false));
        }

        [Fact]
        public void AndTrueFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(and true false)"), new BoolV(false));
        }

        [Fact]
        public void AndFalseFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(and false false)"), new BoolV(false));
        }

        [Fact]
        public void OrTrueTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(or true true)"), new BoolV(true));
        }

        [Fact]
        public void OrFalseTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(or false true)"), new BoolV(true));
        }

        [Fact]
        public void OrTrueFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(or true false)"), new BoolV(true));
        }

        [Fact]
        public void OrFalseFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(or false false)"), new BoolV(false));
        }

        [Fact]
        public void NotFalseTest()
        {
            Assert.Equal(SInterpreter.Interpret("(not false)"), new BoolV(true));
        }

        [Fact]
        public void NotTrueTest()
        {
            Assert.Equal(SInterpreter.Interpret("(not true)"), new BoolV(false));
        }
    }
}
