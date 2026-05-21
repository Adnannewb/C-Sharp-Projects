CREATE DATABASE DiningManagementDB;
GO
USE DiningManagementDB;


CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL 
);

INSERT INTO [User] (Username, Password, Role)
VALUES ('admin', '1234', 'Admin');


CREATE TABLE Student (
    StudentID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    RollNumber NVARCHAR(20) NOT NULL UNIQUE,
    Class NVARCHAR(50),
    Contact NVARCHAR(20),
    Address NVARCHAR(MAX)
);

CREATE TABLE Token (
    TokenID INT PRIMARY KEY IDENTITY,
    StudentID INT NOT NULL,
    TokenDate DATE NOT NULL,
    Status NVARCHAR(20) DEFAULT 'Unused', -- Values: 'Unused', 'Used'
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID)
);

CREATE TABLE Meal (
    MealID INT PRIMARY KEY IDENTITY,
    MealName NVARCHAR(100) NOT NULL,
    MealTime NVARCHAR(20), -- Values: 'Breakfast', 'Lunch', 'Dinner'
    Price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY IDENTITY,
    StudentID INT NOT NULL,
    TokenID INT NOT NULL,
    MealID INT NOT NULL,
    TransactionDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (TokenID) REFERENCES Token(TokenID),
    FOREIGN KEY (MealID) REFERENCES Meal(MealID)
);

CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    Role NVARCHAR(50),
    Contact NVARCHAR(20),
    Address NVARCHAR(MAX)
);
