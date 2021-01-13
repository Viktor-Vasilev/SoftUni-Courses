/* Problem 14 - CAR RENTAL DATABASE */

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT,
)

CREATE TABLE Cars 
(
	 Id INT PRIMARY KEY ,
	 PlateNumber VARCHAR(10) NOT NULL,
	 Manufacturer VARCHAR(50) NOT NULL,
	 Model VARCHAR(50) NOT NULL,
	 CarYear INT NOT NULL,
	 CategoryId INT NOT NULL,
	 Doors INT NOT NULL,
	 Picture VARBINARY(MAX),
	 Condition VARCHAR(50),
	 Available BIT NOT NULL,
)

CREATE TABLE Employees
(
	 Id INT PRIMARY KEY,
	 FirstName NVARCHAR(30) NOT NULL,
	 LastName NVARCHAR(30) NOT NULL,
	 Title NVARCHAR(30),
	 Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
	 Id INT PRIMARY KEY,
	 DriverLicenceNumber VARCHAR(20) NOT NULL,
	 FullName VARCHAR(120) NOT NULL,
	 [Address] VARCHAR(300) NOT NULL,
	 City NVARCHAR(40) NOT NULL,
	 ZIPCode NVARCHAR(20) NOT NULL,
	 Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd - KilometrageStart,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT NOT NULL,
	TaxRate AS RateApplied * 0.3,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (Id, CategoryName) VALUES
	(1, 'Sport car'),
	(2, 'Truck'),
	(3, 'Cabrio')

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available) VALUES
	(1, 'Boza1', 'Opel', 'Corsa', 1998, 1, 1, 1),
	(2, 'Boza2', 'Suzuki', 'Rodster', 1999, 2, 2, 2),
	(3, 'Boza3', 'Honda', 'CR-V', 2000, 3, 3, 3)

INSERT INTO Employees (Id, FirstName, LastName) VALUES
	 (1, 'Asen', 'Asenov'),
	 (2, 'Jivotnoto', 'Jelqzkov'),
	 (3, 'Viktor', 'Vasilev')

INSERT INTO Customers (Id, DriverLicenceNumber, FullName, [Address], City, ZIPCode) VALUES
	 (1, '111111', 'Some Cool Name 1', 'Some Street 1', 'Stara Zagora', '6000'),
	 (2, '222222', 'Some Cool Name 2', 'Some Street 2', 'Sofia', '1000'),
	 (3, '333333', 'Some Cool Name 3', 'Some Street 3', 'Plovidv', '2000')

INSERT INTO RentalOrders(Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, RateApplied, OrderStatus) VALUES
	 (1, 1, 1, 1, 11, 1111, 11111, '2010-02-10', '2010-07-10', 250, 1),
	 (2, 2, 2, 2, 22, 2222, 22222, '2010-09-18', '2010-10-24', 1500, 0),
	 (3, 3, 3, 3, 33, 3333, 33333, '2010-05-08', '2010-05-01', 850, 0)




