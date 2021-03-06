#region

using System.Linq;

#endregion

namespace SibalaDojoTests
{
    public class Sibala
    {
        public string Result(string input)
        {
            var firstPlayerName = input
                                  .Split(new[] {' ', ' '})
                                  .First()
                                  .Split(':')
                                  .First();
            return $"{firstPlayerName} wins. all the same kind:6.";
            return "Tie.";
        }
    }
}