-- Barangay Equipment Borrowing System
-- Database Schema for MS Access
-- Run each CREATE TABLE statement separately in Access

-- Equipment Master Table
CREATE TABLE Equipment (
    EquipmentID AUTOINCREMENT PRIMARY KEY,
    ItemName TEXT(100) NOT NULL,
    Category TEXT(50),
    Description MEMO,
    Stock INTEGER,
    Unit TEXT(20),
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

-- Borrowers Master Table
CREATE TABLE Borrowers (
    BorrowerID AUTOINCREMENT PRIMARY KEY,
    FullName TEXT(100) NOT NULL,
    ContactNo TEXT(20),
    Address TEXT(200),
    Email TEXT(100),
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

-- Borrowings Transaction Header Table
CREATE TABLE Borrowings (
    BorrowingID AUTOINCREMENT PRIMARY KEY,
    BorrowerID INTEGER NOT NULL,
    BorrowDate DATETIME NOT NULL,
    ExpectedReturnDate DATETIME,
    ActualReturnDate DATETIME,
    Status TEXT(20),
    Notes MEMO,
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

-- Borrowing Items Transaction Detail Table
CREATE TABLE BorrowingItems (
    BorrowingItemID AUTOINCREMENT PRIMARY KEY,
    BorrowingID INTEGER NOT NULL,
    EquipmentID INTEGER NOT NULL,
    Quantity INTEGER NOT NULL,
    ReturnedQuantity INTEGER,
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

-- Create Foreign Key Relationships (run these separately)
-- Note: In Access, foreign keys are created through Relationships window
-- Or use ALTER TABLE statements:

ALTER TABLE Borrowings 
ADD CONSTRAINT FK_Borrowings_Borrowers 
FOREIGN KEY (BorrowerID) REFERENCES Borrowers(BorrowerID);

ALTER TABLE BorrowingItems 
ADD CONSTRAINT FK_BorrowingItems_Borrowings 
FOREIGN KEY (BorrowingID) REFERENCES Borrowings(BorrowingID);

ALTER TABLE BorrowingItems 
ADD CONSTRAINT FK_BorrowingItems_Equipment 
FOREIGN KEY (EquipmentID) REFERENCES Equipment(EquipmentID);

-- Create Indexes for better performance
CREATE INDEX idx_Equipment_ItemName ON Equipment(ItemName);
CREATE INDEX idx_Equipment_Category ON Equipment(Category);
CREATE INDEX idx_Borrowers_FullName ON Borrowers(FullName);
CREATE INDEX idx_Borrowings_BorrowerID ON Borrowings(BorrowerID);
CREATE INDEX idx_Borrowings_BorrowDate ON Borrowings(BorrowDate);
CREATE INDEX idx_Borrowings_Status ON Borrowings(Status);
CREATE INDEX idx_BorrowingItems_BorrowingID ON BorrowingItems(BorrowingID);
CREATE INDEX idx_BorrowingItems_EquipmentID ON BorrowingItems(EquipmentID);
