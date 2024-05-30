use master
use DiamondStore
-- Insert data into Tbl_MaterialCategory
INSERT INTO Tbl_MaterialCategory (MaterialID, MaterialName) VALUES
('MT0001', 'Gold'),
('MT0002', 'Silver'),
('MT0003', 'Platinum'),
('MT0004', 'Titanium'),
('MT0005', 'Palladium');

-- Insert data into Tbl_MaterialPriceList
INSERT INTO Tbl_MaterialPriceList (MaterialID, UnitPrice, EffDate) VALUES
('MT0001', 58.50, '2024-01-01'),
('MT0002', 0.75, '2024-01-01'),
('MT0003', 31.20, '2024-01-01'),
('MT0004', 14.00, '2024-01-01'),
('MT0005', 45.00, '2024-01-01');

-- Insert data into Tbl_GemPriceList
INSERT INTO Tbl_GemPriceList (GemID, GemCode, Polish, Symmetry, Fluorescence, Origin, CaratWeight, Color, Cut, Clarity, Shape, Price, EffDate) VALUES
('GM0001', 'GEM001', 'Excellent', 'Very Good', 'None', 'Africa', 1.0, 'D', 'Round', 'IF', 'Round', 10000.00, '2024-01-01'),
('GM0002', 'GEM002', 'Very Good', 'Good', 'Faint', 'Australia', 0.5, 'E', 'Oval', 'VVS1', 'Oval', 5000.00, '2024-01-01'),
('GM0003', 'GEM003', 'Good', 'Fair', 'Medium', 'Brazil', 1.5, 'F', 'Princess', 'VS1', 'Princess', 15000.00, '2024-01-01'),
('GM0004', 'GEM004', 'Fair', 'Poor', 'Strong', 'Russia', 2.0, 'G', 'Cushion', 'SI1', 'Cushion', 20000.00, '2024-01-01'),
('GM0005', 'GEM005', 'Excellent', 'Excellent', 'None', 'Canada', 0.75, 'H', 'Emerald', 'SI2', 'Emerald', 7500.00, '2024-01-01');

-- Insert data into Tbl_ProductCategory
INSERT INTO Tbl_ProductCategory (CategoryID, CategoryName) VALUES
('PC0001', 'Ring'),
('PC0002', 'Necklace'),
('PC0003', 'Earrings'),
('PC0004', 'Bracelet'),
('PC0005', 'Pendant');

-- Insert data into Tbl_Account
INSERT INTO Tbl_Account (AccountID, Username, Password, Role) VALUES
('AC0001', 'john_doe', 'password123', 'Customer'),
('AC0002', 'jane_smith', 'password456', 'Staff'),
('AC0003', 'robert_brown', 'password789', 'Customer'),
('AC0004', 'lucy_white', 'password101', 'Staff'),
('AC0005', 'michael_green', 'password102', 'Customer');

-- Insert data into Tbl_Staff
INSERT INTO Tbl_Staff (StaffID, AccountID, FirstName, LastName) VALUES
('ST0001', 'AC0002', 'Jane', 'Smith'),
('ST0002', 'AC0004', 'Lucy', 'White');

-- Insert data into Tbl_Customer
INSERT INTO Tbl_Customer (CustomerID, AccountID, FirstName, LastName, Gender, Birthday, Email, PhoneNumber, Address, Spending, Status) VALUES
('CU0001', 'AC0001', 'John', 'Doe', 'Male', '1990-05-15', 'john.doe@example.com', '0912345678', '123 Main St', 1000.00, 1),
('CU0002', 'AC0003', 'Robert', 'Brown', 'Male', '1985-08-20', 'robert.brown@example.com', '0923456789', '456 Oak St', 500.00, 1),
('CU0003', NULL, 'Emily', 'Davis', 'Female', '1992-11-30', 'emily.davis@example.com', '0934567890', '789 Pine St', 1500.00, 1),
('CU0004', 'AC0005', 'Michael', 'Green', 'Male', '1988-02-25', 'michael.green@example.com', '0945678901', '101 Maple St', 2000.00, 1),
('CU0005', NULL, 'Sarah', 'Johnson', 'Female', '1995-07-10', 'sarah.johnson@example.com', '0956789012', '202 Birch St', 2500.00, 0);

-- Insert data into Tbl_Membership
INSERT INTO Tbl_Membership (MinSpend, MaxSpend, DiscountRate, Ranking) VALUES
(0, 499.99, 0, 'Bronze'),
(500, 999.99, 5, 'Silver'),
(1000, 1999.99, 10, 'Gold'),
(2000, 2999.99, 15, 'Platinum'),
(3000, 10000, 20, 'Diamond');

-- Insert data into Tbl_Product
INSERT INTO Tbl_Product (ProductID, ProductName, ProductCode, Description, CategoryID, MaterialCost, ProductionCost, PriceRate, ProductSize, PriceSize, GemID, Image, Status) VALUES
('PD0001', 'Diamond Ring', 'P001', 'A beautiful diamond ring', 'PC0001', 500.00, 200.00, 1.5, 7, 10000000, 'GM0001', 'ring1.jpg', 1),
('PD0002', 'Gold Necklace', 'P002', 'A shiny gold necklace', 'PC0002', 300.00, 100.00, 1.4, 18, 25600000, 'GM0002', 'necklace1.jpg', 1),
('PD0003', 'Silver Earrings', 'P003', 'Elegant silver earrings', 'PC0003', 100.00, 50.00, 1.3, 5, 32000000, 'GM0004', 'earrings1.jpg', 1),
('PD0004', 'Platinum Bracelet', 'P004', 'Luxurious platinum bracelet', 'PC0004', 700.00, 300.00, 1.6, 8, '7200000', 'GM0003', 'bracelet1.jpg', 1),
('PD0005', 'Titanium Pendant', 'P005', 'Durable titanium pendant', 'PC0005', 200.00, 80.00, 1.2, 10, 9680000, 'GM0005', 'pendant1.jpg', 1);

-- Insert data into Tbl_ProductMaterial
INSERT INTO Tbl_ProductMaterial (ProductID, MaterialID, Weight) VALUES
('PD0001', 'MT0001', 3.5),
('PD0002', 'MT0005', 5.0),
('PD0003', 'MT0002', 2.5),
('PD0004', 'MT0003', 4.0),
('PD0005', 'MT0004', 3.0);

-- Insert data into Tbl_Order
INSERT INTO Tbl_Order (OrderID, CustomerID, OrderDate, PaymentMethod, OrderStatus, ShippingDate, ReceiveDate, StaffID, ShipperID) VALUES
('OD0001', 'CU0001', '2024-04-01', 'Credit Card', 'Shipped', '2024-04-02', '2024-04-05', 'ST0001', 'SP0001'),
('OD0002', 'CU0002', '2024-04-03', 'PayPal', 'Processing', NULL, NULL, 'ST0001', 'SP0002'),
('OD0003', 'CU0003', '2024-04-05', 'Cash', 'Delivered', '2024-04-06', '2024-04-08', 'ST0002', 'SP0003'),
('OD0004', 'CU0004', '2024-04-07', 'Bank Transfer', 'Cancelled', NULL, NULL, 'ST0002', 'SP0004'),
('OD0005', 'CU0005', '2024-04-09', 'Credit Card', 'Pending', NULL, NULL, 'ST0001', 'SP0001');

-- Insert data into Tbl_OrderDetail
INSERT INTO Tbl_OrderDetail (OrderDetailID, OrderID, ProductID, CustomizedSize, CustomizedAmount, Quantity, TotalPrice, FinalPrice) VALUES
('ODT0001', 'OD0001', 'PD0001', 7, 0, 1, 1500.00, 1500.00),
('ODT0002', 'OD0002', 'PD0002', 18, 0, 1, 1400.00, 1400.00),
('ODT0003', 'OD0003', 'PD0003', 5, 0, 1, 130.00, 130.00),
('ODT0004', 'OD0004', 'PD0004', 8, 0, 1, 1600.00, 1600.00),
('ODT0005', 'OD0005', 'PD0005', 10, 0, 1, 120.00, 120.00);

-- Insert data into Tbl_Payment
INSERT INTO Tbl_Payment (OrderID, CustomerID, PaymentMethod, Deposits, PayDetail) VALUES
('OD0001', 'CU0001', 'Credit Card', 500.00, 'Paid full amount on 2024-04-01'),
('OD0002', 'CU0002', 'PayPal', 200.00, 'Initial deposit made on 2024-04-03'),
('OD0003', 'CU0003', 'Cash', 130.00, 'Paid full amount on delivery'),
('OD0004', 'CU0004', 'Bank Transfer', 0.00, 'Order cancelled'),
('OD0005', 'CU0005', 'Credit Card', 60.00, 'Pending full payment');

-- Insert data into Tbl_Warranty
INSERT INTO Tbl_Warranty (WarrantyID, OrderDetailID, WarrantyStartDate, WarrantyEndDate) VALUES
('WR0001', 'ODT0001', '2024-04-05', '2025-04-05'),
('WR0002', 'ODT0002', '2024-04-10', '2025-04-10'),
('WR0003', 'ODT0003', '2024-04-12', '2025-04-12'),
('WR0004', 'ODT0004', '2024-04-15', '2025-04-15'),
('WR0005', 'ODT0005', '2024-04-18', '2025-04-18');

-- Insert data into Tbl_DiamondGradingReport
INSERT INTO Tbl_DiamondGradingReport (ReportID, GemID, GenerateDate, Image) VALUES
('RP0001', 'GM0001', '2024-01-01', 'report1.jpg'),
('RP0002', 'GM0002', '2024-01-01', 'report2.jpg'),
('RP0003', 'GM0003', '2024-01-01', 'report3.jpg'),
('RP0004', 'GM0004', '2024-01-01', 'report4.jpg'),
('RP0005', 'GM0005', '2024-01-01', 'report5.jpg');
