-- Problem 1.	One-To-One Relationship
CREATE DATABASE TEST

USE TEST
GO

CREATE TABLE Passports
(
	PassportId INT NOT NULL PRIMARY KEY,
	PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30),
	Salary DECIMAL(15,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons VALUES
('Robero', 43300.00, 102),
('Tom',  56100.00, 103),
('Yana', 60200.00, 101)

-- Problem 2.	One-To-Many Relationship
CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATETIME
)

CREATE TABLE Models
(
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
     ('BMW', '1916-03-07'),
    ('Tesla', '2003-01-01'),
    ('Lada', '1966-05-01')

INSERT INTO Models VALUES
     ('X1', 1),
     ('i6', 1),
     ('Model S', 2),
     ('Model X', 2),
     ('Model 3', 2),
     ('Nova', 3)

-- Problem 3.	Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50)
)

CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT,

	CONSTRAINT PK_Students_Exams PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_Students FOREIGN KEY (StudentID) REFERENCES Students(StudentID), 
	CONSTRAINT FK_Exams FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students VALUES
     ('Mila'),
     ('Toni'),
     ('Ron')

INSERT INTO Exams VALUES
     ('SpringMVC'),
     ('Neo4j'),
     ('Oracle 11g')

INSERT INTO StudentsExams VALUES
     (1, 101),
     (1, 102),
     (2, 101),
     (3, 103),
     (2, 102),
     (2, 103)

-- Problem 4.	Self-Referencing 
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50),
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
     ('John', NULL),
     ('Maya', 106),
     ('Silvia', 106),
     ('Ted', 105),
     ('Mark', 101),
     ('Greta', 101)

/* 

CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] VARCHAR(50),
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
     ('John', NULL),
     ('Maya', NULL),
     ('Silvia', NULL),
     ('Ted', NULL),
     ('Mark', 101),
     ('Greta', 101)

UPDATE Teachers
SET ManagerID = 106
WHERE TeacherID IN (102, 103)

UPDATE Teachers
SET ManagerID = 105
WHERE TeacherID = 104

*/

-- Problem 5.	Online Store Database
CREATE DATABASE StoreDB
USE StoreDB

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID)

	CONSTRAINT PK_Order_Item PRIMARY KEY (OrderID, ItemID)
)


-- Problem 6.	University Database
CREATE DATABASE UniversityDB
USE UniversityDB

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(100) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(15,2),
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

	CONSTRAINT PK_StudentID_SubjectID PRIMARY KEY (StudentID, SubjectID)
)




-- Problem 7.	SoftUni Design


-- Problem 8.	Geography Design


-- Problem 9.   Peaks in Rila
USE [Geography]

SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
	FROM Mountains
	JOIN Peaks ON Peaks.MountainId = Mountains.Id
	WHERE Mountains.MountainRange = 'Rila'
	ORDER BY Peaks.Elevation DESC

--SELECT m.MountainRange
--      ,p.PeakName
--      ,p.Elevation 
--FROM Mountains AS m
--JOIN Peaks AS p ON p.MountainId = m.Id
--WHERE m.MountainRange = 'Rila'
--ORDER BY p.Elevation DESC
