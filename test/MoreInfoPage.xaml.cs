using System;
using System.Collections.Generic;
using test.Models;
using Xamarin.Forms;

namespace test
{
    public partial class MoreInfoPage : ContentPage
    {
        Monsterdatum fightMonster;

        public MoreInfoPage()
        {
            InitializeComponent();
        }

        public MoreInfoPage(MenuItem mi)
        {
            InitializeComponent();
            Monsterdatum monster = (Monsterdatum)mi.CommandParameter;
            fightMonster = monster;
            BindingContext = monster;
        }

        //clicked on fight
        async void Fight_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FightPage(fightMonster), true);
        }
    }
}
