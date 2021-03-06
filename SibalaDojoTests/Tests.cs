#region

using System.Collections.Generic;
using ExpectedObjects;
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
            Assert.AreEqual("Tie.", result);
        }

        [Test]
        public void first_player_win()
        {
            ResultShouldBe("amy wins. all the same kind:6.", "amy:6 6 6 6  lin:1 1 1 1");
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
            //    ResultShouldBe("1111", "amy:1 1 1 1  lin:6 6 6 6");
            var player = _sibala.GetPlayer("amy:1 1 1 1");
            Assert.AreEqual("amy", player.Name);
            var expected = new List<int>() {1, 1, 1, 1};
            expected.ToExpectedObject().ShouldEqual(player.Dices);
        }

        [Test]
        public void when_all_the_same_kind_and_both_equal()
        {
            ResultShouldBe("Tie.", "amy:6 6 6 6  lin:6 6 6 6");
        }

        [Test]
        public void all_the_same_kind_and_no_point()
        {
            ResultShouldBe("amy wins. all the same kind:6.", "amy:6 6 6 6  lin:1 2 3 4");
        }

        [Test]
        [Ignore("next")]
        public void no_point_and_all_the_same_kind()
        {
            ResultShouldBe("lin wins. all the same kind:2.", "amy:6 6 6 3  lin:2 2 2 2");
        }
        
        [Test]
        public void all_the_same_kind_and_no_point_secondPlayer_win()
        {
            ResultShouldBe("lin wins. all the same kind:2.", "amy:6 6 6 3  lin:2 2 2 2");
        }

        
        private void ResultShouldBe(string expected, string input)
        {
            Assert.AreEqual(expected, _sibala.Result(input));
        }
    }
}