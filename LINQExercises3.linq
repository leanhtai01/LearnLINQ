// 1. Với database Northwind. Hãy liệt kê tất cả các Product
var querySyntax =
    from p in Products
    select p;
querySyntax.Dump();

// 2. Với database Northwind. Hãy liệt kê tất cả các Product
// theo nhóm Categories
var querySyntax =
    from p in Products
    group p by p.CategoryID;
querySyntax.Dump();

// 3. Với database Northwind. Hãy nhóm các đơn hàng của khách hàng
// theo năm và theo tháng.
var querySyntax =
    from o in Orders
    group o by new {o.OrderDate.Value.Year, o.OrderDate.Value.Month};
querySyntax.Dump();

// 4. Với database Northwind. Tìm tất cả các đơn hàng có tổng giá
// trị nhỏ hơn 500 triệu
var query =
    (from od in OrderDetails
    group od by od.OrderID into OrderGroup
    select new
    {
        OrderID = OrderGroup.Key,
        TotalPrice = OrderGroup.Sum(og => (double)og.UnitPrice * (1 - og.Discount) * og.Quantity)
    }).Where(o => o.TotalPrice < 500);
query.Dump();

// 5. Với database Northwind. Tìm tất cả các đơn hàng được lập sau năm 1997
var querySyntax =
    from o in Orders
    where o.OrderDate.Value.Year > 1997
    select o;
querySyntax.Dump();

// 6. Với database Northwind. Tìm tất cả các đơn hàng có tổng
// giá trị lớn hơn 600 triệu và được khách hàng từ USA đặt
var query =
    (from orderdetail in OrderDetails
    join order in Orders on orderdetail.OrderID equals order.OrderID
    join customer in Customers on order.CustomerID equals customer.CustomerID
    where customer.Country == "USA"
    group orderdetail by orderdetail.OrderID into OrderGroup
    select new
    {
        OrderID = OrderGroup.Key,
        TotalPrice = OrderGroup.Sum(ordergroup => (double)ordergroup.UnitPrice * (1 - ordergroup.Discount) * ordergroup.Quantity)
    })
    .Where(order => order.TotalPrice > 600);
query.Dump();

// 7. Với database Northwin, hãy tìm các Category có ít nhất 1 Product hết hàng.
var query =
    from product in Products
    where product.UnitsInStock == 0
    group product by product.CategoryID into ProductGroup
    select new { CategoryID = ProductGroup.Key };
query.Dump();

// 8. Với database Northwind, hãy tìm các Category không có Product nào hết hàng
var query =
	from product in Products
	group product by product.CategoryID into ProductGroup
	where !ProductGroup.Any(product => product.UnitsInStock == 0)
	select ProductGroup;
query.Dump();

// 9. Với database Northwind, hãy cho biết số lượng đặt hàng của mỗi khách hàng.
var query =
	from customer in Customers
	join order in Orders on customer.CustomerID equals order.CustomerID
	group customer by customer.CustomerID into CustomerGroup
	select new
	{
		CustomerID = CustomerGroup.Key,
		TotalOrders = CustomerGroup.Count()
	};
query.Dump();

// 10. Với database Northwind, hãy cho biết số lượng sản phẩm trong mỗi danh mục.
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group category by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		Products = CategoryGroup.Count()
	};
query.Dump();

// 11. Với database Northwind, hãy cho biết tổng số lượng sản phẩm trong mỗi
// danh mục
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		TotalProductsInCategory = CategoryGroup.Sum(categorygroup => categorygroup.product.UnitsInStock)
	};
query.Dump();

// 12. Với database Northwind, hãy cho biết giá rẻ nhất trong mỗi danh mục.
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		MinPrice = CategoryGroup.Min(categorygroup => categorygroup.product.UnitPrice)
	};
query.Dump();

// 13. Với database Northwind, hãy cho biết sản phẩm rẻ nhất trong mỗi danh mục
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		ProductName =
			(from categorygroup in CategoryGroup
			orderby categorygroup.product.UnitPrice
			select categorygroup.product.ProductName)
			.First(),
		MinPrice = CategoryGroup.Min(categorygroup => categorygroup.product.UnitPrice)
	};
query.Dump();

// 14. Với database Northwind, hãy cho biết giá đắt nhất trong mỗi danh mục.
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		MaxPrice = CategoryGroup.Max(categorygroup => categorygroup.product.UnitPrice)
	};
query.Dump();

// 15. Với database Northwind, hãy cho biết sản phẩm đắt nhất trong mỗi danh mục
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		ProductName =
			(from categorygroup in CategoryGroup
			orderby categorygroup.product.UnitPrice descending
			select categorygroup.product.ProductName)
			.First(),
		MaxPrice = CategoryGroup.Max(categorygroup => categorygroup.product.UnitPrice)
	};
query.Dump();

// 16. Với database Northwind, hãy cho biết mức giá trung bình của sản phẩm
// trong mỗi danh mục
var query =
	from category in Categories
	join product in Products on category.CategoryID equals product.CategoryID
	group new { category, product } by category.CategoryID into CategoryGroup
	select new
	{
		CategoryID = CategoryGroup.Key,
		AvgPrice = CategoryGroup.Average(categorygroup => categorygroup.product.UnitPrice)
	};
query.Dump();