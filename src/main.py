import RPi.GPIO as GPIO
import time
import sensor

maxStrength = 0



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