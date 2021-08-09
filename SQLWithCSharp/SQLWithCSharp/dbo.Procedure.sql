CREATE PROCEDURE [dbo].[UpdateCustomer]
@ID nchar(5),
@NewName nvarchar(40)
AS
UPDATE Customers
SET ContactName = @NewName
WHERE CustomerID = @ID

RETURN 0
