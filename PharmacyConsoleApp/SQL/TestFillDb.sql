INSERT INTO [dbo].[Product] (Name, Cost) VALUES
('Аспирин', 123),
('Ношпа', 245);

INSERT INTO [dbo].[Pharmacy] (Name, Address, PhoneNumber) VALUES
('Живика', 'Ленина 5', '89542663012'),
('Аптека №1', 'Гоголя 34', '81234567899');

INSERT INTO [dbo].[Warehouse] (Name, PharmacyId) VALUES
('Склад 1', 1),
('Склад 1.2', 1),
('Склад 2', 2);

INSERT INTO [dbo].[Batch] (ProductId, WarehouseId, ProductCount) VALUES
(1, 1, 35),
(2, 1, 50),
(1, 2, 44);