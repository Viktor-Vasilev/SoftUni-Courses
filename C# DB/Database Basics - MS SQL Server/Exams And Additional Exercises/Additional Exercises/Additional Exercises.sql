-- Problem 1 - Number of Users for Email Provider
USE Diablo
SELECT Query.Email , COUNT(Query.Email) AS [Number Of Users] FROM (
               SELECT RIGHT(Email,LEN(Email) - CHARINDEX('@' , Email)) AS Email 
               FROM Users
			  ) AS [Query]
GROUP BY Email
ORDER BY COUNT(Query.Email) DESC , Query.Email ASC

-- Problem 2 - All Users in Games - 0 FROM 100 !!!
USE Diablo

SELECT g.[Name] AS [Game],
		gt.[Name] AS[Game Type],
		u.Username , ug.[Level],
		ug.Cash , c.[Name] AS [Character]
FROM UsersGames AS ug
INNER JOIN Users AS u 
ON ug.UserId = u.Id
INNER JOIN Games AS g 
ON g.Id = ug.GameId
INNER JOIN Characters AS c 
ON c.Id = ug.CharacterId
INNER JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
WHERE g.IsFinished = 1
ORDER BY ug.[Level] DESC , u.Username ASC, g.[Name] ASC

-- Problem 3 - Users in Games with Their Items
SELECT u.Username, g.[Name] AS [Game], COUNT(ugi.ItemID) AS [Items Count], Sum(i.Price) AS [Items Price]
	FROM UsersGames AS ug 
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN Users As u ON u.Id = ug.UserId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
		GROUP BY u.Username, g.[Name]
		HAVING COUNT(ugi.ItemID) >= 10
		ORDER BY COUNT(ugi.ItemID) DESC, Sum(i.Price) DESC,  u.Username;



