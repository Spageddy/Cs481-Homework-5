using System;
using System.Collections.Generic;
using test.Models;
using Xamarin.Forms;

namespace test
{
    public partial class FightPage : ContentPage
    {

        double UHealth;
        double MHealth;

        Monsterdatum monsterInfo;

        public FightPage()
        {
            InitializeComponent();
        }

        public FightPage(Monsterdatum monster)
        {
            InitializeComponent();
            BindingContext = monster;
            MHealth = monster.Health;
            monsterInfo = monster;
            UHealth = 500;
            UpdateHealthlabels();
        }
        //update health
        public void UpdateHealthlabels()
        {
            UserHealthLabel.Text = UHealth.ToString();
            MonsterHealthLabel.Text = MHealth.ToString();
        }
        //battle clicked 
        void Battle_Clicked(object sender, System.EventArgs e)
        {
            //pick a random number for monster and user
            Random random = new Random();
            double m = random.Next(1, 10);
            double u = random.Next(1, 10);
            double p;

            //if monster number is larger
            if (m >= u)
            {
                UHealth -= m * 10;
                //if user health reachs 0
                if (UHealth <= 0)
                {
                    LostLabel.IsVisible = true;
                    ReturnButton.IsVisible = true;
                    BattleButton.IsVisible = false;
                }
                p = UHealth / 500;
                UserHealth.ProgressTo(p, 250, Easing.Linear);
                UpdateHealthlabels();
            }
            //if users number is larger
            else if (u > m)
            {
                MHealth -= u * 10;
                //if monster health reachs 0
                if (MHealth <= 0)
                {
                    WonLabel.IsVisible = true;
                    ReturnButton.IsVisible = true;
                    BattleButton.IsVisible = false;
                }
                p = MHealth / monsterInfo.Health;
                MonsterHealth.ProgressTo(p, 250, Easing.Linear);
                UpdateHealthlabels();
            }
        }
        //clicked on back to list
        void Return_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

    }
}
