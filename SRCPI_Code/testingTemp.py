#from grovepi import *
#from grove_rgb_lcd import *
import smbus
import time

i2c_address = 0x27

dht_sensor_port = 7		# Connect the DHt sensor to port 7
dht_sensor_type = 1		# Connect the DHt sensor to port 7

def send_text_to_lcd(text):
    bus = smbus.SMBus(1)
    bus.write_byte(i2c_address, ord("S"))
    bus.write_i2c_block_data(i2c_address,0, list(text.encode()))
    #bus.write_string(i2c_address, text)

while True:
    if __name__ == "__main__":
        send_text_to_lcd("hello world!")
        time.sleep(10)

        

