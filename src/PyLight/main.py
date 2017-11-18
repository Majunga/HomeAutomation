import time
import RPi.GPIO as GPIO
import sensor
import Api
import config
import asyncio

DATA = []

def deviceSetup():
    print("Setting up Device")
    Api.setup()

    print("Setting up device vars")
    location = config.APISETTINGS["location"]
    deviceType = config.APISETTINGS["deviceType"] 
    sensors = config.APISETTINGS["sensors"]
    device = { 'id' : 0, 'name': config.APISETTINGS["deviceName"], 'location': location, 'deviceType': deviceType, 'sensors': sensors}


    if location["id"] == 0:
        print("Getting Location")
        location = Api.GetLocation(location["id"], location["name"], location["inside"])
        print(f"Location: {location}")
        
    if deviceType["id"] == 0:
        print(f"Getting Device Type")
        deviceType = Api.GetDeviceType(deviceType["id"], deviceType["name"])
        print(f"Device Type: {location}")
        
    print(f"Getting Sensors")
    for item in sensors:
        if item["id"] > 0:
            pass
        newsensor = Api.GetSensor(item["id"], item["name"])
        if newsensor["id"] > 0:
            sensors.remove(item)
            sensors.append(newsensor)
    print(f"Sensors: {sensors}")

    if device["id"] == 0:
        print(f"Getting Device")
        device = Api.GetDevice(device["id"], device["name"], location, deviceType, sensors)
        print(f"Device: {device}")
    
        
    return device

def AddData(device, value):
    DATA.append({ "percentageoflight": value, "creationdatetime": time.time() })

    if DATA.count > 1000:
        print("Sending Data")
        NEWDATA = DATA
        DATA.clear()
        
        lightSensor = [x for x in device["sensors"] if x.n == "Light"][0]
        asyncio.ensure_future(Api.PostData(device["id"], lightSensor, NEWDATA))

def main():
    try:
        device = deviceSetup()

        print("Starting Main Program Loop")
        while True:
            signalStrength = sensor.rc_time(config.APISETTINGS["pin"])
            signalPercentage = sensor.calcSignalPercentage(signalStrength)

            AddData(device, signalPercentage)

            print(signalPercentage)
    except Exception as ex:
        print(ex)
    finally:
        GPIO.cleanup()

if __name__ == '__main__':
    main()
