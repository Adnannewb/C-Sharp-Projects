
CREATE DATABASE PayrollDB;
GO


USE PayrollDB;



CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Address VARCHAR(255),
    ContactInfo VARCHAR(50),
    EmployeeType VARCHAR(50),
    BasicSalary FLOAT,
    HourlyRate FLOAT
);


CREATE TABLE Payroll (
    PayrollID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT FOREIGN KEY REFERENCES Employee(EmployeeID),
    PayrollDate DATE
);


CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeID INT FOREIGN KEY REFERENCES Employee(EmployeeID),
    GrossPay FLOAT,
    NetPay FLOAT,
    Deductions FLOAT,
    PaymentDate DATE,
    OvertimeHours FLOAT
);


CREATE TABLE Deduction (
    DeductionID INT PRIMARY KEY IDENTITY(1,1),
    PaymentID INT FOREIGN KEY REFERENCES Payment(PaymentID),
    DeductionType VARCHAR(50),
    Percentage FLOAT,
    FixedAmount FLOAT
);


CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL
);


INSERT INTO Admin (Username, Password)
VALUES ('Archi', '1234')