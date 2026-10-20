-- Special Night demo database, reconstructed from the queries and reader ordinals in DataAccessLayer/DALs.
-- Added for the GitHub version of this project (the original had no schema script); demo data only.
IF DB_ID('SpecialNight') IS NULL CREATE DATABASE SpecialNight;
GO
USE SpecialNight;
GO
CREATE TABLE Product (productID INT IDENTITY(1,1) PRIMARY KEY, quantity INT NOT NULL, price INT NOT NULL);
-- Dress/Suit: sizes at ordinals 3-5 and color at 6 after Product's 3 columns, so productID comes last
CREATE TABLE Dress (sizeB INT, sizeW INT, sizeH INT, color INT, productID INT REFERENCES Product(productID));
CREATE TABLE Suit  (sizeB INT, sizeW INT, sizeH INT, color INT, productID INT REFERENCES Product(productID));
-- jewelry: material at ordinal 4, so productID first
CREATE TABLE Bracelet (productID INT REFERENCES Product(productID), material INT);
CREATE TABLE Earrings (productID INT REFERENCES Product(productID), material INT);
CREATE TABLE Necklace (productID INT REFERENCES Product(productID), material INT);
CREATE TABLE Customer (personID INT IDENTITY(1,1) PRIMARY KEY, name NVARCHAR(100), password NVARCHAR(200), email NVARCHAR(100),
  address NVARCHAR(200), phone_number NVARCHAR(50), salt NVARCHAR(200), age INT, gender INT, orderID INT NULL);
CREATE TABLE Admin (personID INT IDENTITY(1,1) PRIMARY KEY, name NVARCHAR(100), password NVARCHAR(200), email NVARCHAR(100),
  address NVARCHAR(200), phone_number NVARCHAR(50), salt NVARCHAR(200));
CREATE TABLE Orders (orderID INT IDENTITY(1,1) PRIMARY KEY, total_price INT, personID INT, status INT);
CREATE TABLE OrderLine (orderID INT, productID INT, quantity INT, price INT);
CREATE TABLE ShoppingCart (personID INT, productID INT, quantity INT);
CREATE TABLE Review (personID INT, description NVARCHAR(1000));
GO
-- demo products
DECLARE @id INT;
INSERT INTO Product(quantity, price) VALUES (4, 120); SET @id = SCOPE_IDENTITY(); INSERT INTO Dress VALUES (86, 66, 92, 0, @id);
INSERT INTO Product(quantity, price) VALUES (3, 135); SET @id = SCOPE_IDENTITY(); INSERT INTO Dress VALUES (90, 70, 96, 1, @id);
INSERT INTO Product(quantity, price) VALUES (5, 110); SET @id = SCOPE_IDENTITY(); INSERT INTO Dress VALUES (82, 62, 88, 2, @id);
INSERT INTO Product(quantity, price) VALUES (4, 150); SET @id = SCOPE_IDENTITY(); INSERT INTO Suit VALUES (100, 84, 98, 0, @id);
INSERT INTO Product(quantity, price) VALUES (2, 160); SET @id = SCOPE_IDENTITY(); INSERT INTO Suit VALUES (104, 88, 102, 1, @id);
INSERT INTO Product(quantity, price) VALUES (3, 145); SET @id = SCOPE_IDENTITY(); INSERT INTO Suit VALUES (96, 80, 94, 2, @id);
INSERT INTO Product(quantity, price) VALUES (6, 45);  SET @id = SCOPE_IDENTITY(); INSERT INTO Bracelet VALUES (@id, 0);
INSERT INTO Product(quantity, price) VALUES (6, 30);  SET @id = SCOPE_IDENTITY(); INSERT INTO Bracelet VALUES (@id, 1);
INSERT INTO Product(quantity, price) VALUES (5, 55);  SET @id = SCOPE_IDENTITY(); INSERT INTO Earrings VALUES (@id, 0);
INSERT INTO Product(quantity, price) VALUES (5, 35);  SET @id = SCOPE_IDENTITY(); INSERT INTO Earrings VALUES (@id, 1);
INSERT INTO Product(quantity, price) VALUES (4, 70);  SET @id = SCOPE_IDENTITY(); INSERT INTO Necklace VALUES (@id, 0);
INSERT INTO Product(quantity, price) VALUES (4, 50);  SET @id = SCOPE_IDENTITY(); INSERT INTO Necklace VALUES (@id, 1);
GO
