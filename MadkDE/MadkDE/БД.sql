-- �������: ��� ���������
CREATE TABLE MaterialType (
    MaterialTypeID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    WastePercentage DECIMAL(5, 2) NOT NULL
);

-- �������: ��������
CREATE TABLE Material (
    MaterialID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    MaterialTypeID INT NOT NULL FOREIGN KEY REFERENCES MaterialType(MaterialTypeID),
    UnitPrice DECIMAL(10, 2) NOT NULL,
    QuantityInStock DECIMAL(10, 2) NOT NULL,
    MinQuantity DECIMAL(10, 2) NOT NULL,
    QuantityPerPackage INT NOT NULL,
    Unit NVARCHAR(20) NOT NULL
);

-- �������: ���������
CREATE TABLE Supplier (
    SupplierID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(150) NOT NULL,
    SupplierType NVARCHAR(50) NOT NULL,
    INN VARCHAR(12) NOT NULL UNIQUE,
    Rating INT CHECK (Rating BETWEEN 1 AND 10),
    StartDate DATE NOT NULL
);

-- ��������� �������: ��������-���������
CREATE TABLE MaterialSupplier (
    MaterialID INT FOREIGN KEY REFERENCES Material(MaterialID),
    SupplierID INT FOREIGN KEY REFERENCES Supplier(SupplierID),
    PRIMARY KEY (MaterialID, SupplierID)
);

-- �������: ��� ���������
CREATE TABLE ProductType (
    ProductTypeID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Coefficient DECIMAL(5, 2) NOT NULL
);

-- �������: ������������
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL, -- ����� �������� ��� ������
    Role NVARCHAR(50) NOT NULL CHECK (Role IN ('�������������', '������������'))
);
