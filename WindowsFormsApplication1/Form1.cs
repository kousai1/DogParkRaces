using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        GreyHound[] GreyhoundArray = new GreyHound[4];
        Guy[] GuyArray = new Guy[3];
        Random MyRandomizer = new Random();
        
        public Form1()
        {
            InitializeComponent();
            LoadGreyHoundArray();
            LoadGuyArray();

            foreach (var dude in GuyArray)
            {
                dude.UpdateLabelsFirst();
            }

            int trackLength = pictureBoxRaceTrack.Width;
            Console.WriteLine("The length of the track is " + trackLength);
        }

        public void LoadGreyHoundArray()
        {

            GreyhoundArray[0] = new GreyHound()
            {
                MyPictureBox = pictureBoxDog1,
                StartingPosition = pictureBoxDog1.Left,
                RacetrackLength = pictureBoxRaceTrack.Width,
                Randomizer = MyRandomizer

            };

            Console.WriteLine("The length of the track for dog 1 is " + GreyhoundArray[0].RacetrackLength);
            GreyhoundArray[1] = new GreyHound()
            {
                MyPictureBox = pictureBoxDog2,
                StartingPosition = pictureBoxDog2.Left,
                RacetrackLength = pictureBoxRaceTrack.Width,
                Randomizer = MyRandomizer
            };

            Console.WriteLine("The length of the track for dog 2 is " + GreyhoundArray[1].RacetrackLength);
            GreyhoundArray[2] = new GreyHound()
            {
                MyPictureBox = pictureBoxDog3,
                StartingPosition = pictureBoxDog3.Left,
                RacetrackLength = pictureBoxRaceTrack.Width,
                Randomizer = MyRandomizer
            };

            Console.WriteLine("The length of the track for dog 3 is " + GreyhoundArray[2].RacetrackLength);
            GreyhoundArray[3] = new GreyHound()
            {
                MyPictureBox = pictureBoxDog4,
                StartingPosition = pictureBoxDog4.Left,
                RacetrackLength = pictureBoxRaceTrack.Width,
                Randomizer = MyRandomizer
            };

            Console.WriteLine("The length of the track for dog 4 is " + GreyhoundArray[3].RacetrackLength);

        }

        public void LoadGuyArray()
        {

            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                cash = 50,
                MyRadioButton = radioButtonJoe,
                MyLabel = labelJoeBets
            };

            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                cash = 75,
                MyRadioButton = radioButtonBob,
                MyLabel = labelBobBets
            };

            GuyArray[2] = new Guy()
            {
                Name = "Al",
                cash = 45,
                MyRadioButton = radioButtonAl,
                MyLabel = labelAlBets
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelBettingName.Text = "Name";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonJoe_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonJoe.Checked)
            {
                labelBettingName.Text = "Joe";
            }
        }

        private void radioButtonBob_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBob.Checked)
            {
                labelBettingName.Text = "Bob";
            }
        }

        private void radioButtonAl_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAl.Checked)
            {
                labelBettingName.Text = "Al";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButtonJoe.Checked)
            {
                GuyArray[0].MyBet = new Bet()
                {
                    Amount = (int)numericUpDownBet.Value,
                    Dog = (int)numericUpDownDog.Value,
                    Bettor = this.GuyArray[0]
                };
                GuyArray[0].UpdateLabels();
            }
            else if (radioButtonBob.Checked)
            {
                GuyArray[1].MyBet = new Bet()
                {
                    Amount = (int)numericUpDownBet.Value,
                    Dog = (int)numericUpDownDog.Value,
                    Bettor = this.GuyArray[1]
                };
                GuyArray[1].UpdateLabels();
            }
            else if (radioButtonAl.Checked)
            {
                GuyArray[2].MyBet = new Bet()
                {
                    Amount = (int)numericUpDownBet.Value,
                    Dog = (int)numericUpDownDog.Value,
                    Bettor = this.GuyArray[2]
                };
                GuyArray[2].UpdateLabels();
            }
        }

        private void buttonRace_Click(object sender, EventArgs e)
        {
            bool GameOver = false;
            char Winner;

            while (!GameOver)
            {
                foreach (var dog in GreyhoundArray)
                {
                    if (dog.Run() == false)
                    {
                        dog.Run();
                    }
                    else
                    {
                        Winner = dog.MyPictureBox.Name.ToString().Last();
                        string winners = Winner.ToString();
                        MessageBox.Show("Winner is dog # " + winners);
                        int winnest = Convert.ToInt16(Winner.ToString());
                        //int WinningDog = Convert.ToInt16(Winner);                        
                        Console.WriteLine("The winning dog is " + Winner);
                        Console.WriteLine("The winnest dog is " + winnest);
                        GameOver = true;
                        foreach (var dude in GuyArray)
                        {
                            dude.MyBet.Payout(winnest);
                            Console.WriteLine("The guy: " + dude.Name + "\n"
                                               + "Bet Amount: " + dude.MyBet.Amount + "\n"
                                               + "Dog bet On: " + dude.MyBet.Dog + "\n"
                                               + "The winner is: Dog#" + winnest);
                            int amount = dude.MyBet.Payout(winnest);
                            Console.WriteLine("This is the amount for winnings: " + amount);
                            dude.cash = dude.cash += dude.MyBet.Payout(winnest);
                            //MessageBox.Show(dude.MyBet.IsWinner((int)Winner));
                            //dude.Collect(dude.MyBet.Dog);
                            dude.UpdateLabels();
                            dude.ClearBet();
                        }

                        foreach (var pup in GreyhoundArray)
                        {
                            pup.TakeStartingPosition();
                        }
                    }
                }
            }
        }


    }
}
