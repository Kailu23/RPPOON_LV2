using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class DiceRoller : ILogable
    {
        private List<Die> dice;
        private List<int> resultForEachRoll;

        public DiceRoller()
        {
            this.dice = new List<Die>();
            this.resultForEachRoll = new List<int>();
        }

        public void InsertDie(Die die)
        {
            dice.Add(die);
        }

        public void RollAllDice()
        {
            resultForEachRoll.Clear();
            foreach (Die die in dice)
            {
                resultForEachRoll.Add(die.Roll());
            }
        }

        public IList<int> GetRollingResults()
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<int>(resultForEachRoll);
        }

        public string GetStringRepresentation()
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine("Rezultati bacanja kockica:");
            for (int i = 0; i < resultForEachRoll.Count; i++)
            {
                resultBuilder.AppendLine($"Kockica {i + 1}: {resultForEachRoll[i]}");
            }
            return resultBuilder.ToString();
        }
    }
}
