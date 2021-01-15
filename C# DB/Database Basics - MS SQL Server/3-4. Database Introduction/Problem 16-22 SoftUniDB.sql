/* Problem 16 - SOFTUNI DATABASE */

USE master
GO

/* Problem 16 - SOFTUNI DATABASE */
CREATE DATABASE SoftUni
GO

USE SoftUni
GO

CREATE TABLE Towns (
	 Id INT CONSTRAINT PK_Towns PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses (
	 Id INT CONSTRAINT PK_Addresses PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,AddressText NVARCHAR(100) NOT NULL
	,TownId INT CONSTRAINT FK_Addresses_Towns FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments (
	 Id INT CONSTRAINT PK_Departments PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees (
	 Id INT CONSTRAINT PK_Employees PRIMARY KEY IDENTITY(1, 1) NOT NULL
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(50) NOT NULL
	,LastName NVARCHAR(50) NOT NULL
	,JobTitle NVARCHAR(150) NOT NULL
	,DepartmentId INT CONSTRAINT FK_Employees_Departments FOREIGN KEY REFERENCES Departments(Id) NOT NULL
	,HireDate DATE
	,Salary MONEY
	,AddressId INT CONSTRAINT FK_Employees_Addresses FOREIGN KEY REFERENCES Addresses(Id)
)

/* Problem Problem 17.	Backup Database */
BACKUP DATABASE SoftUni TO DISK = 'Desktop\softuni-backup.bak'

DROP DATABASE SoftUni

RESTORE DATABASE softUni FROM DISK = 'Desktop\softuni-backup.bak'

/* Problem 18 - BASIC INSERT */
INSERT INTO Towns VALUES
	 ('Gabrovo')
	,('Pernik')
	,('Dolno Nanagornishte')
	,('Urokovo')

INSERT INTO Departments VALUES
	 ('Mechanic')
	,('Worker')
	,('Gunman')
	,('QA')
	,('Policeman')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary ) VALUES
	 ('Pesho', 'Peshev', 'Peshov', 'Salesman', 1, '2019-01-01', 1500.00)
	,('Pesha', 'Pesheva', 'Peshovb', 'Worker', 2, '2019-01-02', 2000.00)
	,('Peshu', 'Peshevc', 'Peshovd', 'Policeman', 3, '2019-01-03', 3000.00)
	,('Peshy', 'Pesheve', 'Peshovf', 'Fireman', 4, '2019-01-04', 3500.00)
	,('Peshi', 'Peshevg', 'Peshovn', 'Zooman', 5, '2019-01-05', 4000.00)

/* Problem 19 - BASIC SELECT ALL FIELDS */
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

/* Problem 20 - BASIC SELECT ALL FIELDS AND ORDER THEM */
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

/* Problem 21 - BASIC SELECT ALL SOME FIELDS */
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

/* Problem 22 - INCREASE EMPLOYEES SALARY ------------------*/
UPDATE Employees
SET Salary = Salary * 1.1

SELECT Salary FROM Employees
