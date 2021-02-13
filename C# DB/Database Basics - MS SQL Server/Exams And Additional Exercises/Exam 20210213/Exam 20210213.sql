CREATE DATABASE Bitbucket
USE Bitbucket

-- SECTION 1 - DDL

-- Problem 1 Database Design

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username  VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT NOT NULL,
	ContributorId INT NOT NULL,

CONSTRAINT PK_RepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId),
CONSTRAINT FK_RepositoriesContributors_Rep FOREIGN KEY (RepositoryId) REFERENCES Repositories (Id),
CONSTRAINT FK_RepositoriesContributors_Con FOREIGN KEY (ContributorId) REFERENCES Users (Id)
)


CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id), --??
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files (Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)


-- SECTION 2 - DML

-- Problem 2  - Insert

INSERT INTO Files ([Name], [Size], ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93,	3, 3),
('Controller.php', 7353.15,	4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json',	14034.87, 3, 6),
('Operate.xix',	7662.92, 7,	7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId ) VALUES
('Critical Problem with HomeController.cs file', 'open', 1,	4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9,	8)

-- Problem 3 - Update
-- Make issue status 'closed' where Assignee Id is 6.

UPDATE Issues
	SET IssueStatus = 'Closed'
	WHERE AssigneeId = 6

-- Problem 4
-- Delete - Delete repository "Softuni-Teamwork" in repository contributors and issues.

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = 3

DELETE FROM Issues
	WHERE RepositoryId = 3


-- SECTION 3 - Querying

-- Problem 5
-- Select all commits from the database. Order them by id (ascending), message (ascending), repository id (ascending) and contributor id (ascending).

SELECT Id, [Message], RepositoryId, ContributorId
	FROM Commits
	ORDER BY Id ASC, [Message] ASC, RepositoryId ASC, ContributorId ASC

-- Problem 6
-- Select all of the files, which have size, greater than 1000, and a name containing "html". Order them by size (descending), id (ascending) and by file name (ascending).

SELECT Id, [Name], [Size]
	FROM Files
	WHERE [Size] > 1000 AND [Name] LIKE '%html%'
	ORDER BY [Size] DESC, Id ASC, [Name] ASC

-- Problem 7
-- Select all of the issues, and the users that are assigned to them, so that they end up in the following format: {username} : {issueTitle}. Order them by issue id (descending) and   issue assignee (ascending).

SELECT i.Id, u.Username + ' : ' + i.Title AS [IssueAssignee]
	FROM Issues AS i
	JOIN Users AS u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, [IssueAssignee] ASC

-- Problem 8
-- Select all of the files, which are NOT a parent to any other file. Select their size of the file and add "KB" to the end of it. Order them file id (ascending), file name (ascending) and file size (descending).

SELECT f.Id, f.[Name], CONCAT(f.[Size], 'KB')
	FROM Files AS f
	LEFT JOIN Files AS fl ON f.id = fl.ParentId
	WHERE fl.Id IS NULL 
	ORDER BY Id ASC, [Name] ASC, f.[Size] DESC 

-- Problem 9
--Select the top 5 repositories in terms of count of commits. Order them by commits count (descending), repository id (ascending) then by repository name (ascending).

SELECT TOP(5) r.Id, r.[Name], COUNT(r.[Name]) AS [Commits]
	FROM RepositoriesContributors AS rc
	JOIN Repositories AS r ON rc.RepositoryId = r.Id
	JOIN Commits AS c ON r.Id = c.RepositoryId
		GROUP BY r.Id, R.[Name]
		ORDER BY [Commits] DESC, r.Id ASC, r.Name ASC	

-- Problem 10
-- Select all users which have commits. Select their username and average size of the file, which were uploaded by them. Order the results by average upload size (descending) and by username (ascending).

SELECT u.Username, AVG([Size])
	FROM Files f
	JOIN Commits c ON f.CommitId = c.Id
	JOIN Users u ON c.ContributorId = u.Id
	GROUP BY u.Username
	ORDER BY AVG([Size]) DESC, u.Username ASC

--SECTION 4 - Programmability

-- Problem 11
-- Create a user defined function, named udf_AllUserCommits(@username) that receives a username.
-- The function must return count of all commits for the user:

CREATE FUNCTION udf_AllUserCommits(@username as VARCHAR(max))
RETURNS INT
AS
BEGIN
DECLARE @value  INT = (SELECT COUNT(*) FROM Commits WHERE ContributorId IN
(
    SELECT id 
        FROM Users WHERE Username=@username)
);

    RETURN @value
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

-- Problem 12
-- Search for Files

CREATE PROCEDURE usp_SearchForFiles(@fileExtension NVARCHAR(100))
AS
BEGIN 
	
	SELECT Id, [Name], CAST(Size AS VARCHAR) + 'KB' AS [Size]
		FROM Files
		WHERE [Name] LIKE '%'+@fileExtension
		ORDER BY Id ASC, [Name] ASC, Size DESC
END


