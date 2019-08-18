using System;
using System.Collections.Generic;
using System.Text;

namespace Analog_watch.Models
{
    internal interface IObserver
    {
        //Паттерн наблюдатель: наблюдающий объект
        void Update();
    }
}
