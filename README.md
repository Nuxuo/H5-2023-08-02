# H5-2023-08-02

IoT & Embedded Systems - Datacenter Access Management and Monitoring Solution
Table of Contents
Introduction
Requirements
Solution Overview
Hardware
Software
Communication
Documentation
Conclusion
Introduction
This repository contains a comprehensive solution for access management and monitoring of a datacenter using IoT and embedded systems. The goal is to maintain optimal conditions within the datacenter, manage access to the server room, and provide efficient monitoring capabilities.

Requirements
The solution must address the following aspects:

Climate
Maintain server room temperature between 23 and 26˚C.
Temperature variation should not exceed 1.5˚C per hour.
Maintain humidity levels between 45% and 55%.
Work Hours
Standard work hours: 8:00 AM to 6:00 PM.
Access may be required outside standard hours for critical updates or emergencies.
Access
Employees are provided with access cards for the server room.
Access cards log employee entries and exits.
Ability to create time-limited access cards for external service personnel.
Option to deactivate access cards (due to resignation or loss).
Monitoring
Live streaming of server room images.
Capability to capture individual images of people during specific situations (manual function / after standard work hours).
Scalable solution for multiple server rooms with distinct access and monitoring.
Solution Overview
Our solution involves using various IoT devices and embedded systems to meet the requirements:

Raspberry Pi 3 and 4, Arduino Uno, M5 Stack, STM32F746NG-DISCO, along with appropriate sensors and devices.
Code structured with clear blocks, minimal repetition, and comprehensive comments.
A balance between custom code and standard libraries.
A chosen communication protocol (MQTT or API) for inter-device communication.
Data collection into a central database, either using standard SQL or NoSQL.
Local security measures and network security policies.
Hardware
The solution incorporates the following hardware components:

Raspberry Pi 3 and 4 for processing and connectivity.
Arduino Uno for additional sensor integration.
M5 Stack for a portable display and user interaction.
STM32F746NG-DISCO for advanced control and interaction.
Various sensors for temperature, humidity, and access control.
Software
The software aspects of the solution include:

Efficient code organization with clear comments.
Utilization of standard libraries when appropriate.
Implementation of access control mechanisms for employee access cards.
Development of logic to handle time-limited access cards.
Code to capture and stream server room images.
Logging of critical events and access attempts.
Integration of temperature and humidity monitoring routines.
Communication
The chosen communication methods are:

Eventbus communication between devices, using either MQTT or API protocols.
Data collection into a central database using either standard SQL or NoSQL.
Documentation
The documentation consists of:

User manual detailing how to use the developed solution, including adding/deleting employees, accessing the server room, etc.
Technical description explaining the system setup from scratch.
Listing of hardware used, along with suggestions for improvements.
Clear attribution when using code from external sources.
