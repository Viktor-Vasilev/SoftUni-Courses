/* Problem 15 - HOTEL DATABASE */

CREATE DATABASE Hotel

Use Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50)NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Gosho,', 'Goshev', 'CEO', NULL),
(2, 'Petar,', 'Petrov', 'CFO', 'random note'),
(3, 'Jivotnoto,', 'Jelqzkov', 'CTO', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10)NOT NULL,
	EmergencyName VARCHAR(90)NOT NULL,
	EmergencyNumber CHAR(10)NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(120, 'G', 'P', '0123456789', 'e', '4567890123', NULL),
(121, 'f', 'y', '0423456789', 'd', '4577890123', NULL),
(122, 'u', 'o', '0723456789', 'z', '4569890123', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)



INSERT INTO RoomStatus VALUES
('Cleaning', NULL),
('Repairing', NULL),
('Free','random note')

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Apartment', NULL),
('Studio', NULL),
('Box','random note')

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Floor','random note')

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(120, 'Apartment', 'Single', 10, 'Free', NULL),
(121, 'Apartment', 'Double', 11, 'Cleaning', NULL),
(122, 'Apartment', 'Floor', 12, 'Free', NULL)



CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirsDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmmountCharged DECIMAL(15,2),
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, 1, GETDATE(), 120, '5/5/2012', '5/8/2012', 3, 450.30, NULL, NULL, 450.30, NULL),
(2, 1, GETDATE(), 120, '1/5/2012', '5/8/2012', 5, 750.30, NULL, NULL, 750.30, NULL),
(3, 1, GETDATE(), 120, '11/5/2012', '12/8/2012', 4, 650.30, NULL, NULL, 650.30, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, 120, GETDATE(), 120, 120, 0, 0, NULL),
(2, 120, GETDATE(), 121, 121, 0, 0, NULL),
(3, 120, GETDATE(), 122, 122, 0, 0, NULL)

/* Problem 23 - DECREASE TAX RATE */
UPDATE Payments
SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

/* Problem 24 - DELETE ALL RECORDS */
TRUNCATE TABLE Occupancies
