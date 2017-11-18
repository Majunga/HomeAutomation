import datetime
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
        print("Location: {0}".format(location))
        
    if deviceType["id"] == 0:
        print("Getting Device Type")
        deviceType = Api.GetDeviceType(deviceType["id"], deviceType["name"])
        print("Device Type: {0}".format(deviceType))
        
    print("Getting Sensors")
    for item in sensors:
        if item["id"] > 0:
            pass
        newsensor = Api.GetSensor(item["id"], item["name"])
        if newsensor["id"] > 0:
            sensors.remove(item)
            sensors.append(newsensor)
    print("Sensors: {0}".format(sensors))

    if device["id"] == 0:
        print("Getting Device")
        device = Api.GetDevice(device["id"], device["name"], location, deviceType, sensors)
        print("Device: {0}".format(location))
    
        
    return device

def AddData(device, value):
    DATA.append({ "percentageoflight": value, "creationdatetime": datetime.datetime.now() })

    if len(DATA) > 100:
        print("Sending Data")
        
        lightSensor = [x for x in device["sensors"] if x["name"] == "Light"][0]
        Api.PostData(device["device"]["id"], lightSensor["id"], DATA)
        DATA.clear()
        

def main():
    try:
        device = deviceSetup()

        print("Starting Main Program Loop")
        while True:
            signalStrength = sensor.rc_time(config.APISETTINGS["pin"])
            signalPercentage = sensor.calcSignalPercentage(signalStrength)

            AddData(device, signalPercentage)

            #print(signalPercentage)
    except Exception as ex:
        print(ex)
    finally:
        GPIO.cleanup()

if __name__ == '__main__':
    main()
