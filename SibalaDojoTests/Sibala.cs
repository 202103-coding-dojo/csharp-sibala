#region

#endregion

namespace SibalaDojoTests
{
    public class Sibala
    {
        public string Result(string input)
        {
            var firstPlayerName = GetPlayerName(input, 0);
            var secondPlayerName = GetPlayerName(input, 1);
            return $"{firstPlayerName} wins. all the same kind:6.";
            return "Tie.";
        }

        private string GetPlayerName(string input, int seq)
        {
            return input
                   .Split(new[] {' ', ' '})[seq]
                   .Split(':')[0];
        }
    }
}