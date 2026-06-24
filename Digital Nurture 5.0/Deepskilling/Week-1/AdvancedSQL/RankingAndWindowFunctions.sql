CREATE TABLE Employees (
    EmployeeID INT,
    EmployeeName VARCHAR(50),
    Salary INT
);

INSERT INTO Employees VALUES
(1,'Ashok',50000),
(2,'Ravi',60000),
(3,'Kiran',55000),
(4,'Rahul',70000);

SELECT EmployeeID,
       EmployeeName,
       Salary,
       RANK() OVER (ORDER BY Salary DESC) AS RankNo
FROM Employees;