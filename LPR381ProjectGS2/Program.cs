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
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            string filePath = "knapsack_input.txt";
            var model = ParseInputFile(filePath);

            var knapSolver = LPR381ProjectGS2.Domain.Algorithms.KnapSackSolver.FromLPModel(model);
            knapSolver.Solve();
            knapSolver.PrintSolution(); // <-- console output

            System.Windows.Forms.Application.Run(new Main_Form());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Main_Form());
        }
    }
}
