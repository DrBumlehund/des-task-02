using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    class Program
    {

        static int _sleepTime = 500; //Sleep time between players scoring
        
        static void Main(string[] args)
        {
            Boolean running = true; 
            Random rnd = new Random(); 
            Player player1 = new Player();
            Player player2 = new Player();
            TennisGame game = new TennisGame(player1, player2);
            
            while (running) //main loop
            {
                if (rnd.Next(2) == 0)   //Player1 scores
                {
                    player1.IncrementPoints();
                    Console.WriteLine("Player1 scored and now has " + player1.GetPoints().ToString() + " points" );
                }
                else     //Player2 scores
                {
                    player2.IncrementPoints();
                    Console.WriteLine("Player2 scored and now has " + player2.GetPoints().ToString() + " points");
                }
                Console.WriteLine("Score is: " + game.GetScore()); // Score of the game
                
                if (GameIsWon(player1, player2))    //check if game is already won
                {
                    running = false; 
                }

                System.Threading.Thread.Sleep(_sleepTime); //Thread sleep to make it easier to follow game process in console
          }
            
        }
        /*
        Checks if the game is won 
        */
        static bool GameIsWon(Player player1, Player player2)
        {
            if (player1.GetPoints() >= 4 && Math.Abs(player1.GetPoints() - player2.GetPoints()) >= 2)   //Player1 wins
            {
                Console.ReadLine();
                return true;
            }
            else if (player2.GetPoints() >= 4 && Math.Abs(player1.GetPoints() - player2.GetPoints()) >= 2)   //Player2 wins
            {
                Console.ReadLine();
                return true;
            }
            else return false; 
        }
    }
}
