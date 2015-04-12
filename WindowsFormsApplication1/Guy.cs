using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabelsFirst()
        {
            MyLabel.Text = "Has not bet.";
            MyRadioButton.Text = Name + " has $" + cash;
        }
        
        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has $" + cash;
        }

        public void ClearBet()
        {
            MyBet.Amount = 5;
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= cash)
            {
                MyBet.Amount = BetAmount;
                return true;
            }
            MessageBox.Show("Sorry didn't have enough money for the bet");
            return false;
        }

        public void Collect(int Winner)
        {
            cash = MyBet.Payout(Winner);
            MyBet = new Bet();
            UpdateLabels();
        }
    }
    
}
