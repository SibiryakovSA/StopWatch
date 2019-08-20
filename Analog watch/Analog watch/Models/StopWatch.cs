using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Analog_watch.Models
{

    internal class StopWhatch : IObservable
    {
        List<IObserver> observers = new List<IObserver> { };
        int secondsLeft = 0;
        bool timerIsWork = false;

        public void AddObserver(IObserver observer) => observers.Add(observer);

        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var observer in observers)
                observer.Update();
        }

        public void StartTimer()
        {
            if (!timerIsWork)
            {
                timerIsWork = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (timerIsWork)
                    {
                        secondsLeft++;
                        NotifyObservers();
                    }
                    return timerIsWork;
                });
            }
        }

        public void PauseTimer()
        {
            timerIsWork = false;

        }

        public void StopTimer()
        {
            timerIsWork = false;
            secondsLeft = 0;
        }

        public int GetSecondsHasPassed
        {
            get
            {
                return secondsLeft;
            }
        }

        public bool IsTimerWork
        {
            get
            {
                return timerIsWork;
            }
        }

        public StopWhatch()
        {

        }


    }
}
