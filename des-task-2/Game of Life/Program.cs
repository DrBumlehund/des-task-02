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

        IEnumerable<int> Rg = Enumerable.Range(-1, 2);

        private void Startup()
        {
            Console.Clear();
            string input = null;
            try
            {
                Console.Write("Enter size:  ");
                input = Console.ReadLine();
                rows = Convert.ToInt32(input);
                cols = rows; //it needs to be square.
                Console.Write("Enter delay [ms]:  ");
                input = Console.ReadLine();
                sleepTimer = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Error: " + input + " could not be converted to intger \nPlease try again, using numbers");
                Console.WriteLine("--------------------------------------------------\n");
                Startup();
            }
            InitializeCell();
            setTicks();


        }


        private void setTicks()
        {
            string input = null;
            try
            {
                Console.Write("Enter ticks:  ");
                input = Console.ReadLine();
                Play(Convert.ToInt32(input));
            }
            catch (FormatException)
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Error: " + input + " could not be converted to intger \nPlease try again, using numbers");
                Console.WriteLine("--------------------------------------------------\n");
                setTicks();
            }
        }

        private void Play(int ticks)
        {
            bool playOn = true; //made to secure that when the end condition is met, the game doesn't ask for continuation.
            for (int i = 0; i < ticks; i++)
            {
                if (endCondition())
                {
                    WriteCells(cell, rows, cols);
                    System.Threading.Thread.Sleep(sleepTimer);
                    cell = Gen();
                    
                }
                else
                {
                    Console.WriteLine(i);
                    playOn = false;
                    break;
                }
            }
            if (playOn)
            {
                if (askForReplay("Continue?"))
                {
                    setTicks();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n-----------------------");
                    Console.WriteLine("|Thank you for playing|");
                    Console.WriteLine("-----------------------");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private bool askForReplay(string question)
        {

            Console.Write(question + " (Y/N)  ");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("y"))
            {
                return true;
            }
            else if (input.ToLower().Equals("n"))
            {
                return false;
            }
            else
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine("Error: input \"" + input + "\" isn't an acceptable input. \nPlease try again, using either \"Y\" or \"N\"");
                Console.WriteLine("--------------------------------------------------\n");
                askForReplay(question);
                return false;
            }
        }

        public int Neighbours(int r, int c)
        {
            return Rg.Sum(dr => Rg.Sum(dc => cell[r + dr, c + dc])) - cell[r, c];
        }

        public int Next(int r, int c)
        {
            var nbrs = Neighbours(r, c);
            if (cell[r, c] == 0 && nbrs == 3 || cell[r, c] == 1 && (nbrs == 2 || nbrs == 3))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int[,] Gen()
        {
            var nxt = new int[rows, cols];
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    nxt[r, c] = Next(r, c);
                }
            }
            return nxt;
        }

        public void WriteCells(int[,] cell, int rows, int cols)
        {
            Console.Clear();
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    Console.Write(cell[r, c] == 0 ? '-' : '*');
                    if (c == cols - 2) Console.WriteLine();
                }
            }
        }
        private void InitializeCell()
        {
            cell = new int[rows, cols];
            var rnd = new Random();
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    cell[r, c] = (int)Math.Round(rnd.NextDouble());
                }
            }
        }
        private bool endCondition()
        {
            int living = 0;
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 1; c < cols - 1; c++)
                {
                    living += cell[r, c];

                }
            }
            if (living == 0)
            {
                Console.WriteLine("\n------------");
                Console.WriteLine("|Game Over!|");
                Console.WriteLine("------------");
                if (askForReplay("Restart game?"))
                {
                    Startup();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n-----------------------");
                    Console.WriteLine("|Thank you for playing|");
                    Console.WriteLine("-----------------------");
                    System.Threading.Thread.Sleep(1000);
                }
                return false;

            }

            return true;
        }

    }
}