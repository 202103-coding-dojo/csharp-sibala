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
            var firstPlayer = GetPlayer(ParsePlayerData(input)[0]);
            var secondPlayer = GetPlayer(ParsePlayerData(input)[1]);

            secondPlayer.SetCategoryType();
            firstPlayer.SetCategoryType();

            var winner = firstPlayer.CategoryType > secondPlayer.CategoryType ? firstPlayer : secondPlayer;

            if (IsSameCategory(firstPlayer, secondPlayer))
            {
                if (firstPlayer.Dices.Max() == secondPlayer.Dices.Max())
                {
                    return "Tie.";
                }

                winner = firstPlayer.Dices.Max() > secondPlayer.Dices.Max() ? firstPlayer : secondPlayer;
            }

            return $"{winner.Name} wins. all the same kind:{winner.Dices.Max()}.";
        }

        private static bool IsSameCategory(Player firstPlayer, Player secondPlayer)
        {
            return firstPlayer.CategoryType == secondPlayer.CategoryType;
        }

        private static string[] ParsePlayerData(string input)
        {
            return input
                .Split(new string[] {"  "}, StringSplitOptions.RemoveEmptyEntries);
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

        public void SetCategoryType()
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
            else if (secondPlayerGroup.Count() == 3)
            {
                CategoryType = CategoryType.NormalPoints;
            }
        }
    }

    public enum CategoryType
    {
        NoPoints,
        AllTheSameKind,
        NormalPoints
    }
}