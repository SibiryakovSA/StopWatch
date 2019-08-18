namespace Analog_watch.Models
{
    internal interface IObservable 
    {
        // Паттерн наблюдатель: наблюдаемый объект
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
}