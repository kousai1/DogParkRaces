using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;
        public Boolean isWinner = false;

        public string GetDescription()
        {
            if (Amount == 0)
            {
                return "has not bet.";
            }
            return "$" + Amount + " on Dog #" + Dog;
        }

        public int Payout(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount * 2;

            }
            else
            {
                return Amount * -1;

            }
        }

        public string IsWinner(int Winner)
        {
            if (Winner == Dog)
            {
                return Bettor.Name + " has won $" + (Amount * 2) + " from betting on Dog #" + Dog;
            }
            return Bettor.Name + " has lost $" + (Amount * -1) + " from betting on Dog #" + Dog;
        }
    }
}
