using Xunit;
using Splaak.Core.Reader;
using Splaak.Core.Reader.Expressions;

namespace Splaak.Tests.Reader
{
    public class SReaderTests
    {
        [Fact]
        public void IntTest()
        {
            Assert.Equal(SReader.Read("5"), new SInt(5));
        }

        [Fact]
        public void FloatTest()
        {
            Assert.Equal(SReader.Read("3.0"), new SFloat(3));
        }

        [Fact]
        public void SymbolTest()
        {
            Assert.Equal(SReader.Read("bla"), new SSym("bla"));
        }

        [Fact]
        public void ListEmptyTest()
        {
            Assert.Equal(SReader.Read("()"), new SList(new ISExpression[0]));
        }

        [Fact]
        public void ListSingleTest()
        {
            Assert.Equal(SReader.Read("(5)"), new SList(new SInt(5)));
        }

        [Fact]
        public void ListMultipleTest()
        {
            Assert.Equal(SReader.Read("(5 true)"), new SList(new SInt(5), new SSym("true")));
        }

        [Fact]
        public void ListMultipleExtraSpacesTest()
        {
            Assert.Equal(SReader.Read("(   5    true  )"), new SList(new SInt(5), new SSym("true")));
        }

        [Fact]
        public void ListMultipleExtraExtraSpacesTest()
        {
            Assert.Equal(SReader.Read("    (  if true  5    2  )    "), new SList(new ISExpression[] { new SSym("if"), new SSym("true"), new SInt(5), new SInt(2) }));
        }

        [Fact]
        public void BracketMismatchOpenTest()
        {
            Assert.Throws<ReaderException>(() => SReader.Read("("));
        }

        [Fact]
        public void BracketMismatchCloseTest()
        {
            Assert.Throws<ReaderException>(() => SReader.Read(")"));
        }

        [Fact]
        public void BracketMismatchContentOpenTest()
        {
            Assert.Throws<ReaderException>(() => SReader.Read("(if true 5 0"));
        }

        [Fact]
        public void BracketMismatchContentCloseTest()
        {
            Assert.Throws<ReaderException>(() => SReader.Read("22    )"));
        }
    }
}
