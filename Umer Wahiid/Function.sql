CREATE FUNCTION dbo.GetInformation(@name VARCHAR(50), @salary int)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @Info VARCHAR(100);
    SET @Info = @name + ' gets ' + @salary;
    RETURN @Info;
END;

