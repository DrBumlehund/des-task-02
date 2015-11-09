using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Program
    {
        static void Main()
        {
            var rows = 10; // Including a 1-cell border o'death.
            var cols = 10;
            var rnd = new Random();
            var cell = new int[rows, cols];
            Do(cell, rows, cols, (r, c) => { cell[r, c] = (int)Math.Round(rnd.NextDouble()); });
            while (true)
            {
                WriteCells(cell, rows, cols);
                Console.WriteLine("--------");
                Console.ReadLine();
                cell = Gen(cell, rows, cols);
            }
        }

        static IEnumerable<int> Rg = Enumerable.Range(-1, 3);

        static int Nbrs(int[,] cell, int r, int c)
        {
            return Rg.Sum(dr => Rg.Sum(dc => cell[r + dr, c + dc]));
        }

        static int Next(int[,] cell, int r, int c)
        {
            var nbrs = Nbrs(cell, r, c) - cell[r, c];
            return (cell[r, c] == 0 && nbrs == 3 || cell[r, c] == 1 && (nbrs == 2 || nbrs == 3)) ? 1 : 0;
        }

        static void Do(int[,] cell, int rows, int cols, Action<int, int> a)
        {
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    a(r, c);
                }
            }
        }

        static int[,] Gen(int[,] cell, int rows, int cols)
        {
            var nxt = new int[rows, cols];
            Do(cell, rows, cols, (r, c) => { nxt[r, c] = Next(cell, r, c); });
            return nxt;
        }

        static void WriteCells(int[,] cell, int rows, int cols)
        {
            Do(cell, rows, cols, (r, c) => {
                Console.Write(cell[r, c] == 0 ? ' ' : '*');
                if (c == cols - 2) Console.WriteLine();
            });
        }
    }
}
