-- Problem 1 - CREATE TABLE LOGS
USE Bank
GO

CREATE TABLE Logs (
     LogId INT CONSTRAINT PK_Logs PRIMARY KEY IDENTITY NOT NULL
    ,AccountId INT CONSTRAINT FK_Logs_Accounts FOREIGN KEY REFERENCES Accounts(Id)
    ,OldSum DECIMAL(15,2) NOT NULL
    ,NewSum DECIMAL(15,2) NOT NULL
)

CREATE TRIGGER tr_InsertAccountInfo ON Accounts FOR UPDATE
AS
    DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
    DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
    DECLARE @accountId INT = (SELECT Id FROM inserted)

    INSERT INTO Logs (AccountId, NewSum, OldSum) VALUES
    (@accountId, @newSum, @oldSum)

UPDATE Accounts
SET Balance += 10
WHERE Id = 1
   
SELECT * FROM Accounts
WHERE Id = 1

SELECT * FROM Logs

-- Problem 2 - CREATE TABLE EMAILS
CREATE TABLE NotificationEmails (
     Id INT PRIMARY KEY IDENTITY
    ,Recipient INT FOREIGN KEY REFERENCES Accounts(Id)
    ,[Subject] VARCHAR(50)
    ,Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS	
    DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
    DECLARE @oldSum DECIMAL(15, 2) = (SELECT TOP(1) OldSum FROM inserted)
    DECLARE @newSum DECIMAL(15, 2) = (SELECT TOP(1) NewSum FROM inserted)

    INSERT INTO NotificationEmails (Recipient, [Subject], Body) VALUES
        (
            @accountId
           ,'Balance change for account: ' + CAST(@accountId AS VARCHAR(20))
           ,'On ' + CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was changed from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20))
        )

UPDATE Accounts
SET Balance += 100
WHERE Id = 1
	
SELECT * FROM Accounts WHERE Id = 1
SELECT * FROM Logs
SELECT * FROM NotificationEmails

-- Problem 3 - DEPOSIT MONEY
CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
    BEGIN TRANSACTION
        DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
		
        IF(@accountId IS NULL)
        BEGIN
            ROLLBACK
            RAISERROR('Invalid account Id!', 16, 1)
            RETURN
        END
		
        IF(@moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Negative amount!', 16, 1)
            RETURN
        END

UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

SELECT * FROM Accounts WHERE Id = 1
EXEC usp_DepositMoney 1, 234.14
SELECT * FROM Accounts WHERE Id = 1

-- Problem 4 - WITHDRAW MONEY
CREATE PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
    BEGIN TRANSACTION
        DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
        DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)
		
        IF(@accountId IS NULL)
        BEGIN
            ROLLBACK
            RAISERROR('Invalid account Id!', 16, 1)
            RETURN
        END
		
        IF(@moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Negative amount!', 16, 1)
            RETURN
        END

        IF(@accountBalance - @moneyAmount < 0)
        BEGIN
            ROLLBACK
            RAISERROR('Insufficient funds', 16, 1)
            RETURN
        END

    UPDATE Accounts
    SET Balance -= @moneyAmount
    WHERE Id = @accountId
    COMMIT

SELECT * FROM Accounts WHERE Id = 1
EXEC usp_WithdrawMoney 1, 150.14
SELECT * FROM Accounts WHERE Id = 1

-- Problem 5 - MONEY TRANSFER
CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
    BEGIN TRANSACTION
        EXEC usp_WithdrawMoney @senderId, @amount
        EXEC usp_DepositMoney @receiverId, @amount
    COMMIT

SELECT * FROM Accounts WHERE Id IN(1, 2)
EXEC usp_TransferMoney 1, 2, 100
SELECT * FROM Accounts WHERE Id IN(1, 2)

-- Problem 6 - TRIGGER
USE Diablo
GO

CREATE TRIGGER tr_RestrictItems ON UserGameItems INSTEAD OF INSERT
AS
	DECLARE @itemId INT = (SELECT ItemId FROM inserted)
	DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
	DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

	IF(@userGameLevel >= @itemLevel)
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) VALUES
			(@itemId, @userGameId)
	END

-- Problem 7 - MASSIVE SHOPPING
DECLARE @gameId INT, @sum1 MONEY, @sum2 MONEY;

SELECT @gameId = usg.[Id]
FROM UsersGames AS usg
     JOIN Games AS g ON usg.[GameId] = g.[Id]
WHERE g.[Name] = 'Safflower';

SET @sum1 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 11 AND 12
);

SET @sum2 =
(
    SELECT SUM(i.Price)
    FROM Items AS i
    WHERE MinLevel BETWEEN 19 AND 21
);

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum1
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum1
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 11 AND 12;
        COMMIT;
END;

BEGIN TRANSACTION;

IF
(
    SELECT Cash
    FROM UsersGames
    WHERE Id = @gameId
) < @sum2
    BEGIN
        ROLLBACK;
END
    ELSE
    BEGIN
        UPDATE UsersGames
          SET
              Cash = Cash - @sum2
        WHERE Id = @gameId;

        INSERT INTO UserGameItems(UserGameId,
                                  ItemId
                                 )
               SELECT @gameId,
                      Id
               FROM Items
               WHERE MinLevel BETWEEN 19 AND 21;
        COMMIT;
END;

SELECT i.Name AS 'Item Name'
FROM UserGameItems AS ugi
     JOIN Items AS i ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = @gameId;

-- Problem 8 - EMPLOYEES WITH THREE PROJECTS
USE SoftUni
GO

CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN 
	DECLARE @maxProjectsAllowed INT = 3; 
	DECLARE @currentProjects INT;

	SET @currentProjects = 
	(SELECT COUNT(*) 
	FROM Employees AS e
	JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
	WHERE ep.EmployeeID = @emloyeeId)

BEGIN TRANSACTION 	
	IF(@currentProjects >= @maxProjectsAllowed)
	BEGIN 
		RAISERROR('The employee has too many projects!', 16, 1);
		ROLLBACK;
		RETURN;
	END

	INSERT INTO EmployeesProjects
	VALUES
	(@emloyeeId, @projectID)

COMMIT	
END 

-- Problem 9 - DELETE EMPLOYEES
CREATE TRIGGER tr_DeletedEmp 
ON Employees 
AFTER DELETE 
AS
	INSERT INTO Deleted_Employees
	SELECT 	
		d.FirstName, 
		d.LastName, 
		d.MiddleName, 
		d.JobTitle, 
		d.DepartmentID, 
		d.Salary
FROM deleted as d

