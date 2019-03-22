using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinForms.Controls.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KayitForm : ContentPage
    {
        public KayitForm()
        {
            InitializeComponent();
            txtAd.ReturnCommand = new Command(() => txtSoyad.Focus());
            txtSoyad.ReturnCommand = new Command(() => txtEmail.Focus());
            txtEmail.ReturnCommand = new Command(() => txtPass.Focus());

            MessagingCenter.Subscribe<KayitForm, string>(this, "Hi", (sender, arg) => {
                DisplayAlert("Message Received", "arg=" + arg, "OK");
            });
        }
    }
}