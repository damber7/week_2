using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_2
{
    public class TemperatureSensor
    {
        private int temperature;
        public delegate void TemperatureChangedEventHandler(Object sender);
        public event TemperatureChangedEventHandler TemperatureChanged;

        public int Temperature
        {
            get { return temperature; }
            set
            {
                if(value != temperature) {
                    temperature = value;
                    OnTemperatureChanged();
                }
            }
        }

        public virtual void OnTemperatureChanged()
        {
            if(TemperatureChanged != null)
            {
                TemperatureChanged(this);
            }
        }

    }

    public class TemperatureMonitor
    {
        public void Connect(TemperatureSensor sensor)
        {
            sensor.TemperatureChanged += HandleTemperatureChanged;
        }

        private void HandleTemperatureChanged(object sender)
        {
            Console.WriteLine($"Temperature changed. New temperature:" + $"{((TemperatureSensor)sender).Temperature} degree Celsius"); 
        }
    }

    class EventDemo
    {
        static void Main()
        {
            TemperatureSensor sensor = new TemperatureSensor();
            TemperatureMonitor monitor = new TemperatureMonitor();
            monitor.Connect(sensor);

            sensor.Temperature = 20;
            sensor.Temperature = 25;

            Console.ReadLine();


        }
    }

    
}
