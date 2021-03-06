using System.Linq;

namespace SibalaDojoTests
{
    public class Sibala
    {
        public string Result(string input)
        {
            var firstPlayerName = input.Split("  ").First().Split(":").First();
            return "Tie.";
        }
    }
}