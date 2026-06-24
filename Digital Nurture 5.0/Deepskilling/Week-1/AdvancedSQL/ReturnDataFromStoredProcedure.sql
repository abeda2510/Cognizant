CREATE PROCEDURE GetEmployeeById
    @EmpId INT
AS
BEGIN
    SELECT *
    FROM Employees
    WHERE EmployeeID = @EmpId;
END;