namespace Sensors.Gpio
{
    using System.Threading.Tasks;
    using Sensors.Enums;

    public interface IGpio
    {
        bool Read(int pin);

        // Summary:
        //     Reads the digital value on the pin as a boolean value.
        //
        // Returns:
        //     The state of the pin
        Task<bool> ReadAsync(int pin);

        // Summary:
        //     Reads the analog value on the pin. This returns the value read on the supplied
        //     analog input pin. You will need to register additional analog modules to enable
        //     this function for devices such as the Gertboard, quick2Wire analog board, etc.
        //
        // Returns:
        //     The analog level
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     When the pin mode is not configured as an input.
        int ReadLevel(int pin);

        // Summary:
        //     Reads the analog value on the pin. This returns the value read on the supplied
        //     analog input pin. You will need to register additional analog modules to enable
        //     this function for devices such as the Gertboard, quick2Wire analog board, etc.
        //
        // Returns:
        //     The analog level
        Task<int> ReadLevelAsync(int pin);

        // Summary:
        //     Reads the digital value on the pin as a High or Low value.
        //
        // Returns:
        //     The state of the pin
        GpioPinValue ReadValue(int pin);

        // Summary:
        //     Reads the digital value on the pin as a High or Low value.
        //
        // Returns:
        //     The state of the pin
        Task<GpioPinValue> ReadValueAsync(int pin);

        // Summary:
        //     Writes the specified value. 0 for low, any other value for high This method performs
        //     a digital write
        //
        // Parameters:
        //   value:
        //     The value.
        void Write(int pin, int value);

        // Summary:
        //     Writes the specified bit value. This method performs a digital write
        //
        // Parameters:
        //   value:
        //     if set to true [value].
        void Write(int pin, bool value);

        // Summary:
        //     Writes the specified pin value. This method performs a digital write
        //
        // Parameters:
        //   value:
        //     The value.
        void Write(int pin, GpioPinValue value);

        // Summary:
        //     Writes the specified value. 0 for low, any other value for high This method performs
        //     a digital write
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The awaitable task
        Task WriteAsync(int pin, int value);

        // Summary:
        //     Writes the specified bit value. This method performs a digital write
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The awaitable task
        Task WriteAsync(int pin, bool value);

        // Summary:
        //     Writes the value asynchronously.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The awaitable task
        Task WriteAsync(int pin, GpioPinValue value);

        // Summary:
        //     Writes the specified value as an analog level. You will need to register additional
        //     analog modules to enable this function for devices such as the Gertboard.
        //
        // Parameters:
        //   value:
        //     The value.
        void WriteLevel(int pin, int value);

        // Summary:
        //     Writes the specified value as an analog level. You will need to register additional
        //     analog modules to enable this function for devices such as the Gertboard.
        //
        // Parameters:
        //   value:
        //     The value.
        //
        // Returns:
        //     The awaitable task
        Task WriteLevelAsync(int pin, int value);
    }
}