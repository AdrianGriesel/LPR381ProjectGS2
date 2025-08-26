using LinearProgrammingSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LPR381ProjectGS2.Domain.Algorithms
{
    public class KnapSackSolver 
    {
        private List<string> iterationLog = new List<string>();

        public IReadOnlyList<string> IterationLog => iterationLog;
        public static KnapSackSolver FromLPModel(LPInputParser.LPModel model)
        {
            if (model.Constraints.Count == 0)
                throw new ArgumentException("Knapsack model requires at least one constraint.");

            if (!model.SignRestrictions.TrueForAll(t => t == LPInputParser.VariableType.Binary))
                throw new ArgumentException("Knapsack solver requires all variables to be binary.");



            var capacityConstraint = model.Constraints[0];

            var items = new List<Item>();
            for (int i = 0; i < model.NumberOfVariables; i++)
            {
                items.Add(new Item
                {
                    Index = i + 1,
                    Value = model.ObjectiveCoefficients[i],
                    Weight = capacityConstraint.Coefficients[i]
                });
            }
            double capacity = capacityConstraint.RightHandSide;
            return new KnapSackSolver(items, capacity);
        }
        public class Item
        {
            public int Index { get; set; }
            public double Value{ get; set; }
            public double Weight {  get; set; }
            public double Ratio => Value / Weight;
        }

        private class Node
        {
            public int Level { get; set; }
            public double Value { get; set; }
            public double Weight { get; set; }
            public double Bound {  get; set; }
            public List<int> ItemsTaken { get; set; } = new List<int>();

        }

        private List<Item> items;
        private double capacity;
        private double bestValue;
        private List<int> bestItems;

        public KnapSackSolver(List<Item> _items, double _capacity)
        {
            this.items = _items;
            this.capacity = _capacity;
            this.bestValue = 0;
            this.bestItems = new List<int>();
        }

        public void Solve()
        {
            items.Sort((a, b) => b.Ratio.CompareTo(a.Ratio));
            Queue<Node> queue = new Queue<Node>();


            Node root = new Node { Level = -1, Value = 0, Weight = 0 };
            root.Bound = CalculateBound(root);
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node current = queue.Dequeue();

                iterationLog.Add($"Level {current.Level}, "+
                    $"Value = {current.Value}, "+
                    $"Weight={current.Level}, "+
                    $"Bound={current.Bound}, "+
                    $"Items={{{string.Join(", ", current.ItemsTaken)}}}");

                if (current.Bound <= bestValue || current.Level == items.Count - 1)
                    continue;
                int nextLevel = current.Level + 1;
                Node include = new Node
                {
                    Level = nextLevel,
                    Value = current.Value + items[nextLevel].Value,
                    Weight = current.Weight + items[nextLevel].Weight,
                    ItemsTaken = new List<int>(current.ItemsTaken)
                };
                include.ItemsTaken.Add(items[nextLevel].Index);
                iterationLog.Add($"➡ Include x{items[nextLevel].Index}: " +
                 $"Value={include.Value}, Weight={include.Weight}, Bound={include.Bound:F2}");
                if (include.Weight <= capacity && include.Value > bestValue)
                {
                    bestValue = include.Value;
                    bestItems = include.ItemsTaken;
                }

                include.Bound = CalculateBound(include);
                if (include.Bound > bestValue)
                    queue.Enqueue(include);
                Node exclude = new Node
                {
                    Level = nextLevel,
                    Value = current.Value,
                    Weight = current.Weight,
                    ItemsTaken = new List<int>(current.ItemsTaken)
                };

                iterationLog.Add($"✖ Exclude x{items[nextLevel].Index}: " +
                 $"Value={exclude.Value}, Weight={exclude.Weight}, Bound={exclude.Bound:F2}");
                exclude.Bound = CalculateBound(exclude);
                if (exclude.Bound > bestValue)

                    queue.Enqueue(exclude);
            }
        }

        private double CalculateBound(Node node)
        {
            if (node.Weight >= capacity) return 0;

            double bound = node.Value;
            double totalWeight = node.Weight;

            for (int i = node.Level + 1; i < items.Count; i++)
            {
                if (totalWeight + items[i].Weight <= capacity)
                {
                    totalWeight += items[i].Weight;
                    bound += items[i].Value;
                }
                else
                {
                    double remain = capacity - totalWeight;
                    bound += items[i].Value * (remain / items[i].Weight);
                    break;
                }
            }
            return bound;
        }

        public void PrintSolution()
        {
            Console.WriteLine("Best Vallue: " + bestValue);
            Console.WriteLine("Items Taken: " + string.Join(", ", bestItems));
        }

        public (double Value, List<int> Items) GetSolution()
        {
            return (bestValue, bestItems);
        }
    }
}
