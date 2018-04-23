using Splaak.Core.Values;
using Xunit;

namespace Splaak.Tests.Values
{
    public class EnvironmentTests
    {
        [Fact]
        public void MutabilityTest()
        {
            Environment env1 = new Environment();
            Environment env2 = env1.Add("bla", new IntV(0));

            Assert.NotSame(env1, env2);
            Assert.Throws<InterpretException>(() => env1.Lookup("bla"));
            Assert.Equal(env2.Lookup("bla"), new IntV(0));
        }

        [Fact]
        public void UpdateTest()
        {
            Environment env1 = new Environment().Add("f1", new BoolV(true));
            Environment env2 = env1.Add("f2", new IntV(0));

            env2.Update("f1", new BoolV(false));

            Assert.Equal(env1.Lookup("f1"), new BoolV(false));
            Assert.Equal(env2.Lookup("f1"), new BoolV(false));
        }
    }
}
