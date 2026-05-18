CREATE DATABASE ProjectManagementDB;

USE ProjectManagementDB;

CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectName NVARCHAR(100),
    StartDate DATE,
    EndDate DATE,
    Status NVARCHAR(20)
);

CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    TaskName NVARCHAR(100),
    DueDate DATE,
    Status NVARCHAR(20),
    ProjectID INT,
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Position NVARCHAR(50),
    Contact NVARCHAR(15),
    Email NVARCHAR(100)
);
SELECT * FROM Projects;
SELECT * FROM Tasks;
SELECT * FROM Employees;

CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY IDENTITY(1,1),
    TaskID INT NOT NULL,
    EmployeeID INT NOT NULL,
    AssignmentDate DATE NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

ALTER TABLE Tasks DROP CONSTRAINT FK__Tasks__ProjectID__267ABA7A;
ALTER TABLE Assignments DROP CONSTRAINT FK__Assignmen__TaskI__2B3F6F97;
ALTER TABLE Assignments DROP CONSTRAINT FK__Assignmen__Emplo__2C3393D0;

ALTER TABLE Tasks
ADD CONSTRAINT FK__Tasks__ProjectID__267ABA7A
FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE;

ALTER TABLE Assignments
ADD CONSTRAINT FK__Assignmen__TaskI__2B3F6F97
FOREIGN KEY (TaskID) REFERENCES Tasks(TaskID) ON DELETE CASCADE;

ALTER TABLE Assignments
ADD CONSTRAINT FK__Assignmen__Emplo__2C3393D0
FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE;

SELECT * FROM Assignments;
