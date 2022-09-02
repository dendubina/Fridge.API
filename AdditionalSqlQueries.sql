--Fridge name starts with A
SELECT
(Fridges.Name + ' ' + FridgeModels.Name) AS FridgeName,
Products.Name AS ProductName,
FridgeProducts.Quantity
FROM Fridges
	JOIN FridgeModels ON Fridges.FridgeModelId = FridgeModels.Id
	JOIN FridgeProducts ON FridgeProducts.FridgeId = Fridges.Id
	JOIN Products ON FridgeProducts.ProductId = Products.Id
WHERE Fridges.Name LIKE 'a%'

--Ñontaining products that quantity is more than default
SELECT DISTINCT
Fridges.Id,
(Fridges.Name + ' ' + FridgeModels.Name) AS FridgeName
FROM Fridges
	JOIN FridgeModels ON FridgeModels.Id = Fridges.FridgeModelId
	JOIN FridgeProducts ON FridgeId = Fridges.Id
	JOIN Products ON Products.Id = FridgeProducts.ProductId
WHERE FridgeProducts.Quantity < Products.DefaultQuantity

--Year of most capacious model
SELECT TOP 1
FridgeModels.Year 
FROM Fridges
	JOIN FridgeModels ON FridgeModels.Id = Fridges.FridgeModelId
	JOIN FridgeProducts ON FridgeId = Fridges.Id
	JOIN Products ON Products.Id = FridgeProducts.ProductId
GROUP BY FridgeModels.Year
ORDER BY SUM (FridgeProducts.Quantity) DESC


--Products for fridge with specified id
SELECT
Products.Name AS ProductName,
FridgeProducts.Quantity
FROM FridgeProducts
	JOIN Products ON FridgeProducts.ProductId = Products.Id
WHERE FridgeProducts.FridgeId = '6D4A1831-0793-4282-AD4C-3F023B60A3B9'


--Name, Model and year with sum of products	
SELECT
(Fridges.Name + ' ' + FridgeModels.Name) AS FridgeName,
FridgeModels.Year,
SUM(FridgeProducts.Quantity) AS ProductsSum 
FROM FridgeProducts	
	 JOIN Fridges ON FridgeProducts.FridgeId = Fridges.Id
	 JOIN FridgeModels ON FridgeModels.Id = Fridges.FridgeModelId
GROUP BY (Fridges.Name + ' ' + FridgeModels.Name), FridgeModels.Year


-- Ñontaining products that quantity is more than default
SELECT
Fridges.Id,
Fridges.Name
FROM FridgeProducts
	JOIN Fridges ON Fridges.Id = FridgeProducts.FridgeId
	JOIN Products ON FridgeProducts.ProductId = Products.Id
WHERE FridgeProducts.Quantity > Products.DefaultQuantity
GROUP BY Fridges.Id, Fridges.Name

--Ñontaining products that quantity is more than default with count
SELECT
FridgeId,
Fridges.Name,
COUNT(*)
FROM FridgeProducts
	JOIN Products ON FridgeProducts.ProductId = Products.Id
	JOIN Fridges ON FridgeProducts.FridgeId = Fridges.Id
WHERE Quantity > Products.DefaultQuantity
GROUP BY fridgeid, fridges.Name
