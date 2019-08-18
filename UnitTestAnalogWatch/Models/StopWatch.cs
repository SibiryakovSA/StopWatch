using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Analog_watch.Models
{

    internal class StopWhatch : IObservable
    {
        List<IObserver> observers = new List<IObserver> { };
        Timer timer = new Timer();
        int secondsLeft = 0;
        const int interval = 1000; //интервал срабатывания таймера


        public void AddObserver(IObserver observer) => observers.Add(observer);

        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void NotifyObservers()
        {
            foreach (var observer in observers)
                observer.Update();
        }

        public void StartTimer() => timer.Start();

        public void PauseTimer() => timer.Stop();

        public void StopTimer()
        {
            timer.Stop();
            secondsLeft = 0;
        }

        public int GetTimeHasPassed
        {
            get
            {
                return secondsLeft;
            }
        }

        public StopWhatch()
        {
            timer.Interval = interval;
            timer.Elapsed += (e, a) =>
            {
                NotifyObservers();
                secondsLeft++;
            };
        }

        
    }
}
