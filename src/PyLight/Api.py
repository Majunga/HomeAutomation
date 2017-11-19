import datetime
import requests
import json
import config
import urllib3.contrib.pyopenssl

def setup():
    urllib3.contrib.pyopenssl.inject_into_urllib3()


def GetLocation(id, name, inside):

    payload = { 'id' : id, 'name' : name, 'inside' : inside}
    headers = {'content-type': 'application/json'}
    url = config.APISETTINGS["url"] + "/Location"

    r = requests.post(url, data=json.dumps(payload), headers=headers)
    if r.status_code == 200:
        return json.loads(r.text)["data"]

    else:
        print(r.status_code)
        raise Exception(json.loads(r.text))
        
def GetDeviceType(id, name):
    
    payload = { 'id' : id, 'name' : name}
    headers = {'content-type': 'application/json'}

    r = requests.post(config.APISETTINGS["url"]  + "/DeviceType", data=json.dumps(payload), headers=headers)
	
    if r.status_code == 200:
        return json.loads(r.text)["data"]

    else:
        print(r.status_code)
        raise Exception(json.loads(r.text))
        
def GetSensor(id, name):
    payload = { 'id' : id, 'name' : name}
    headers = {'content-type': 'application/json'}

    r = requests.post(config.APISETTINGS["url"]  + "/Sensor", data=json.dumps(payload), headers=headers)
	
    if r.status_code == 200:
        return json.loads(r.text)["data"]

    else:
        print(r.status_code)
        
        raise Exception(json.loads(r.text))

def GetDevice(id, name, location, deviceType, sensors):
    payload = { 'id' : id, 'name' : name, 'location' : location, 'deviceType' : deviceType, 'sensors': sensors }
    headers = {'content-type': 'application/json'}
    
    r = requests.post(config.APISETTINGS["url"]  + "/Device", data=json.dumps(payload), headers=headers)
    if r.status_code == 200:
        return json.loads(r.text)["data"]

    else:
        print(r.status_code)
        
        raise Exception(json.loads(r.text))

        
def GetDeviceInfo(name):
    
    r = requests.get(config.APISETTINGS["url"]  + "/DeviceInfo?deviceName=" + name)
    if r.status_code == 200:
        return json.loads(r.text)["data"]

    else:
        print(r.status_code)
        
        raise Exception(json.loads(r.text))

def PostData(deviceId, sensorId, data):
    payload = { "deviceId": deviceId, "sensorTypeId": sensorId, "data": data }
    headers = {'content-type': 'application/json'}
    r = requests.post(config.APISETTINGS["url"]  + "/Data", data=json.dumps(payload), headers=headers)
    if r.status_code != 200:
        print(r.status_code)
        print(json.loads(r.text))
        return False
    else:
        return True

# def main():
#     try:
#         location = GetLocation(0, "Inside", True)

#         deviceType = GetDeviceType(0, "Test")

#         sensor = GetSensor(0, "Light")
        
#         device = GetDevice(0, "Test", location, deviceType, [sensor])

#         deviceInfo = GetDeviceInfo("Test")

#         print(device)
#         print(sensor)
#         print("Post")
#         PostData(device["device"]["id"], sensor["id"], [{"CreationDateTime": f"{datetime.datetime.now():%Y-%m-%d %H:%M:%S.%f}", "PercentageOfLight":  10.0 }, {"CreationDateTime": f"{datetime.datetime.now():%Y-%m-%d %H:%M:%S.%f}", "PercentageOfLight":  20.0 }])


#     except Exception as ex:
#         print (ex)
#         pass



# if __name__ == '__main__':
#     main()