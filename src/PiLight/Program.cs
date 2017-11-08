using System;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace PiLight
{
    class Program
    {
        static int maxStrength = 1000;
        static int blackoutTimer = 60;
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
        static int CalculateSignalStrengthPercentage(int signalStrength)
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

            return (signalStrength / maxStrength) * 100;
        }
        static bool IsDark(DateTime now)
        {
            if(DateTime.Now > now.AddSeconds(blackoutTimer))
            {
                return true;
            }
            return false;
        }
    }
}
