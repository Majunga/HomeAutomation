namespace Sensors.Gpio
{
    using System;
    using System.Threading.Tasks;
    using Sensors.Enums;
    using Unosquare.RaspberryIO;

    public class UnosquareGpio : IGpio
    {
        public bool Read(int pin)
        {
            return Pi.Gpio[pin].Read();
        }

        public Task<bool> ReadAsync(int pin)
        {
            return Pi.Gpio[pin].ReadAsync();
        }

        public int ReadLevel(int pin)
        {
            return Pi.Gpio[pin].ReadLevel();
        }

        public Task<int> ReadLevelAsync(int pin)
        {
            return Pi.Gpio[pin].ReadLevelAsync();
        }

        public GpioPinValue ReadValue(int pin)
        {
            switch (Pi.Gpio[pin].ReadValue())
            {
                case Unosquare.RaspberryIO.Gpio.GpioPinValue.High:
                    return GpioPinValue.High;
                case Unosquare.RaspberryIO.Gpio.GpioPinValue.Low:
                    return GpioPinValue.Low;
                default:
                    throw new InvalidOperationException("Cannot Read Pin Value");
            }
        }

        public async Task<GpioPinValue> ReadValueAsync(int pin)
        {
            switch (await Pi.Gpio[pin].ReadValueAsync())
            {
                case Unosquare.RaspberryIO.Gpio.GpioPinValue.High:
                    return GpioPinValue.High;
                case Unosquare.RaspberryIO.Gpio.GpioPinValue.Low:
                    return GpioPinValue.Low;
                default:
                    throw new InvalidOperationException("Cannot Read Pin Value");
            }
        }

        public void Write(int pin, int value)
        {
            Pi.Gpio[pin].Write(value);
        }

        public void Write(int pin, bool value)
        {
            Pi.Gpio[pin].WriteAsync(value);
        }

        public void Write(int pin, GpioPinValue value)
        {
            switch (value)
            {
                case GpioPinValue.High:
                    Pi.Gpio[pin].Write(Unosquare.RaspberryIO.Gpio.GpioPinValue.High);
                    break;
                case GpioPinValue.Low:
                    Pi.Gpio[pin].Write(Unosquare.RaspberryIO.Gpio.GpioPinValue.Low);
                    break;
                default:
                    throw new InvalidOperationException("Cannot Read Pin Value");
            }
        }

        public Task WriteAsync(int pin, int value)
        {
            return Pi.Gpio[pin].WriteAsync(value);
        }

        public Task WriteAsync(int pin, bool value)
        {
            return Pi.Gpio[pin].WriteAsync(value);
        }

        public Task WriteAsync(int pin, GpioPinValue value)
        {
            switch (value)
            {
                case GpioPinValue.High:
                    return Pi.Gpio[pin].WriteAsync(Unosquare.RaspberryIO.Gpio.GpioPinValue.High);
                case GpioPinValue.Low:
                    return Pi.Gpio[pin].WriteAsync(Unosquare.RaspberryIO.Gpio.GpioPinValue.Low);
                default:
                    throw new InvalidOperationException("Cannot Read Pin Value");
            }
        }

        public void WriteLevel(int pin, int value)
        {
            Pi.Gpio[pin].WriteLevel(value);
        }

        public Task WriteLevelAsync(int pin, int value)
        {
           return Pi.Gpio[pin].WriteLevelAsync(value);
        }
    }
}
