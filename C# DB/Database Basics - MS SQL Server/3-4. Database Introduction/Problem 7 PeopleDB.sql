/* Problem 7 - CREATE TABLE PEOPLE */
CREATE TABLE People (
	 Id INT CONSTRAINT PK_People PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK (DATALENGTH(Picture) > 1024 * 1024 * 2),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) CHECK (Gender = 'm' OR Gender = 'f') NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate) VALUES
	 ('Vasil Ivanov', 1.88, 65.23, 'm', '1996/04/02')
	,('Petko Vasilev', 1.92, 72.83, 'm', '1993/07/07')
	,('Viktor Vasilev', 1.84, 82.23, 'm', '1976/04/11')
	,('Jivotnoto Jelqzkov', 2.15, 113.32, 'f', '1997/11/23')
	,('Vaskata Papesha', 1.54, 45.98, 'm', '2001/10/18')
