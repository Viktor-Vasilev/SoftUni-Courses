--1 Download and get familiar with the SoftUni, Diablo and Geography database schemas and tables.

--2 FIND ALL INFORMATION ABOUT DEPARTMENTS
USE SoftUni
GO

SELECT * FROM Departments

--3 FIND ALL DEPARTMENT NAMES
SELECT [Name] FROM Departments

--4 FIND SALARY OF EACH EMPLOYEE
SELECT FirstName, LastName,Salary FROM Employees

--5 FIND FULL NAME OF EACH EMPLOYEE
SELECT FirstName, MiddleName ,LastName FROM Employees

--6 FIND EMAIL ADDRESS OF EACH EMPLOYEE
SELECT (FirstName + '.' + LastName + '@softuni.bg') AS [Full Email Address] 
FROM Employees

--7  FIND ALL DIFFERENT EMPLOYEE'S SALARIES
SELECT DISTINCT Salary FROM Employees

--8 FIND ALL INFORMATION ABOUT EMPLOYEES
SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

--9 FIND NAMES OF ALL EMPLOYEES BY SALARY IN RANGE
SELECT FirstName ,LastName,JobTitle FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

--10 FIND NAMES OF ALL EMPLOYEES
SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--11  FIND ALL EMPLOYEES WITHOUT MANAGER
SELECT FirstName ,LastName FROM Employees WHERE ManagerID IS NULL

--12 FIND ALL EMPLOYEES WITH SALARY MORE THAN
SELECT FirstName ,LastName ,Salary FROM Employees
WHERE Salary > 50000 ORDER BY Salary DESC

--13 FIND 5 BEST PAID EMPLOYEES
SELECT TOP(5) FirstName ,LastName FROM Employees ORDER BY Salary DESC

--14 FIND ALL EMPLOYEES EXCEPT MARKETING
SELECT FirstName ,LastName FROM Employees WHERE NOT (DepartmentID = 4)
SELECT FirstName ,LastName FROM Employees WHERE DepartmentID != 4
SELECT FirstName ,LastName FROM Employees WHERE DepartmentID <> 4

--15 SORT EMPLOYEES TABLE
SELECT * FROM Employees ORDER BY Salary DESC ,FirstName ASC ,
LastName DESC ,MiddleName ASC

--16 CREATE VIEW EMPLOYEES WITH SALARIES
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName ,LastName ,Salary FROM Employees

--17  CREATE VIEW EMPLOYEES WITH JOB TITLES
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT (FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName) AS [Full Name]
      ,JobTitle AS [Job Title]
FROM Employees


--18 DISTINCT JOB TITLES
SELECT DISTINCT JobTitle FROM Employees

--19 FIND FIRST 10 STARTED PROJECTS
SELECT TOP(10) * FROM Projects ORDER BY StartDate ASC ,[Name] ASC

--20 LAST 7 HIRED EMPLOYEES
SELECT TOP(7) FirstName ,LastName ,HireDate FROM Employees ORDER BY HireDate DESC

--21 INCREASE SALARIES
UPDATE Employees
SET Salary = Salary * 1.12 --SET Salary *= 1.12
WHERE DepartmentID IN(1, 2, 4, 11)

SELECT Salary FROM Employees

--22 ALL MOUNTAIN PEAKS
USE Geography
GO

SELECT PeakName FROM Peaks ORDER BY PeakName ASC


--23 BIGGEST COUNTRIES BY POPULATION
SELECT TOP(30) CountryName ,[Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC ,CountryName ASC

--24 COUNTRIES AND CURRENCY (EURO / NOT EURO)
SELECT CountryName, CountryCode,
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
END AS Currency
	FROM Countries
	ORDER BY CountryName  ASC

--25 ALL DIABLO CHARACTERS
USE Diablo
GO

SELECT [Name] FROM Characters ORDER BY [Name] ASC