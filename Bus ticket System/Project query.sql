create database busticketDB;
use busticketDB;
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Phone NVARCHAR(20),
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(255),
    Role NVARCHAR(10) -- 'Admin' or 'Customer'
);
INSERT INTO Users (Name, Phone, Username, Password, Role)  
VALUES ('Admin', '1234567890', 'admin', '1234', 'Admin');
CREATE TABLE Buses (
    BusID INT PRIMARY KEY IDENTITY(1,1),
    BusName NVARCHAR(100),
    RouteFrom NVARCHAR(100),
    RouteTo NVARCHAR(100),
    TotalSeats INT,
    AvailableSeats INT,
    TicketPrice DECIMAL(10,2)
);

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    BusID INT FOREIGN KEY REFERENCES Buses(BusID),
    SeatNumber INT,
    PaymentAmount DECIMAL(10,2),
    BookingDate DATETIME DEFAULT GETDATE()
);

ALTER TABLE Bookings
ALTER COLUMN SeatNumber NVARCHAR(50);


CREATE TABLE BusSeats (
    SeatID INT PRIMARY KEY IDENTITY(1,1),
    BusID INT FOREIGN KEY REFERENCES Buses(BusID),
    SeatNumber NVARCHAR(10),
    IsBooked BIT DEFAULT 0 
);



ALTER TABLE Bookings
ADD CONSTRAINT FK_Bookings_Buses FOREIGN KEY (BusID) REFERENCES Buses(BusID) ON DELETE CASCADE;



ALTER TABLE BusSeats
ADD CONSTRAINT FK_BusSeats_Buses FOREIGN KEY (BusID) REFERENCES Buses(BusID) ON DELETE CASCADE;


select * from BusSeats;
select * from Bookings;
