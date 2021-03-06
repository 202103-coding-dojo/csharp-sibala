#region

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace SibalaDojoTests
{
    public class Sibala
    {
        public Player GetPlayer(string input)
        {
            var strings = input.Split(':');
            return new Player()
                   {
                       Name = strings[0],
                       Dices = strings[1].Split(' ').Select(x => int.Parse(x)).ToList()
                   };
        }

        public string Result(string input)
        {
            var firstPlayer = GetPlayer(input
                                            .Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries)[0]);
            var secondPlayer = GetPlayer(input
                                             .Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries)[1]);
            var winner = firstPlayer.Dices.Max() > secondPlayer.Dices.Max() ? firstPlayer : secondPlayer;
            if (secondPlayer.Dices.Distinct().Count() == 4)
            {
                return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
            }

            if (firstPlayer.Dices.Max() == secondPlayer.Dices.Max())
            {
                return "Tie.";
            }

            return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
        }

        private string GetPlayerName(string input, int seq)
        {
            return input
                   .Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries)[seq]
                   .Split(':')[0];
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public List<int> Dices { get; set; }
        public CategoryType CategoryType { get; set; }
    }

    public enum CategoryType
    {
        NoPoints,
        AllTheSameKind
    }
}