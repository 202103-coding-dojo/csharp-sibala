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
            var firstPlayerGroup = firstPlayer.Dices.GroupBy(m => m).ToDictionary(s => s.Key, s => s.Count());

            // GetCategoryType(firstPlayerGroup, firstPlayer);
            secondPlayer.GetCategoryType();
            firstPlayer.GetCategoryType();

            var winner = firstPlayer.CategoryType > secondPlayer.CategoryType ? firstPlayer : secondPlayer;

            // return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";

            if (firstPlayerGroup.Count() == 4)
            {
                return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
            }

            if (firstPlayer.CategoryType == secondPlayer.CategoryType)
            {
                if (firstPlayer.Dices.Max() > secondPlayer.Dices.Max())
                {
                    winner = firstPlayer;
                    return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
                }
                else if (firstPlayer.Dices.Max() < secondPlayer.Dices.Max())
                {
                    winner = secondPlayer;
                    return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
                }

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

        public void GetCategoryType()
        {
            Dictionary<int, int> secondPlayerGroup =
                Dices.GroupBy(m => m).ToDictionary(s => s.Key, s => s.Count());
            if (secondPlayerGroup.Count() == 4)
            {
                CategoryType = CategoryType.NoPoints;
            }
            else if (secondPlayerGroup.Count() == 1)
            {
                CategoryType = CategoryType.AllTheSameKind;
            }
        }
    }

    public enum CategoryType
    {
        NoPoints,
        AllTheSameKind
    }
}