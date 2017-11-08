# 
#
import RPi.GPIO as GPIO
import time

GPIO.setmode(GPIO.BOARD)

output_pin = 7
# Number of seconds before return pitch black signal
blackoutTimer = 60

# Check to see if it is pitch black
def isDark(now):
    if time.time() > now + blackoutTimer:
        return True
    
    return False

# Get Sensor signal strength. 
# The higher the number the weaker the light
# -1 is returned if blackout timer is reached (this is so the program doesn't overflow or impact the device)
def rc_time (output_pin):
    global maxStrength 
    count = 0
    now = time.time()
    
    GPIO.setup(output_pin, GPIO.OUT)
    GPIO.output(output_pin, GPIO.LOW)
    time.sleep(0.1)
    GPIO.setup(output_pin, GPIO.IN)
    
    # Wait for Signal from Sensor
    while(GPIO.input(output_pin) == GPIO.LOW): 
        count += 1

        # If Dark return pitch black signal
        if isDark(now):
            maxStrength = count
            print ("Pitch black value: {}".format(count))
            return -1

    # return signal strength
    return count

def calcSignalPercentage(signalStrength):
    global maxStrength 
    if signalStrength == 0:
      return 0

    if signalStrength == -1:
        return 100
    
    if signalStrength > maxStrength:
        maxStrength = signalStrength

    signalPercentage = (signalStrength / maxStrength) * 100

    return signalPercentage

def main():
    try:
        
        while True:
            signalStrength = rc_time(output_pin)
            signalPercentage = calcSignalPercentage(signalStrength)
            print (signalPercentage)
    except Exception as ex:
        print (ex)
        pass
    finally:
        GPIO.cleanup()

if __name__ == '__main__':
        main()
