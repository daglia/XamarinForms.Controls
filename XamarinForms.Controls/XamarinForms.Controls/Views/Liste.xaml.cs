using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Model;

namespace XamarinForms.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Liste : ContentPage
    {
        public Liste()
        {
            InitializeComponent();
            LoadData();
            ListeyiDoldur();
            InitMyComponent();
        }

        private void InitMyComponent()
        {
            var moreAction = new MenuItem { Text = "More" };
            moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            moreAction.Clicked += async (sender, e) => {
                var mi = ((MenuItem)sender);
                //Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);
            };

            var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
            deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
            deleteAction.Clicked += async (sender, e) => {
                var mi = ((MenuItem)sender);
                //Debug.WriteLine("Delete Context Action clicked: " + mi.CommandParameter);
            };
            // add to the ViewCell's ContextActions property

            //ContextActions.Add(moreAction);
            //ContextActions.Add(deleteAction);

            AlbumView.ItemSelected += async (sender, e) =>
            {
                var seciliAlbum = e.SelectedItem as AlbumModel;

                var sonuc = await DisplayActionSheet($"{seciliAlbum.title} ?", "Cancel", null, "Satınal", "Detay");
                // Debug.WriteLine("Action: " + action);
                switch (sonuc)
                {
                    case "Satınal":
                        var browser = new WebView();
                        browser.Source = seciliAlbum.url;
                        var page = new ContentPage();
                        page.Content = browser;
                        browser.HorizontalOptions = LayoutOptions.FillAndExpand;
                        browser.VerticalOptions = LayoutOptions.FillAndExpand;
                        page.Title = seciliAlbum.title;
                        //Content = browser;

                        await Navigation.PushAsync(page);
                        break;
                    case "Detay":

                        break;
                    default:
                        break;
                }

            };
        }

        private void ListeyiDoldur()
        {
            AlbumView.ItemsSource = model;
        }

        List<AlbumModel> model = new List<AlbumModel>();
        private void LoadData()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://rallycoding.herokuapp.com/api/music_albums")).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<List<AlbumModel>>(responseString);
            int a = 0;
            BindingContext = model;
        }

    }
}