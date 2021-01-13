/* Problem 8 - CREATE TABLE USERS */

CREATE DATABASE USERS



USE USERS

CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARCHAR(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, ISdeleted)
VALUES
('vick', 'strongpass1', 'https://github.com/rothja.png?size=32', '1/12/2020', 0),
('stef', 'strongpass2', 'https://github.com/rothja.png?size=32', '2/12/2020', 0),
('stoyan', 'strongpass3', 'https://github.com/rothja.png?size=32', '3/12/2020', 0),
('jivotnoto', 'strongpass4', 'https://github.com/rothja.png?size=32', '4/12/2020', 0),
('deyan', 'strongpass5', 'https://github.com/rothja.png?size=32', '5/12/2020', 0)

/* Problem 9 - CHANGE PRIMARY KEY */

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC078F816B03

ALTER TABLE Users
ADD CONSTRAINT  PK_IdUsername PRIMARY KEY (Id, Username)

/* Problem 10 - ADD CHECK CONSTRAINT */
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) >= 5)

/* Problem 11 - SET DEFAULT VALUE OF FIELD */
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/* Problem 12 - SET UNIQUE FIELD */
ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
DROP CONSTRAINT UC_Username

ALTER TABLE Users
ADD CONSTRAINT  PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE(Username)

ALTER TABLE Users
ADD CONSTRAINT CH_Username CHECK (LEN(Username) >= 3)

SELECT * FROM Users
