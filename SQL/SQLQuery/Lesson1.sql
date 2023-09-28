Select concat(CustomerName,WebsiteURL) "Name and website"
FROM Sales.Customers;

Select CustomerName, PhoneNumber
FROM Sales.Customers;

select LEFT(CustomerName,1) "CustomerInitial", Count(CustomerID) as COUNT
from Sales.Customers
Group by LEFT(CustomerName, 1);

Select
    DATEPART(dw, o.OrderDate) as "DayOfWeek",
    DATEPART(WW, o.OrderDate) as "WEEK",
    Count(OrderID) as "NumberOfOrders"
From Sales.Orders o
Group By DATEPART(ww, o.OrderDate), DatePart(dw, o.OrderDate)
Order by 1,2;