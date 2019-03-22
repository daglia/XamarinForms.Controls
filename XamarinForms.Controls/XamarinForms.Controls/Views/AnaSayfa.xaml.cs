using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Model;

namespace XamarinForms.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnaSayfa : ContentPage
    {
        public AnaSayfa()
        {
            InitializeComponent();
            InitMyComponent();
            BindingContext = new MockData();
        }


        private void InitMyComponent()
        {
            var red = Color.Red;
            var orange = Color.FromHex("FF6A00");
            var yellow = Color.FromHsla(0.167, 1.0, 0.5, 1.0);
            var green = Color.FromRgb(38, 127, 0);
            var blue = Color.FromRgba(0, 38, 255, 255);
            var indigo = Color.FromRgb(0, 72, 255);
            var violet = Color.FromHsla(0.82, 1, 0.25, 1);
            var colors = new List<Color> { red, orange, yellow, green, blue, indigo, violet };

            //btnDondur.Clicked += BtnDondur_Clicked;
            //btnDondur.Clicked += (sender, e) =>
            //{
            //    angle *= 1.15;
            //    lblMesaj.RotateTo(angle, 1000);
            //};

            btnDondur.Clicked += async (sender, e) =>
            {
                var rnd = new Random();
                angle *= 1.15;
                lblMesaj.TextColor = colors[rnd.Next(0, colors.Count)];
                lblMesaj.RotateTo(angle, 1000);
                lblMesaj.FontSize = rnd.Next(10, 40);
                Button btn = (Button)sender;
                btn.BackgroundColor = colors[rnd.Next(0, colors.Count)];
                var tarih = dtpTarih.Date;
                var span = DateTime.Now - tarih;
                lblMesaj.Text = $"Fark {span.TotalDays} gündür";

                lblMesaj.Text = $"{dtpSaat.Time}";

            };
            //cmbRenkler.ItemsSource = colors;
            //cmbRenkler.SelectedIndexChanged += async (sender, e) =>
            // {
            //     if (cmbRenkler.SelectedItem == null) return;
            //     string seciliRenk = cmbRenkler.SelectedItem.ToString();
            //     await DisplayAlert("Renk Seçme İşlemi", $"Seçtiğiniz Renk: {seciliRenk}", "Tamam", "İptal");
            // };

            //cmbKisiler.ItemsSource = new MockData().Kullanicilar;
            //cmbKisiler.ItemsSource = Kisiler;
            cmbKisiler.SetBinding(Picker.ItemsSourceProperty, "Kullanicilar");
            //cmbKisiler.ItemDisplayBinding = new Binding("Ad");
            cmbKisiler.SelectedIndexChanged += (sender, e) =>
            {
                if (cmbKisiler.SelectedItem == null) return;
                var seciliKisi = cmbKisiler.SelectedItem as Kullanici;
                lblMesaj.Text = $"{seciliKisi.Ad} {seciliKisi.Soyad} - {seciliKisi.Email}";
            };


        }

        private void BtnDondur_Clicked(object sender, EventArgs e)
        {
            angle *= 1.15;
            lblMesaj.RotateTo(angle, 1000);
        }

        private static double angle = 25;
        public async void OnButtonClicked(object sender, EventArgs e)
        {
            angle *= 1.15;
            await lblMesaj.RotateTo(angle, 1000);
        }

    }
}