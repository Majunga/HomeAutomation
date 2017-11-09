using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace PiLight
{
    class Program
    {
        static decimal maxStrength = 0.0m;
        static int blackoutTimer = 500;
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var pin = Pi.Gpio.Pin07;
            try
            {
                var signalStrength = SignalSensor(pin);

                var percentage = CalculateSignalStrengthPercentage(signalStrength);

                Console.WriteLine($"Signal Strength: {percentage}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }

        }
        static int SignalSensor(GpioPin pin)
        {
            var count = 0;
            var now = DateTime.Now;

            pin.PinMode = GpioPinDriveMode.Output;
            pin.Write(GpioPinValue.Low);
            Thread.Sleep(100);
            pin.PinMode = GpioPinDriveMode.Input;

            while(pin.ReadValue() == GpioPinValue.Low)
            {
                count++;

                if (IsDark(now))
                {
                    maxStrength = count;
                    Console.WriteLine($"Pitch black value: {count}");
                    return -1;
                }
            }
            return count;
        }
        static decimal CalculateSignalStrengthPercentage(int signalStrength)
        {
            if (signalStrength == 0)
            {
                return 0;
            }

            if (signalStrength == -1)
            {
                return 100;
            }

            if (signalStrength > maxStrength)
            {
                maxStrength = signalStrength;
            }

            return (decimal.Parse(signalStrength.ToString()) / maxStrength) * 100.0m;
        }
        static bool IsDark(DateTime now)
        {
            if(DateTime.Now > now.AddMilliseconds(blackoutTimer))
            {
                return true;
            }
            return false;
        }
    }
}
