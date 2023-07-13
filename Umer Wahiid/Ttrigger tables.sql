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


CREATE TABLE Employees_4 (
    EmployeeID INT ,
    EmployeeName VARCHAR(50),
    Salary Int,
    ManagerID Int,
	FOREIGN KEY (ManagerID) REFERENCES Manager(ManagerID)
);


--Cursor
DECLARE ECursor cursor scroll for select * from Employees_4
open ECursor
fetch first from ECursor
fetch next from ECursor
fetch last from ECursor
fetch prior from ECursor
fetch absolute 3 from ECursor
fetch relative 2 from ECursor
close ECursor
deallocate ECursor


DECLARE ECursor cursor scroll for select EmployeeID,EmployeeName from Employees_4
Declare @emp_id int, @emp_name varchar(50)
open ECursor

fetch first from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' '+ @emp_name

fetch next from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' ' + @emp_name

fetch last from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' ' + @emp_name

fetch prior from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' ' + @emp_name

fetch absolute 3 from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' ' + @emp_name

fetch relative 2 from ECursor into @emp_id,@emp_name
print 'Employee is: ' + cast(@emp_id as varchar(50))+' ' + @emp_name

close ECursor
deallocate ECursor





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












--CTE

With Emp_CTE
as
(
	select * from Employees_4 where Salary<4000
)
--select count(*) from Emp_CTE
insert Emp_CTE values('Hammad',23123123)



With Emp_CTE(emp_id, emp_name,emp_salary)
as
(
	select EmployeeID,EmployeeName, Salary from Employees_4 where Salary<4000
)
--select count(*) from Emp_CTE
Select emp_id,emp_name from Emp_CTE




WITH EmployeeCTE (EmployeeID, EmployeeName, Salary, ManagerID)
AS
(
    SELECT EmployeeID, EmployeeName, Salary, ManagerID
    FROM Employees_4
)
SELECT E.EmployeeName AS Info, M.EmployeeName AS ManagerName
FROM EmployeeCTE E
LEFT JOIN EmployeeCTE M ON E.ManagerID = M.EmployeeID;







--Pivot
Insert Into Employees_4(EmployeeName,Salary,ManagerID)
Values('Asif',89000,3),
('Adil',70000,2),
('Asad',29000,1),
('Arham',95000,2),
('Asif',20000,1);

SELECT *
FROM (
    SELECT EmployeeName, Salary, ManagerID
    FROM Employees_4
) AS EmployeeData
PIVOT (
    Max(Salary)
    FOR EmployeeName IN ([Asif], [Adil], [Asad])
) AS PivotTable;