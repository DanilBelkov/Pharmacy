INSERT INTO [dbo].[Product] (Name, Cost) VALUES
('�������', 123),
('�����', 245);

INSERT INTO [dbo].[Pharmacy] (Name, Address, PhoneNumber) VALUES
('������', '������ 5', '89542663012'),
('������ �1', '������ 34', '81234567899');

INSERT INTO [dbo].[Warehouse] (Name, PharmacyId) VALUES
('����� 1', 1),
('����� 1.2', 1),
('����� 2', 2);

INSERT INTO [dbo].[Batch] (ProductId, WarehouseId, ProductCount) VALUES
(1, 1, 35),
(2, 1, 50),
(1, 2, 44);