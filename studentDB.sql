CREATE DATABASE School;

Use School;

CREATE TABLE Student(
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	StudentCode VARCHAR(100) NOT NULL,
	NameStudent VARCHAR(300) NOT NULL,
	BirthDate DATETIME NOT NULL,
	Gender VARCHAR(100) NOT NULL,
	GradeId INT NOT NULL,
	Comments VARCHAR (300),
);

EXEC sp_StudentAllData
CREATE PROCEDURE sp_StudentAllData
AS
BEGIN
	SELECT * FROM Student ORDER BY NameStudent ASC
END

CREATE PROCEDURE sp_StudentOneData
	@Id INT 
AS
BEGIN
	SELECT * FROM Student WHERE Id = @Id
END

CREATE OR ALTER PROCEDURE sp_StudentInsert
	@StudentCode VARCHAR(100),
	@NameStudent VARCHAR(300),
	@BirthDate DATETIME,
	@Gender VARCHAR(100),
	@GradeId INT,
	@Comments VARCHAR (300)
AS
BEGIN
	INSERT INTO  Student (StudentCode, NameStudent, BirthDate, Gender, GradeId, Comments) 
	VALUES (UPPER(@StudentCode), UPPER(@NameStudent), @BirthDate, UPPER(@Gender), @GradeId, UPPER(@Comments))
END

CREATE OR ALTER PROCEDURE sp_StudentUpdate
	@Id INT,
	@StudentCode VARCHAR(100),
	@NameStudent VARCHAR(300),
	@BirthDate DATETIME,
	@Gender VARCHAR(100),
	@Comments VARCHAR (300)
AS
BEGIN
	UPDATE Student 
	SET 
	StudentCode = UPPER(@StudentCode), 
	NameStudent = UPPER(@NameStudent), 
	BirthDate = @BirthDate, 
	Gender = UPPER(@Gender), 
	Comments = UPPER(@Comments) 
	WHERE Id = @Id
END

CREATE PROCEDURE sp_StudentDelete
	@Id INT 
AS
BEGIN
	DELETE FROM Student WHERE Id = @Id
END