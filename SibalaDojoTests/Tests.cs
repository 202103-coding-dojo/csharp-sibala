#region

using NUnit.Framework;

#endregion

namespace SibalaDojoTests
{
    [TestFixture]
    public class SibalaTests
    {
        private Sibala _sibala;

        [SetUp]
        public void SetUp()
        {
            _sibala = new Sibala();
        }

        [Test]
        [Ignore("Ignore first")]
        public void tie_with_both_no_point()
        {
            ResultShouldBe("Tie.", "amy:1 2 3 4  lin:2 3 4 5");
        }

        [Test]
        public void first_player_win()
        {
            ResultShouldBe("amy wins. all the same kind:6.", "amy:6 6 6 6  lin:2 3 4 5");
        }

        [Test]
        public void second_player_win()
        {
            ResultShouldBe("lin wins. all the same kind:6.", "amy:2 3 4 5  lin:6 6 6 6");
        }

        private void ResultShouldBe(string expected, string input)
        {
            Assert.AreEqual(expected, _sibala.Result(input));
        }
    }
}