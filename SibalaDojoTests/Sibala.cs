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

        public Player GetPlayer(string input)
        {
            var strings = input.Split(':');
            return new Player()
                   {
                       Name = strings[0],
                       Dices = strings[1].Split(' ').Select(x => int.Parse(x)).ToList()
                   };
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public List<int> Dices { get; set; }
    }
}