using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LinearProgrammingSolver.LPInputParser;

namespace LPR381ProjectGS2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string filePath = "knapsack_input.txt";
            var model = ParseInputFile(filePath);

            var knapSolver = LPR381ProjectGS2.KnapSackSolver.FromLPModel(model);
            knapSolver.Solve();
            knapSolver.PrintSolution(); // <-- console output

            Application.Run(new Main_Form());
        }
    }
}
