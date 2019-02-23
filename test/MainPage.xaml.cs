using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using test.Models;
using Xamarin.Forms;

namespace test
{

 public partial class MainPage : ContentPage
    {
        Mon mondatafromjson = new Mon();

        public MainPage()
        {
            InitializeComponent();
            ReadInJsonFile();
        }

        //get data from json file
        private void ReadInJsonFile()
        {
            var fileName = "test.monsters.json";


            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(fileName);


            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonAsString = reader.ReadToEnd();
                mondatafromjson = JsonConvert.DeserializeObject<Mon>(jsonAsString);
            }

            WeatherListView.ItemsSource = new ObservableCollection<Monsterdatum>(mondatafromjson.Monsterdata);

        }
        //clicked on more
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            await Navigation.PushAsync(new MoreInfoPage(mi), true);
        }
    }
}
