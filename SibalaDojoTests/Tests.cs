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
        public void tie_with_both_no_point()
        {
            var actual = _sibala.Result("amy:1 2 3 4  lin:2 3 4 5");
            Assert.AreEqual("Tie.", actual);
        }
    }
}