using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.Controls.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinForms.Controls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Liste());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}