SELECT p.ProductName, pcc.CategoryName FROM Product as p
LEFT JOIN (SELECT pc.ProductId as pId, c.CategoryName FROM ProductCategory as pc
INNER JOIN Category as c
ON pc.CategoryId = c.Id) as pcc
on pcc.pId = p.Id
