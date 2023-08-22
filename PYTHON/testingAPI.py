from mfrc522_i2c import MFRC522
import signal
import requests
import json
import adafruit_matrixkeypad
from digitalio import DigitalInOut
from grovepi import *
from grove_rgb_lcd import *
import board
import datetime
from datetime import date, datetime
import time
from json import dumps
import os
import pygame, sys
from PIL import Image
import base64
from pygame.locals import *
import pygame.camera
import pylcdlib

Api_Address = "http://192.168.1.135:44344"
ServerRoomId = "1"
CardUid = ""

setup_starting = True
while(setup_starting):
    payload = {'ServerRoomId':ServerRoomId}
    setup_response = requests.get(Api_Address + '/V1/SetupRequest', json = payload)
    if(setup_response.status_code == 200):
        setup_starting = False
setup_response_json = setup_response.json()
high_temp = setup_response_json["highTemperture"]
low_temp = setup_response_json["lowTemperture"]
change_temp = setup_response_json["hourlyTempertureMaxChange"]
high_humid = setup_response_json["highHumidity"]
low_humid = setup_response_json["lowHumidity"]
operating_time_start = datetime.strptime(setup_response_json["operatingAllowedTimeStampStart"], "%H:%M:%S").time()
operating_time_end = datetime.strptime(setup_response_json["operatingAllowedTimeStampEnd"], "%H:%M:%S").time()

i2cBus = 1
i2cAddress = 0x28
MFRC522Reader = MFRC522(i2cBus, i2cAddress)
continue_reading = True

cols = [DigitalInOut(x) for x in (board.D26, board.D5, board.D20)]
rows = [DigitalInOut(x) for x in (board.D13, board.D6, board.D21, board.D19)]
keys = ((1, 2, 3),(4, 5, 6),(7, 8, 9),('*', 0, '#'))
keypad = adafruit_matrixkeypad.Matrix_Keypad(rows, cols, keys)

lcd = pylcdlib.lcd(0x27,1)
buzzer_pin = 2
led_pin = 4
button = 3
pinMode(buzzer_pin,"OUTPUT")
pinMode(led_pin,"OUTPUT")
pinMode(button,"INPUT")

dht_sensor_port = 7
dht_sensor_type = 1

conditions_last_check = datetime.now()
conditions_last_send = datetime.now()
conditions_mins_check = 1
conditions_mins_conditions = 5
conditions_mins_alarm = 30
alarms_checked =  {
    1:datetime.now(),
    2:datetime.now(),
    3:datetime.now(),
    4:datetime.now()
}

width = 920
height = 480

# FUNCTIONS
def has_time_elasped(ts1, ts2, t):
    td_in_secs = (ts2 -ts1).total_seconds()
    td_in_mins = divmod(td_in_secs, 60)[0]
    if td_in_mins >= t:
        return True
    else:
        return False

def clear_display():
    setRGB(0,0,255)
    setText("")
    
def json_serial(obj):
    if isinstance(obj, (datetime, date)):
        return obj.isoformat()
    raise TypeError ("Type %s not serializable" % type(obj))

def camera_image():      
    pygame.init()
    pygame.camera.init()
    cam = pygame.camera.Camera("/dev/video0",(width,height))
    cam.start()
    image = cam.get_image()
    cam.stop()
    pygame.image.save(image,'temp-image.jpg')
    with open('temp-image.jpg', "rb") as f:
        ba = bytearray(f.read())
        return base64.b64encode(ba).decode('utf-8')
    
def clear_LCD():
    lcd.lcd_puts("",1)
    lcd.lcd_puts("",2)
    lcd.lcd_puts("",3)
    lcd.lcd_puts("",4)
    
def granted_access_effects():
    digitalWrite(buzzer_pin,1)
    time.sleep(0.01)
    digitalWrite(buzzer_pin,0)
    digitalWrite(led_pin,1)
    time.sleep(2)
    digitalWrite(led_pin,0)

def check_access_timestamp():
    global operating_time_start
    global operating_time_end
    current_datetime = datetime.now()
    current_time = current_datetime.time()
    
    print("checking open hours time")
    
    if (operating_time_start > current_time or current_time > operating_time_end):
        [ temp,hum ] = dht(dht_sensor_port,dht_sensor_type)
        formatted_timestamp = current_datetime.strftime("%Y-%m-%dT%H:%M:%S.%fZ")
        time = dumps(formatted_timestamp, default=json_serial)
        payload = {'ServerRoomId':ServerRoomId,'Temperture':temp,'Humidtity':hum,'DateTime':formatted_timestamp,'Reason':'Unauthorized Access.. (outside open hours)',}
        response = requests.get(Api_Address + '/V1/Data/Alarm', json = payload)
    

def access_granted():
    clear_display()
    setRGB(0,255,0)
    setText("Access granted!")
    check_access_timestamp()
    granted_access_effects()
    clear_display()
    
def access_denied():
    clear_display()
    setRGB(255,0,0)
    setText("Access denied!")
    time.sleep(1)
    clear_display()
    
def add_alarm_checked(_id):
    global conditions_mins_alarm  
    if has_time_elasped(alarms_checked.get(_id) , datetime.now(), conditions_mins_alarm):
        alarms_checked[_id] = datetime.now()
        return True
    return False
    
def check_conditions(ts):
    print('Checking Conditions..')
    clear_LCD()
    
    timestamp = ts
    formatted_timestamp = timestamp.strftime("%Y-%m-%dT%H:%M:%S.%fZ")
    global conditions_last_check
    global conditions_last_send
    conditions_last_check = timestamp
    reason = ""
    [ temp,hum ] = dht(dht_sensor_port,dht_sensor_type)
    if (temp > high_temp):
        if add_alarm_checked(1):
            reason = reason + "Temperture to high"
    if (temp < low_temp):
        if add_alarm_checked(2):
            reason = reason + "Temperture to low"
    if (hum > high_humid):
        if add_alarm_checked(3):
            reason = reason + "Humidity to high"
    if (hum < low_humid):
        if add_alarm_checked(4):
            reason = reason + "Humidity to low"
    
    clear_display()
    lcd.lcd_puts("Temperature = "+ str(temp)+"c",1)
    lcd.lcd_puts("Humidity = " + str(hum) +"%",2)
    
    if ( has_time_elasped( conditions_last_send , timestamp, conditions_mins_conditions )):
        conditions_last_send = timestamp
        print("Sending Conditions..")
        time = dumps(timestamp, default=json_serial)
        payload = {'ServerRoomId':ServerRoomId,'Temperture':temp,'Humidtity':hum,'Datetime':formatted_timestamp}
        response = requests.get(Api_Address + '/V1/Data/Conditions', json = payload)
        conditions_last_send = timestamp
        
    if (reason != ""):
        print("Sending Alarm..")
        lcd.lcd_puts(reason,4)
        time = dumps(timestamp, default=json_serial)
        payload = {'ServerRoomId':ServerRoomId,'Temperture':temp,'Humidtity':hum,'DateTime':formatted_timestamp,'Reason':reason,}
        response = requests.get(Api_Address + '/V1/Data/Alarm', json = payload)
        
# MAIN LOOP
while continue_reading:
    button_status= digitalRead(button)
    
    if button_status:
        access_granted()
    
    timestamp = datetime.now()
    if ( has_time_elasped( conditions_last_check , timestamp, conditions_mins_check )):
        check_conditions(timestamp)
        
    (status, backData, tagType) = MFRC522Reader.scan()
    if status == MFRC522Reader.MIFARE_OK:
        
        (status, uid, backBits) = MFRC522Reader.identify()
        if status == MFRC522Reader.MIFARE_OK:
            
            CardUid = ""
            for i in range(0, len(uid) ):
                CardUid = CardUid + f'{uid[i]:02x}'
            
            payload = {'KeycardId':CardUid, 'ServerRoomId':ServerRoomId}
            response = requests.get(Api_Address + '/V1/AccessRequest/keycard', json = payload)
            
            print(str(response) +'|'+ str(CardUid))
            
            if(response.status_code == 200):
                keypad_reading = True
                key_reading = True
                security_code = ""
                setText(" Enter PIN code")
                
                while(keypad_reading):
                    keys = keypad.pressed_keys
                    
                    if not keys:
                        key_reading = True
                    
                    elif key_reading == True: 
                        if(keys[0] == "#"):
                            keypad_reading = False
                        else:
                            security_code = security_code + str(keys[0])
                            key_reading = False
                        
                        
                    time.sleep(0.1)
                
                
                image = camera_image()
                payload = {'ImageByteArray':image,'Code':security_code,'KeycardId':CardUid, 'ServerRoomId':ServerRoomId}
                response = requests.get(Api_Address + '/V1/AccessRequest/code', json = payload)

                print(response)
                
                if(response.status_code == 200):
                    access_granted()
                    
                else:
                    access_denied()
                
            






