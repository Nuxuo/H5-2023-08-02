import pylcdlib
lcd = pylcdlib.lcd(0x27,1)
lcd.lcd_write(0x01);
lcd.lcd_puts("NOOOOOOOB!",1) #display "Raspberry Pi" on line 1
lcd.lcd_puts(" World!",2) #display "Take a byte!" on line 2
lcd.lcd_backlight(1)