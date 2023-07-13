Create Database Employee_DB
use Employee_DB;


CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50),
    Salary DECIMAL(10, 2)
);


CREATE TABLE EmployeeAudit (
    AuditID INT PRIMARY KEY IDENTITY,
    EmployeeID INT,
    Action VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);


CREATE TRIGGER AuditEmployeeChanges
ON Employees
AFTER UPDATE, DELETE
AS
BEGIN
    DECLARE @action VARCHAR(20);
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        SET @action = 'Other Change';
        IF EXISTS (SELECT * FROM inserted WHERE EmployeeID = (SELECT EmployeeID FROM deleted))
        BEGIN
            SET @action = 'Name Changed';
            IF EXISTS (SELECT * FROM inserted WHERE EmployeeID = (SELECT EmployeeID FROM deleted) AND Salary <> (SELECT Salary FROM deleted))
            BEGIN
                SET @action = 'Salary Changed';
            END;
        END;
        INSERT INTO EmployeeAudit (EmployeeID, Action)
        SELECT EmployeeID, @action FROM deleted;
    END;
END;



UPDATE Employees
SET Salary = 10000
WHERE EmployeeID = 1;



CREATE TABLE #TempEmployees (
    EmployeeID INT,
    EmployeeName VARCHAR(100),
    Salary int
);

CREATE FUNCTION dbo.GetInformation(@name VARCHAR(50), @salary int)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @Info VARCHAR(100);
    SET @Info = @name + ' gets ' + @salary;
    RETURN @Info;
END;


Select EmployeeName,Salary, dbo.GetInformation(EmployeeName,Salary) As Info From Employees;



Create Procedure SP_Update
@n varchar(20),
@id int
As 
Update Employees Set EmployeeName=@n where EmployeeID=@id;




Create Procedure SP_Delete
@id int
As 
Delete from Employees where EmployeeID=@id;


Truncate Table Employee;

CREATE TABLE Employees_2 (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50)
);


CREATE TABLE Employees_3 (
    EmployeeID INT ,
    EmployeeName VARCHAR(50)
);

CREATE TABLE Manager (
    ManagerID INT Primary Key,
    ManagerName VARCHAR(50)
);







DECLARE @EmpID INT, @EmpName VARCHAR(50);
SELECT TOP 1 @EmpID = EmployeeID,
@EmpName = EmployeeName
FROM Employees;
WHILE @EmpID IS NOT NULL
BEGIN
    INSERT INTO Employees_2(EmployeeID, EmployeeName)
    VALUES (@EmpID, @EmpName);
    SELECT TOP 1 @EmpID = EmployeeID, @EmpID = EmployeeName
    FROM Employees
    WHERE EmployeeID > @EmpID
    ORDER BY EmployeeID;
END;










DECLARE @EmpCursor CURSOR;
DECLARE @EmplID INT, @EmplName VARCHAR(50);
SET @EmpCursor = CURSOR FOR
    SELECT EmployeeID, EmployeeName
    FROM Employees;
OPEN @EmpCursor;
FETCH NEXT FROM @EmpCursor INTO @EmplID, @EmplName;
WHILE @@FETCH_STATUS = 0
BEGIN
    INSERT INTO Employees_3 (EmployeeID, EmployeeName)
    VALUES (@EmplID, @EmplName);
    FETCH NEXT FROM @EmpCursor INTO @EmplID, @EmplName;
END;
CLOSE @EmpCursor;
DEALLOCATE @EmpCursor;


SELECT EmployeeName
FROM Employees
WHERE EmployeeID IN (SELECT EmployeeID FROM Employees_2 where EmployeeID=1);




CREATE TABLE Employees_4 (
    EmployeeID INT ,
    EmployeeName VARCHAR(50),
    Salary Int,
    ManagerID Int,
	FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);


WITH EmployeeCTE (EmployeeID, EmployeeName, Salary, ManagerID)
AS
(
    SELECT EmployeeID, EmployeeName, Salary, ManagerID
    FROM Employees_4
)
SELECT E.EmployeeName AS Info, M.EmployeeName AS ManagerName
FROM EmployeeCTE E
LEFT JOIN EmployeeCTE M ON E.ManagerID = M.EmployeeID;




