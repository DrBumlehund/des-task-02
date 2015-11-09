using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class Player
    {
        private int _points { get; set; }
        private String _runningScore;

        public Player()
        {
            this._points = 0; 
        }

        public void IncrementPoints()
        {
            this._points++; 
        }

        public int GetPoints()
        {
            return this._points;
        }


    }
}
