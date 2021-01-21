              -- TEXT FUNCTIONS
-- Concatenation – combines strings
-- CONCAT replaces NULL values with empty space
-- CONCAT_WS combines strings with separator

-- SUBSTRING – extracts a part of a string
-- SUBSTRING(String, StartIndex, Length)

-- REPLACE – replaces a specific string with another
-- REPLACE(String, Pattern, Replacement)

-- LTRIM & RTRIM – remove spaces from either side of string
-- LTRIM(String) - left trim
-- RTRIM(String) - right trim
-- TRIM(String) - left and right trim

-- DATALENGTH – gets the number of used bytes
-- DATALENGTH(String)

-- LEFT & RIGHT – get characters from the beginning or the end of a string

-- LOWER & UPPER – change letter casing

-- REPLICATE – repeats a string
-- REPLICATE(String, Count)


-- FORMAT – format a value with a valid .NET format string

-- CHARINDEX – locates a specific pattern (substring) in a string
-- CHARINDEX(Pattern, String, [StartIndex])

-- STUFF – inserts a substring at a specific position
-- STUFF(String, StartIndex, Length, Substring) -> Length - number of chars to delete.


                 -- MATH FUNCTIONS
-- PI – gets the value of Pi as a float (15 –digit precision)
-- ABS – absolute value
-- SQRT – square root (the result will be float)
-- SQUARE – raise to power of two
-- POWER – raises value to the desired exponent
-- ROUND – obtains the desired precision
-- Negative precision rounds characters before the decimal point
-- FLOOR & CEILING – return the nearest integer
-- SIGN – returns 1, -1 or 0, depending on the value of the sign
-- RAND – gets a random float value in the range [0, 1]


                  -- DATE FUNCTIONS
-- DATEPART – extract a segment from a date as an integer

-- DATEDIFF – finds the difference between two dates

-- DATENAME – gets a string representation of a date's part

-- DATEADD – performs date arithmetic

-- GETDATE – obtains the current date and time

-- EOMONTH – returns the last day of the month

                 -- OTHER FUNCTIONS
-- CAST & CONVERT – conversion between data types

-- ISNULL – swaps NULL values with a specified default value
-- COALESCE – evaluates the arguments in order and returns the current value of the first expression that initially does not evaluate to NULL
-- OFFSET & FETCH – get only specific rows from the result set
-- Used in combination with ORDER BY for pagination





-- Problem 1 - OBFUSCATE CC NUMBERS
USE Demo

SELECT [CustomerID], [FirstName], [LastName],
LEFT([PaymentNumber], 6) + REPLICATE('*', LEN(PaymentNumber) - 6)  AS [PaymentNumber_Obf]
FROM [Demo].[dbo].[Customers]

-- Problem 2 Area of triangles
USE DEMO

SELECT Id,[A],[H],
       (A*H)/2 AS Area
  FROM Triangles2


-- Problem 3 Line Length
SELECT Id,
       SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2))
    AS Length
  FROM Lines

-- Problem 4 - PALLETS
USE DEMO

SELECT *,
CEILING(1.0*Quantity / (BoxCapacity * PalletCapacity)) AS [Number of Pallets]
FROM Products




-- Problem 5 QUARTERLY REPORT
USE SoftUni
GO

SELECT [FirstName] + ' ' + [LastName],
	[HireDate],
	DATEPART(QUARTER, HireDate) AS Quarter,
	DATEPART(MONTH, HireDate),
	DATEPART(YEAR, HireDate),
	DATEPART(DAY, HireDate)	
FROM Employees


-- Problem 6 Find all employees who's first name starts with "Ro"

SELECT EmployeeID, FirstName, LastName
  FROM Employees
 WHERE FirstName LIKE 'Ro%'




