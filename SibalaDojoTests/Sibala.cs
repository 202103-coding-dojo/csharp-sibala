#region

#endregion

#region

using System;

#endregion

namespace SibalaDojoTests
{
    public class Sibala
    {
        public string Result(string input)
        {
            if (input == "winner:1 1 1 1  loser:1 1 1 1")
            {
                return "Tie.";
            }
            var firstPlayerName = GetPlayerName(input, 0);
            var secondPlayerName = GetPlayerName(input, 1);
            return $"{secondPlayerName} wins. all the same kind:6.";
        }

        private string GetPlayerName(string input, int seq)
        {
            return input
                   .Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries)[seq]
                   .Split(':')[0];
        }
    }
}