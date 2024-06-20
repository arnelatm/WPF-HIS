INSERT INTO Contact (PayeeIdNo, PayeeType)
SELECT IdNo,'E' from Employee
INSERT INTO Contact (PayeeIdNo, PayeeType)
SELECT IdNo,'C' from Customer
INSERT INTO Contact (PayeeIdNo, PayeeType)
SELECT IdNo,'S' from Supplier
