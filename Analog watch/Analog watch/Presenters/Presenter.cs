using Analog_watch.Models;
using System;
using Xamarin.Forms;

namespace Analog_watch.Presenters
{
    class Presenter : IObserver
    {
        StopWhatch stopWhatch;
        MainPage mainPage;

        public Page GetPage
        {
            get
            {
                return mainPage;
            }
        }


        private void GetStart_Clicked(object sender, EventArgs e)
        {
            mainPage.GetStopButton.IsEnabled = true;
            mainPage.GetStopButton.Text = "Пауза";
            stopWhatch.StartTimer();
        }

        private void GetStopButton_Clicked(object sender, EventArgs e)
        {
            if (mainPage.GetStopButton.Text == "Пауза")
            {
                mainPage.GetStopButton.Text = "Сбросить";
                stopWhatch.PauseTimer();

            }
            else if (mainPage.GetStopButton.Text == "Сбросить")
            {
                stopWhatch.StopTimer();
                SetTimeLable(0);
                mainPage.GetStopButton.IsEnabled = false;
                mainPage.GetClockSecondsHand.Rotation = 0;
                mainPage.GetStopButton.Text = "Пауза";
            }
        }

        public void Update()
        {
            mainPage.GetClockSecondsHand.Rotation += 6;
            SetTimeLable(stopWhatch.GetSecondsHasPassed);
        }

        public void SetTimeLable(int secondsLeft)
        {
            string seconds = secondsLeft % 60 < 10 ? "0" + (secondsLeft % 60).ToString() : (secondsLeft % 60).ToString();
            string minutes = secondsLeft % 3600 / 60 < 10 ? "0" + (secondsLeft % 3600 / 60).ToString() : (secondsLeft % 3600 / 60).ToString();
            string hours = secondsLeft / 3600 < 10 ? "0" + (secondsLeft / 3600).ToString() : (secondsLeft / 3600).ToString(); ;
            mainPage.SecondsLable = String.Format(" {0}:{1}:{2} ", hours, minutes, seconds);
        }

        public Presenter(StopWhatch sw)
        {
            stopWhatch = sw;
            stopWhatch.AddObserver(this);
            mainPage = new MainPage();
            mainPage.GetStartButton.Clicked += GetStart_Clicked;
            mainPage.GetStopButton.Clicked += GetStopButton_Clicked;
        }
    }
}
