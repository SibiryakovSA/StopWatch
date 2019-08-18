using Analog_watch.Models;
using Analog_watch.Presenters;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Analog_watch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            StopWhatch stopWhatch = new StopWhatch();
            Presenter presenter = new Presenter(stopWhatch);

            MainPage = presenter.GetPage;
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
