using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Game_of_Life
{
    class Program
    {
        private int rows, cols, sleepTimer;
        int[,] cell;
        static void Main()
        {
 
            Program gol = new Program();
 
            gol.Startup();
 
           
           
        }
 
       
 
        static IEnumerable<int> Rg = Enumerable.Range(-1, 3);
 
        private void Startup()
        {
            try
            {
                Console.Write("Enter size:  ");
                rows = Convert.ToInt32(Console.ReadLine());
                cols = rows;
                Console.Write("Enter delay [ms]:  ");
                sleepTimer = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers in integers");
            }
 
            cell = new int[rows, cols];
            var rnd = new Random();
            Do(cell, rows, cols, (r, c) => { cell[r, c] = (int)Math.Round(rnd.NextDouble()); });
 
            setTicks();
 
 
        }
 
        private void setTicks()
        {
            Console.Write("Enter ticks:  ");
            Play(Convert.ToInt32(Console.ReadLine()));
        }
 
        private void Play(int ticks)
        {
            for (int i = 0; i < ticks; i++)
            {
                WriteCells(cell, rows, cols);
                System.Threading.Thread.Sleep(sleepTimer);
               
                cell = Gen(cell, rows, cols);
            }
            Console.WriteLine("Continue? (Y/N)");
            if (Console.ReadLine().ToLower().Equals("y")){
                setTicks();
 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you for playing");
                System.Threading.Thread.Sleep(1000);
            }
 
        }
 
        public int Nbrs(int[,] cell, int r, int c)
        {
            return Rg.Sum(dr => Rg.Sum(dc => cell[r + dr, c + dc]));
        }
 
        public int Next(int[,] cell, int r, int c)
        {
            var neighbours = Nbrs(cell, r, c) - cell[r, c];
			if (cell[r, c] == 0 && nbrs == 3 ){
				return 1;
			}else if (cell[r, c] == 1 && (nbrs == 2 || nbrs == 3)){
				return 1;
			}else{
				return 0;
			}
        }
 
        public void Do(int[,] cell, int rows, int cols, Action<int, int> a)
        {
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    a(r, c);
                }
            }
        }
 
        public int[,] Gen(int[,] cell, int rows, int cols)
        {
            var nxt = new int[rows, cols];
            Do(cell, rows, cols, (r, c) => { nxt[r, c] = Next(cell, r, c); });
            return nxt;
        }
 
        public void WriteCells(int[,] cell, int rows, int cols)
        {
            Console.Clear();
            Do(cell, rows, cols, (r, c) =>
            {
                Console.Write(cell[r, c] == 0 ? '-' : '*');
                if (c == cols - 2) Console.WriteLine();
            });
        }
    }
}