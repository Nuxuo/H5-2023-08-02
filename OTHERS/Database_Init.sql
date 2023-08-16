CREATE TABLE `Keycard` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `keycardGuid` varchar(36) NOT NULL,
  `Active` bit NOT NULL
);

CREATE TABLE `Employee` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `Name` varchar(75) NOT NULL,
  `keycardId` int,
  `PersonalCode` int NOT NULL
);

CREATE TABLE `AccessLevel` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `EmployeeId` int NOT NULL,
  `ServerRoom` int NOT NULL
);

CREATE TABLE `Building` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `Name` varchar(75) NOT NULL
);

CREATE TABLE `ServerRoom` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `Name` varchar(75) NOT NULL,
  `BuildingId` int NOT NULL,
  `OperatingAllowedTimeStampStart` TIME,
  `OperatingAllowedTimeStampEnd` TIME
);

CREATE TABLE `ServerRoomConditions` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `ServerRoomId` int NOT NULL,
  `Date` Date NOT NULL,
  `Temperture` double NOT NULL,
  `Humitity` double NOT NULL
);

CREATE TABLE `ServerRoomEntryActivity` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `EmployeeId` int NOT NULL,
  `ServerRoomId` int NOT NULL,
  `Date` Date NOT NULL,
  `image` blob
);

CREATE TABLE `ServerRoomAlarms` (
  `Id` int PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `ServerRoomId` int NOT NULL,
  `Temperture` double NOT NULL,
  `Humitity` double NOT NULL,
  `Date` Date NOT NULL,
  `image` blob
);

ALTER TABLE `Employee` ADD FOREIGN KEY (`keycardId`) REFERENCES `Keycard` (`Id`);

ALTER TABLE `AccessLevel` ADD FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`);

ALTER TABLE `AccessLevel` ADD FOREIGN KEY (`ServerRoom`) REFERENCES `ServerRoom` (`Id`);

ALTER TABLE `ServerRoom` ADD FOREIGN KEY (`BuildingId`) REFERENCES `Building` (`Id`);

ALTER TABLE `ServerRoomConditions` ADD FOREIGN KEY (`ServerRoomId`) REFERENCES `ServerRoom` (`Id`);

ALTER TABLE `ServerRoomEntryActivity` ADD FOREIGN KEY (`EmployeeId`) REFERENCES `Employee` (`Id`);

ALTER TABLE `ServerRoomEntryActivity` ADD FOREIGN KEY (`ServerRoomId`) REFERENCES `ServerRoom` (`Id`);

ALTER TABLE `ServerRoomAlarms` ADD FOREIGN KEY (`ServerRoomId`) REFERENCES `ServerRoom` (`Id`);
