--Change zero quantity from task 6
CREATE PROC ChangeZeroQuantity
AS 
DECLARE @contentType NVARCHAR(20) = 'application/json';
DECLARE @postData NVARCHAR(1000);
DECLARE @ret INT;
DECLARE @token INT;
DECLARE @url NVARCHAR(100);

DECLARE @tempTableId INT;
DECLARE @FridgeId NVARCHAR(50);
DECLARE @ProductId NVARCHAR(50);
DECLARE @Quantity INT;

CREATE TABLE #TempTable(
Id INT IDENTITY,
FridgeId NVARCHAR(50),
ProductId NVARCHAR(50),
Quantity INT
)

INSERT INTO #TempTable (FridgeId, ProductId, Quantity)
SELECT
FridgeId,
Products.Id as ProductId,
DefaultQuantity as Quantity
FROM FridgeProducts
	JOIN Products ON ProductId = Products.Id
WHERE Quantity = 0 AND ProductId = Products.Id

EXEC @ret = sp_OACreate 'MSXML2.ServerXMLHTTP', @token OUT;

SELECT TOP 1 @tempTableId = Id, @FridgeId = FridgeId, @ProductId = ProductId, @Quantity = Quantity
FROM #TempTable

WHILE(@@ROWCOUNT > 0)
BEGIN
	SET @url = 'https://localhost:5001/api/fridges/'+ @FridgeId + '/products'

	SET @postData = '{"ProductId": "' + @ProductId + '",' +
					 '"Quantity": "' + CONVERT(NVARCHAR, @Quantity) + '"}'	

	EXEC @ret = sp_OAMethod @token, 'open', NULL, 'PUT', @url, 'false';
	EXEC @ret = sp_OAMethod @token, 'setRequestHeader', NULL, 'Content-type', @contentType;

	EXEC @ret = sp_OAMethod @token, 'send', NULL, @postData

	DELETE FROM #TempTable WHERE Id=@tempTableId

	SELECT TOP 1 @tempTableId = Id, @FridgeId = FridgeId, @ProductId = ProductId, @Quantity = Quantity
	FROM #TempTable
END

DROP TABLE #TempTable

EXEC @ret = sp_OADestroy @token;


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
