-- Problem 1 - EMPLOYEES WITH SALARY ABOVE 35000
USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
    SELECT FirstName, LastName
    FROM Employees
    WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

-- Problem 2 - EMPLOYEES WITH SALARY ABOVE NUMBER
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@inputSalary DECIMAL(18,4))
AS
    SELECT FirstName, LastName
    FROM Employees
    WHERE Salary >= @inputSalary

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- Problem 3 - TOWN NAMES STARTING WITH
CREATE OR ALTER PROC usp_GetTownsStartingWith(@subName NVARCHAR(50))
AS
    SELECT [Name]
    FROM Towns
    WHERE [Name] LIKE @subName + '%'

EXEC usp_GetTownsStartingWith 'b'

-- Problem 4 - EMPLOYEES FROM TOWN
CREATE PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(50))
AS
    SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
    FROM Employees AS e
    JOIN Addresses AS a ON a.AddressID = e.AddressID
    JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName

EXEC usp_GetEmployeesFromTown 'Sofia'

-- Problem 5 - SALARY LEVEL FUNCTION
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @salaryLevel NVARCHAR(10)

    IF(@salary < 30000)
        SET @salaryLevel = 'Low'
    ELSE IF(@salary >= 30000 AND @salary <= 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'

	RETURN @salaryLevel
END

SELECT Salary,dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees


-- Problem 6 - EMPLOYEES BY SALARY LEVEL
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(20))
AS
    SELECT FirstName AS [First Name]
          ,LastName AS [Last Name]
    FROM Employees
    WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

EXEC usp_EmployeesBySalaryLevel 'High'

-- Problem 7 - DEFINE FUNCTION
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
BEGIN
    DECLARE @count INT = 1
    DECLARE @wordMatch NVARCHAR(MAX)

    WHILE (@count <= LEN(@word))
    BEGIN
        DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)
		
     IF (CHARINDEX(@currentLetter, @setOfLetters) = 0)
	 RETURN 0

	 SET @count += 1;
END
RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') AS Result
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob') AS Result
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy') AS Result

-- Problem 8 - DELETE EMPLOYEES AND DEPARTMENTS
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS

    ALTER TABLE Departments
    ALTER COLUMN ManagerID INT

    DELETE FROM EmployeesProjects
    WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

    UPDATE Departments
    SET ManagerID = NULL
    WHERE DepartmentID = @departmentId

    UPDATE Employees
    SET ManagerID = NULL
    WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

    DELETE FROM Employees
    WHERE DepartmentID = @departmentId

    DELETE FROM Departments
    WHERE DepartmentID = @departmentId

SELECT COUNT(*)
FROM Employees
WHERE DepartmentID = @departmentId

-- Problem 9 - FIND FULL NAME
USE Bank
GO

CREATE PROC usp_GetHoldersFullName
AS
    SELECT ah.FirstName + ' ' + ah.LastName AS [Full Name]
    FROM AccountHolders AS ah

EXEC usp_GetHoldersFullName

-- Problem 10 - PEOPLE WITH BALANCE HIGHER THAN
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@value DECIMAL(16,2))
AS 
    SELECT ah.FirstName,ah.LastName
    FROM AccountHolders AS ah
    JOIN Accounts AS a ON a.AccountHolderId = ah.Id
    GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
    HAVING SUM(a.Balance) > @value	
    ORDER BY ah.FirstName, ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan 10000

-- Problem 11 - FUTURE VALUE FUNCTION
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(16, 2), @yearlyRate FLOAT, @numberYears INT)
RETURNS DECIMAL(16, 4)
AS 
    BEGIN
        DECLARE @fv DECIMAL(16, 4) 

        SET @fv = @sum * (POWER(1 + @yearlyRate, @numberYears))
        RETURN @fv 
    END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output]

-- Problem 12 - CALCULATING INTEREST
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accounID INT, @interestRate FLOAT, @years INT = 5)
AS 
    BEGIN
        SELECT a.Id
              ,ah.FirstName
              ,ah.LastName
              ,a.Balance
              ,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, @years) AS [Balance in 5 years]
        FROM Accounts AS a
        JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
        WHERE a.Id = @accounID
    END

EXEC usp_CalculateFutureValueForAccount 1, 0.1, 10

-- Problem 13 - CASH IN USER GAMES ODD ROWS
USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS 
	RETURN (SELECT SUM(fQuerry.Cash) AS SumCash
			FROM
				(
					SELECT ug.Cash AS Cash
						  ,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [Row Number]
					FROM UsersGames AS ug
					JOIN Games AS g ON g.Id = ug.GameId
					WHERE g.[Name] = @gameName
				) 
				AS fQuerry
			WHERE fQuerry.[Row Number] % 2 = 1)


SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')




