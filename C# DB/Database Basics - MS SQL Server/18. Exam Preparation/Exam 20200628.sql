CREATE DATABASE ColonialJourney
USE ColonialJourney

-- SECTION 1 - DDL

-- Problem 1 Database Design
CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL 
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Ucn NVARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DateTime NOT NULL,
	JourneyEnd DateTime NOT NULL,
	Purpose NVARCHAR(11) CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber NVARCHAR(10) CHECK(LEN(CardNumber) = 10) UNIQUE NOT NULL,
	JobDuringJourney NVARCHAR(8) CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

-- SECTION 2 - DML

-- Problem 2  - Insert
INSERT INTO Planets ([Name]) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships ([Name], Manufacturer, LightSpeedRate) VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6)


-- Problem 3 - Update
UPDATE Spaceships
	SET LightSpeedRate += 1
	WHERE Id BETWEEN 8 AND 12

-- Problem 4 - Delete
DELETE FROM TravelCards WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys WHERE Id IN (1, 2, 3)	


-- SECTION 3 - Querying

-- Problem 5 - Select All Military Journeys
SELECT Id, FORMAT(JourneyStart,'dd/MM/yyyy'), FORMAT(JourneyEnd,'dd/MM/yyyy')
	FROM Journeys
	WHERE Purpose = 'Military'
	ORDER BY JourneyStart ASC

-- Problem 6 - Select All Pilots
SELECT c.Id, c.FirstName + ' ' + c.LastName 
	FROM Colonists AS c
	JOIN TravelCards AS tc On tc.ColonistId = c.Id
	WHERE JobDuringJourney = 'Pilot'
	ORDER BY c.Id ASC

-- Problem 7 - Count Colonists
SELECT COUNT(*) AS [count]
	FROM Colonists AS c
	JOIN TravelCards AS tc On tc.ColonistId = c.Id
	JOIN Journeys AS j ON j.Id = tc.JourneyId
	WHERE Purpose = 'Technical'
	GROUP BY Purpose

-- Problem 8 - Select Spaceships With Pilots
SELECT sp.[Name], sp.Manufacturer
	FROM Spaceships AS sp
	JOIN Journeys AS j ON sp.Id = j.SpaceshipId
	JOIN TravelCards AS tc ON j.Id = tc.JourneyId
	JOIN Colonists AS c ON c.Id = tc.ColonistId
		WHERE DATEADD(YEAR, 30, BirthDate) > '2019-01-01' AND JobDuringJourney = 'Pilot'
		ORDER BY sp.[Name] ASC

-- Problem 9 - Planets And Journeys
SELECT p.[Name] AS [PlanetName],
        COUNT(*) AS [JourneysCount]
    FROM Planets AS p
    JOIN Spaceports AS s ON p.Id = s.PlanetId
    JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
    GROUP BY p.[Name]
    ORDER BY JourneysCount DESC, PlanetName ASC

-- Problem 10 - Select Special Colonists
SELECT * FROM
(
    SELECT 
        tc.JobDuringJourney,
        CONCAT(c.FirstName,' ', c.LastName) AS [FullName],
        RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ASC) as [JobRank]
    FROM TravelCards tc
        JOIN Colonists c ON tc.ColonistId = c.Id
) as [RankQuery]
WHERE JobRank = 2

--SECTION 4 - Programmability

-- Problem 11 - Get Colonists Count
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30)) 
RETURNS INT
AS
BEGIN

	DECLARE @Count INT = (
							SELECT COUNT(*)
							FROM Planets AS p
							JOIN Spaceports AS s ON p.Id = s.PlanetId
							JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
							JOIN TravelCards AS tc ON j.Id = tc.JourneyId
							JOIN Colonists AS c ON tc.ColonistId = c.Id
							WHERE p.[Name] = @PlanetName
						 );

	RETURN @Count;
	
END

-- Problem 12 - Change Journey Purpose
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(20))
AS
BEGIN

	DECLARE @CurrentJourneyId INT = (SELECT Id FROM Journeys WHERE Id = @JourneyId);

	IF(@CurrentJourneyId IS NULL)
		THROW 50001, 'The journey does not exist!', 1;

	DECLARE @CurrentJourneyPurpose VARCHAR(20) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId);

	IF(@CurrentJourneyPurpose = @NewPurpose)
		THROW 50002, 'You cannot change the purpose!', 1;

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId;
END
