using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class TennisGame
    {
        private Player _player1;
        private Player _player2; 

        public TennisGame(Player player1, Player player2)
        {
            this._player1 = player1;
            this._player2 = player2;
        }

        public String GetScore()
        {
            if (_player1.GetPoints() >= 3 && _player2.GetPoints() >= 3 && Math.Abs(_player1.GetPoints() - _player2.GetPoints()) < 2)
            {
                if (_player1.GetPoints() == _player2.GetPoints())
                {
                    return "deuce";
                }
                else if (_player1.GetPoints() > _player2.GetPoints())
                {
                    return "Advantage player1";
                }
                else return "Advantage player2";
               
            }
            if (_player1.GetPoints() < 4 && _player2.GetPoints() < 4)
            {
                return TranslateScore(_player1.GetPoints()) + ":" + TranslateScore(_player2.GetPoints());
            }
            if (_player1.GetPoints() >= 4)
            {
                return TranslateScore(_player1.GetPoints()) + " player1";
            }

            return TranslateScore(_player2.GetPoints())+" player2";
        }

        private String TranslateScore(int point)
        {
            switch (point)
            {
                case 0:
                    return "love";
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    return "game";
            }
        }
        
    }
}
