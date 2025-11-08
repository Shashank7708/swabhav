

Create table Restaurants(
id int Primary Key Identity(1,1),
Name varchar(200) Not null,
Address varchar(500) Not null,
Phone varchar(20),
Email varchar(100),
ImageURL varchar(1000)
)

Create table RestaurantBranches(
id int Primary Key Identity(1,1),
RestaurantId int,
Name varchar(200) ,
Address varchar(500),
Phone varchar(20),
Email varchar(100),
ImageURL varchar(1000)
Foreign Key(RestaurantId) references Restaurants(id) on Delete Set Null
)

Create Table TimeSlots(
id Int Primary key Identity(1,1),
BranchId int,
ReservationDay datetime ,
MealType varchar(50),
TableStatus varchar(100)
Foreign Key(BranchId) references RestaurantBranches(id) on Delete Cascade
)

Create Table DiningTables(
id Int Primary key Identity(1,1),
BranchId int,
SeatName varchar(100),
Capacity int
Foreign Key(BranchId) references RestaurantBranches(id) on Delete Cascade
)

Create Table Users(
Id int Primary key Identity(100,1),
FirstName varchar(50) not null,
LastName varchar(100) not null,
EmailId varchar(100) not null,
AdObjId varchar(100) null,
ProfileImageURL varchar(512) null
)
Create table Reservations(
Id int primary key identity(1,1),
UserId int not null,
TableId int not null,
TimeSlotId int not null,
ReservationDate Date Not null
)

INSERT INTO Restaurants (Name, Address, Phone, Email, ImageURL)
VALUES 
('The Spice Villa', '123 Flavor Street, New York, NY', '212-555-1234', 'info@spicevilla.com', 'https://example.com/spicevilla.jpg'),
('Ocean Breeze Diner', '456 Seaside Ave, Miami, FL', '305-555-9876', 'contact@oceanbreeze.com', 'https://example.com/oceanbreeze.jpg'),
('Mountain Feast', '789 Summit Road, Denver, CO', '720-555-4321', 'hello@mountainfeast.com', 'https://example.com/mountainfeast.jpg');

INSERT INTO RestaurantBranches (RestaurantId, Name, Address, Phone, Email, ImageURL)
VALUES
(1, 'The Spice Villa - Downtown', '45 Main St, New York, NY', '212-555-5678', 'downtown@spicevilla.com', 'https://example.com/spicevilla-downtown.jpg'),
(1, 'The Spice Villa - Uptown', '210 Central Park West, New York, NY', '212-555-9012', 'uptown@spicevilla.com', 'https://example.com/spicevilla-uptown.jpg'),
(2, 'Ocean Breeze - South Beach', '101 Ocean Dr, Miami, FL', '305-555-4455', 'southbeach@oceanbreeze.com', 'https://example.com/oceanbreeze-south.jpg'),
(3, 'Mountain Feast - Downtown', '55 Peak Blvd, Denver, CO', '720-555-7788', 'downtown@mountainfeast.com', 'https://example.com/mountainfeast-downtown.jpg');

INSERT INTO TimeSlots (BranchId, ReservationDay, MealType, TableStatus)
VALUES
(1, '2025-10-26 12:00:00', 'Lunch', 'Available'),
(1, '2025-10-26 19:00:00', 'Dinner', 'Booked'),
(2, '2025-10-26 12:30:00', 'Lunch', 'Available'),
(3, '2025-10-26 20:00:00', 'Dinner', 'Available'),
(4, '2025-10-26 18:30:00', 'Dinner', 'Booked');

INSERT INTO DiningTables (BranchId, SeatName, Capacity)
VALUES
(1, 'Table A1', 2),
(1, 'Table A2', 4),
(2, 'Table B1', 6),
(3, 'Table C1', 2),
(4, 'Table D1', 4);


INSERT INTO Users (FirstName, LastName, EmailId, AdObjId, ProfileImageURL)
VALUES
('John', 'Doe', 'john.doe@example.com', NULL, 'https://example.com/users/john.jpg'),
('Emily', 'Clark', 'emily.clark@example.com', NULL, 'https://example.com/users/emily.jpg'),
('Michael', 'Smith', 'michael.smith@example.com', NULL, 'https://example.com/users/michael.jpg'),
('Sophia', 'Brown', 'sophia.brown@example.com', NULL, 'https://example.com/users/sophia.jpg');

INSERT INTO Reservations (UserId, TableId, TimeSlotId, ReservationDate)
VALUES
(100, 1, 2, '2025-10-26'),
(101, 3, 3, '2025-10-26'),
(102, 4, 4, '2025-10-26'),
(103, 5, 5, '2025-10-26');

select r.Id,u.FirstName+ ' '+u.LastName as Username, br.Name as branchName, 
d.SeatName as TableSeatName, r.ReservationDate,ts.MealType,ts.TableStatus
from Reservations as R with(Nolock)
join Users as u with(nolock) on r.UserId=u.id
join DiningTables as d with(nolock) on d.id=r.TableId
join RestaurantBranches as br with(Nolock) on br.id=d.BranchId
join TimeSlots as ts with(nolock) on ts.id=r.TimeSlotId




select u.FirstName,dt.SeatName,t.ReservationDay,r.reservationstatus, br.Name,rt.Name from Reservations as r with(Nolock)
join users as u with(nolock) on u.id=r.UserId
join TimeSlots as t with(Nolock) on t.id=r.TimeSlotId
join DiningTables as dt with(Nolock) on dt.id=r.TableId
join RestaurantBranches as br with(Nolock) on br.id=dt.restaurantbranchid
join Restaurants as rt with(nolock) on rt.id=br.RestaurantId


 