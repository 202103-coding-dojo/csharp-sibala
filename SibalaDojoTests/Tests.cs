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
        public void to_be_done()
        {
            var result = _sibala.Result("winner:1 1 1 1  loser:1 1 1 1");
            Assert.AreEqual("Tie.",result);
        }

        [Test]
        [Ignore("")]
        public void first_player_win()
        {
            ResultShouldBe("amy wins. all the same kind:6.", "amy:6 6 6 6  lin:2 3 4 5");
        }

        [Test]
        public void second_player_win()
        {
            ResultShouldBe("lin wins. all the same kind:6.", "amy:2 3 4 5  lin:6 6 6 6");
        }

        [Test]
        public void all_the_same_kind()
        {
            ResultShouldBe("lin wins. all the same kind:6.", "amy:2 3 4 5  lin:6 6 6 6");
        }
        
        [Test]
        public void first_player_dice_1111()
        {
            
            ResultShouldBe("1111", "amy:1 1 1 1  lin:6 6 6 6");
        }

        private void ResultShouldBe(string expected, string input)
        {
            Assert.AreEqual(expected, _sibala.Result(input));
        }
    }
}