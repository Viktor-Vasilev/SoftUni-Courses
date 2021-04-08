CREATE DATABASE [Service]
USE [Service]

-- SECTION 1 - DDL

-- Problem 1 Database Design

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
);

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
);

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
);

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Label] VARCHAR(30) NOT NULL
);

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
);

-- SECTION 2 - DML

-- Problem 2  - Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5);

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
( 14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
( 4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1);


-- Problem 3 - Update
-- Update the CloseDate with the current date of all reports, which don't have CloseDate. 
UPDATE Reports
   SET CloseDate = GETDATE()
   WHERE CloseDate IS NULL;

-- Problem 4
-- Delete all reports who have a Status 4.
 DELETE FROM Reports
 WHERE StatusId = 4;

-- SECTION 3 - Querying

-- Problem 5
-- Find all reports that don't have an assigned employee. Order the results by OpenDate in ascending order, then by description ascending. OpenDate must be in format - 'dd-MM-yyyy'
  SELECT r.Description,
          FORMAT(r.OpenDate, 'dd-MM-yyyy') AS OpenDate
     FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
    WHERE e.Id IS NULL
 ORDER BY r.OpenDate, r.Description;

-- Problem 6
-- Select all descriptions from reports, which have category. Order them by description (ascending) then by category name (ascending).
  SELECT r.Description,
         c.Name AS CategoryName
    FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.Description, c.Name;

-- Problem 7
-- Select the top 5 most reported categories and order them by the number of reports per category in descending order and then alphabetically by name.
SELECT TOP(5) c.Name AS CategoryName,
         COUNT(r.CategoryId) AS ReportsNumber
    FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name;

-- Problem 8
-- Select the user's username and category name in all reports in which users have submitted a report on their birthday. Order them by username (ascending) and then by category name (ascending).
SELECT u.Username,
       c.Name AS CategoryName
    FROM Users AS u
    JOIN Reports AS r ON u.Id = r.UserId
    JOIN Categories AS c ON r.CategoryId = c.Id
         WHERE DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate) AND
         DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
ORDER BY u.Username, c.Name;

-- Problem 9
-- Select all employees and show how many unique users each of them has served to. Order by users count  (descending) and then by full name (ascending).
 SELECT e.FirstName + ' ' + e.LastName AS FullName,
          COUNT(r.UserId) AS UsersCount
     FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
 GROUP BY e.FirstName, e.LastName
 ORDER BY UsersCount DESC, FullName;

-- Problem 10
-- Select all info for reports along with employee first name and last name (concataned with space), their department name, category name, report description, open date, status label and name of the user. Order them by first name (descending), last name (descending), department (ascending), category (ascending), description (ascending), open date (ascending), status (ascending) and user (ascending). Date should be in format - dd.MM.yyyy. If there are empty records, replace them with 'None'.

  SELECT  ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee,
          ISNULL(d.Name, 'None') AS Department,
		  ISNULL(c.Name, 'None') AS Category,
		  ISNULL(r.Description, 'None') AS Description,
		  ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate,
		  ISNULL(s.Label, 'None') AS Status,
		  ISNULL(u.Name, 'None') AS [User]
     FROM Reports AS r
			LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
			LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
			LEFT JOIN Categories AS c ON r.CategoryId = c.Id
			LEFT JOIN Status AS s ON r.StatusId = s.Id
			LEFT JOIN Users AS u ON r.UserId = u.Id
 ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate, s.Label, u.Name;

--SECTION 4 - Programmability

-- Problem 11
-- Create a user defined function with the name udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) that receives a start date and end date and must returns the total hours which has been taken for this task. If start date is null or end is null return 0.
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports

-- Problem 12
--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) that receives an employee's Id and a report's Id and assigns the employee to the report only if the department of the employee and the department of the report's category are the same. Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!". 
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN

	DECLARE @EmpDepartmentId INT = (
										SELECT d.Id FROM Departments AS d
											JOIN Employees AS e ON d.Id = e.DepartmentId
											WHERE e.Id = @EmployeeId
								    ); 

	DECLARE @RepDepartmentID INT = (
										SELECT d.Id FROM Departments AS d
											JOIN Categories AS c ON d.Id = c.DepartmentId
											JOIN Reports AS r ON c.Id = r.CategoryId
											WHERE r.Id = @ReportId
									);

	IF(@EmpDepartmentId = @RepDepartmentID)
		BEGIN
			UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
		END
	ELSE
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
END

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2

