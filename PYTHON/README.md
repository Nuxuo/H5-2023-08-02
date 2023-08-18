# Server Room Access Control System

The Server Room Access Control System is a Python program designed to control access to a server room using various components, including RFID card readers, keypads, sensors, and a camera. The system aims to ensure secure access to the server room and monitor environmental conditions within it.

## Features

1. **Access Control:**
   The system utilizes an RFID card reader and a keypad to control access to the server room. Authorized personnel can gain access by presenting their RFID card and entering a PIN on the keypad.

2. **Environmental Monitoring:**
   The system continuously monitors temperature and humidity using sensors within the server room. It sends alerts if conditions exceed predefined thresholds.

3. **Visual Feedback:**
   The system employs an LCD display to provide real-time information about temperature, humidity, and access status. LED indicators and a buzzer provide immediate feedback during access attempts.

4. **Data Reporting:**
   The system reports environmental conditions and access events to a central server using API requests. This data can be used for analysis and record-keeping.

## Components

- **MFRC522 Reader:** Interfaces with RFID cards and scans for card presence.

- **Matrix Keypad:** Captures PIN entries for additional access verification.

- **DHT Sensor:** Measures temperature and humidity within the server room.

- **LCD Display:** Provides visual feedback and displays temperature and humidity readings.

- **LED and Buzzer:** Indicate access status (granted or denied) and provide feedback during access attempts.

- **Camera:** Captures images of individuals attempting access, linked to access events.

## Setup

1. Configure the `Api_Address` and `ServerRoomId` variables to match the central server's API address and the specific server room identifier.

2. Use the `setup_starting` loop to retrieve initial setup parameters from the central server, including temperature and humidity thresholds, allowed operating hours, and more.

3. Initialize hardware components, such as the RFID card reader, matrix keypad, LCD, and sensors, with appropriate configurations.

## Functions

- `has_time_elapsed(ts1, ts2, t)`: Checks if a specified time duration has elapsed between two timestamps.

- Various access control and feedback functions (`access_granted`, `access_denied`, etc.) handle access attempts and provide visual/auditory feedback.

- `check_conditions(timestamp)`: Monitors environmental conditions, sends data to the central server if needed, and triggers alarms if conditions exceed thresholds.

## Main Loop

The main loop continuously reads the RFID card reader, checks access attempts, monitors environmental conditions, and provides feedback using LED, LCD, and buzzer components.

## Usage

1. Authorized personnel can present their RFID card and enter a PIN to gain access to the server room.

2. The system continuously monitors and reports temperature and humidity conditions to the central server.

3. Alarms are triggered if temperature or humidity exceeds predefined thresholds.

4. Access and environmental data are sent to the central server for analysis and record-keeping.

## Note

This documentation provides an overview of the Server Room Access Control System. Ensure proper hardware connections and necessary libraries are installed before deploying the system. Adapt and extend the code as needed to meet specific requirements and configurations.
