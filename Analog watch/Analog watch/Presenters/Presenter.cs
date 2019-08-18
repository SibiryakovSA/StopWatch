using System;
using System.Collections.Generic;
using System.Text;
using Analog_watch.Models;
using Analog_watch;
using System.Threading.Tasks;
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
                mainPage.SetTimeLable(0);
                mainPage.GetStopButton.IsEnabled = false;
                mainPage.GetClockSecondsHand.Rotation = 0;
                mainPage.GetClockMinutesHand.Rotation = 0;
            }
        }

        public void Update()
        {
            mainPage.GetClockSecondsHand.Rotation += 6;
            mainPage.GetClockMinutesHand.Rotation += 0.1;
            mainPage.SetTimeLable(stopWhatch.GetSecondsHasPassed);
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
