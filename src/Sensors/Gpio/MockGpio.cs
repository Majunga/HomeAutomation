namespace Sensors.Gpio
{
    using System;
    using System.Threading.Tasks;
    using Sensors.Enums;

    public class MockGpio : IGpio
    {
        public bool Read(int pin)
        {
            return new Random().Next(0, 2) == 1;
        }

        public Task<bool> ReadAsync(int pin)
        {
            return Task.Run(() => new Random().Next(0, 2) == 1);
        }

        public int ReadLevel(int pin)
        {
            return new Random().Next(0, 1000);
        }

        public Task<int> ReadLevelAsync(int pin)
        {
            return Task.Run(() => new Random().Next(0, 1000));
        }

        public GpioPinValue ReadValue(int pin)
        {
            return new Random().Next(0, 2) == 1 ? GpioPinValue.High : GpioPinValue.Low;
        }

        public async Task<GpioPinValue> ReadValueAsync(int pin)
        {
            return await Task.Run(() => ( new Random().Next(0, 2) == 1 ? GpioPinValue.High : GpioPinValue.Low));
        }

        public void Write(int pin, int value)
        {
            return;
        }

        public void Write(int pin, bool value)
        {
            return;
        }

        public void Write(int pin, GpioPinValue value)
        {
            return;
        }

        public Task WriteAsync(int pin, int value)
        {
            return null;
        }

        public Task WriteAsync(int pin, bool value)
        {
            return null;
        }

        public Task WriteAsync(int pin, GpioPinValue value)
        {
            return null;
        }

        public void WriteLevel(int pin, int value)
        {
        }

        public Task WriteLevelAsync(int pin, int value)
        {
            return null;
        }
    }
}
