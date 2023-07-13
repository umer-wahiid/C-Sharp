CREATE TRIGGER AuditEmployeeChanges
ON Employees
AFTER UPDATE, DELETE
AS
BEGIN
    DECLARE @action VARCHAR(20);
    
    IF EXISTS (SELECT * FROM deleted)
    BEGIN
        -- Delete operation
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