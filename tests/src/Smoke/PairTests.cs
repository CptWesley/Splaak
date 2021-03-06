﻿using Splaak.Core;
using Splaak.Core.Values.Types;
using Xunit;

namespace Splaak.Tests.Smoke
{
    public class PairTests
    {
        [Fact]
        public void PairTest()
        {
            Assert.Equal(SInterpreter.Interpret("(pair 3 4)").Force(), new PairV(new IntV(3), new IntV(4)));
        }

        [Fact]
        public void FirstTest()
        {
            Assert.Equal(SInterpreter.Interpret("(first (pair 3 4))").Force(), new IntV(3));
        }

        [Fact]
        public void SecondTest()
        {
            Assert.Equal(SInterpreter.Interpret("(second (pair 3 4))").Force(), new IntV(4));
        }

        [Fact]
        public void NestedTest()
        {
            Assert.Equal(SInterpreter.Interpret("(first (second (second (second (pair 0 (pair 1 (pair 2 (pair 3 4))))))))").Force(), new IntV(3));
        }

        [Fact]
        public void TupleTest()
        {
            Assert.Equal(SInterpreter.Interpret("(tuple 1 2 3 4 5)").Force(),
                new PairV(new IntV(1),
                    new PairV(new IntV(2),
                        new PairV(new IntV(3), 
                            new PairV(new IntV(4), new IntV(5))))));
        }
    }
}
