-- 1
CREATE TABLE Cities 
(
	Id INT PRIMARY KEY IDENTITY(1,1) , 
	[Name] NVARCHAR(20) NOT NULL ,
	CountryCode NVARCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Name VARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18,2) NOT NULL ,
	Type NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY  REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY ,
	RoomId INT FOREIGN KEY  REFERENCES Rooms(Id) NOT NULL ,
	BookDate DATE NOT NULL ,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL ,
	CancelDate DATE ,
	 CONSTRAINT cn_BookDate
		CHECK(BookDate< ArrivalDate ),
	CONSTRAINT cn_ArrivalDate
		CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY , 
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20) ,
	LastName NVARCHAR(50) NOT NULL ,
	CityId INT FOREIGN KEY  REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL ,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY  REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY  REFERENCES Trips(Id) NOT NULL ,
	Luggage INT  NOT NULL CHECK (Luggage >= 0)

	PRIMARY KEY(AccountId , TripId)
)

-- 2
INSERT INTO Accounts (FirstName, MiddleName ,LastName ,CityId,BirthDate,Email ) VALUES
('John' , 'Smith' , 'Smith' ,34,'1975-07-21' , 'j_smith@gmail.com'),
('Gosho' , NULL , 'Petrov' ,11,'1978-05-16' , 'g_petrov@gmail.com'),
('Ivan' , 'Petrovich' , 'Pavlov' ,59,'1849-09-26' , 'i_pavlov@softuni.bg'),
('Friedrich' , 'Wilhelm' , 'Nietzsche' ,2,'1844-10-15' , 'f_nietzsche@softuni.bg')



INSERT INTO Trips (RoomId,BookDate , ArrivalDate,ReturnDate,CancelDate) VALUES
(101, '2015-04-12' , '2015-04-14' , '2015-04-20' , '2015-02-02'),
(102, '2015-07-07' , '2015-07-15' , '2015-07-22' , '2015-04-29'),
(103, '2013-07-17' , '2013-07-23' , '2013-07-24' , NULL),
(104, '2012-03-17' , '2012-03-31' , '2012-04-01' , '2012-01-10'),
(109, '2017-08-07' , '2017-08-28' , '2017-08-29' , NULL)

--3
UPDATE Rooms
SET  price = price + (price * 14.0 / 100.0)
WHERE HotelId IN(5,7,9)

--4 
delete from AccountsTrips
where AccountId = 47

--5
SELECT FirstName ,LastName,FORMAT(BirthDate,'MM-dd-yyy') AS BirthDate ,c.[Name] AS Hometown,
Email FROM Accounts AS a 
INNER JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.[Name] ASC

--6
SELECT c.[Name] ,COUNT(*) AS Hotels FROM Hotels AS h
INNER JOIN Cities AS c ON h.CityId = c.Id
GROUP BY CityId , c.[Name]
ORDER BY COUNT(*) DESC , c.[Name]

--7
SELECT AccountId ,a.FirstName + ' '+ a.LastName AS FullName ,
	 	MAX(DATEDIFF(DAY , ArrivalDate , ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF (DAY , ArrivalDate,ReturnDate)) AS ShortestTrip
FROM AccountsTrips AS [at]
INNER JOIN Trips AS t ON t.Id = [at].TripId
INNER JOIN Accounts AS a ON a.Id = [at].AccountId
WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
GROUP BY AccountId , a.FirstName , a.LastName
ORDER BY LongestTrip DESC , ShortestTrip ASC

--8
SELECT TOP(10) c.Id , c.[Name] , c.CountryCode , COUNT(*) FROM Accounts AS a
INNER JOIN Cities AS c ON a.CityId = c.Id 
GROUP BY a.CityId  , c.Id , c.[Name] ,c.CountryCode
ORDER BY COUNT(a.CityId) DESC

--9
SELECT a.Id , a.Email ,c.[Name] , COUNT(*) AS Trips FROM Accounts AS a
INNER JOIN Cities AS c  ON c.Id = a.CityId 
INNER JOIN Hotels AS h ON h.CityId = c.Id
INNER JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
INNER JOIN Trips AS t ON t.Id =[at].TripId
INNER JOIN Rooms AS r ON r.HotelId = h.Id
WHERE TripId = t.Id AND t.RoomId = r.Id AND r.HotelId =  h.Id AND h.CityId = a.CityId
GROUP BY a.Id , a.Email ,c.[Name] 
ORDER BY Trips DESC ,a.Id

--10
SELECT TripId,
		   CASE WHEN MiddleName IS NULL THEN FirstName + ' ' + LastName
				ELSE FirstName + ' ' + MiddleName + ' ' + LastName END AS FullName,
		   Origin AS [From],
		   Cities.[Name] AS [To],
		   CASE WHEN CancelDate IS NOT NULL THEN 'Canceled'
				ELSE CONCAT(DATEDIFF(DAY, ArrivalDate, ReturnDate), ' days') END AS Duration
	FROM
		(SELECT Trips.Id AS TripId,
			   FirstName,
			   MiddleName,
			   LastName,
			   ArrivalDate,
			   ReturnDate,
			   CancelDate,
			   Cities.[Name] As Origin,
			   Hotels.CityId AS Destination
		FROM Trips
		JOIN AccountsTrips ON AccountsTrips.TripId = Trips.Id
		JOIN Accounts ON AccountsTrips.AccountId = Accounts.Id
		JOIN Rooms ON Trips.RoomId = Rooms.Id
		JOIN Hotels ON Rooms.HotelId = Hotels.Id
		JOIN Cities ON Accounts.CityId = Cities.Id) AS AggregatedData
JOIN Cities ON [Destination] = Cities.Id
ORDER BY FullName ASC,
		 TripId ASC

--11 ???


--12 4 FROM 7 POINTS!!!!
CREATE PROCEDURE usp_SwitchRoom(@TripId INT , @TargetRoomId INT)
AS 
BEGIN
	DECLARE @TripRoomHotelId INT;
	DECLARE @TargetRoomBeds INT;
	DECLARE @TripPeople INT;
	DECLARE @TargetRoomHotel INT;

	SELECT @TripPeople = COUNT(*)
	FROM AccountsTrips
	WHERE TripId = @TripId
	GROUP BY TripId

	SELECT @TripRoomHotelId = Rooms.HotelId
	FROM Trips
	JOIN Rooms ON Trips.RoomId = Rooms.Id
	WHERE Trips.Id = @TripId
	
	SELECT @TargetRoomBeds = Rooms.Beds,
			@TargetRoomHotel = Rooms.HotelId
	FROM Rooms
	WHERE Rooms.Id = @TargetRoomId AND Rooms.HotelId = @TripRoomHotelId

	IF(@TripRoomHotelId <> @TargetRoomHotel)
		THROW 50001, 'Target room is in another hotel!', 1
	ELSE IF (@TargetRoomBeds < @TripPeople)
		THROW 50002, 'Not enough beds in target room!', 1
	ELSE
		BEGIN 
			UPDATE Trips
			SET RoomId = @TargetRoomId
			WHERE Trips.Id = @TripId
		END
END