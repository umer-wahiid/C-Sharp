use Employee_DB

-- Declare variables
DECLARE @EmpID INT, @EmpName VARCHAR(50);

-- Initialize variables
SELECT TOP 1 @EmpID = EmployeeID,
@EmpName = EmployeeName

FROM Employees;

-- Loop through the records
WHILE @EmpID IS NOT NULL
BEGIN
    -- Insert data into the destination table
    INSERT INTO Employees_2(EmployeeID, EmployeeName)
    VALUES (@EmpID, @EmpName);

    -- Get the next record
    SELECT TOP 1 @EmpID = EmployeeID, @EmpID = EmployeeName
    FROM Employees
    WHERE EmployeeID > @EmpID
    ORDER BY EmployeeID;

END;