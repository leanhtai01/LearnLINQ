<Query Kind="Statements">
  <Connection>
    <ID>65cd4f87-17e0-4541-97a3-8e3314c204c5</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>E490WIN10</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAeNrCU2YgPUS4GE4tDFlwSAAAAAACAAAAAAAQZgAAAAEAACAAAABG+s7A5HU9AvPHwhTF2JC/BgJ5kVGoYS6ex41tAr/75gAAAAAOgAAAAAIAACAAAACxh/6XfXgpbeTzDegnuHtRI8P/92ASStOVVFXCs//r3hAAAACGtkZBkzBfo3jWrNxuKXQyQAAAAAstYGB1W4W729sCfUWm/L0et7ZcxEq1i8sYLcq2XLp2yOAmlDxK2mugIoo1uS/SmjOfUNsdD9a+db8QCu3Kar4=</Password>
    <Database>Northwind</Database>
  </Connection>
</Query>

// File: 1760169.linq
// ID: 1760169
// Name: Lê Anh Tài

// 1. Tìm tất cả các phần tử < 5 trong mảng các số nguyên
var querySyntax =
	from n in Enumerable.Range(-10, 10)
	where n < 5
	select n;
querySyntax.Dump();

var fluentSyntax = Enumerable.Range(-10, 10)
	.Where(n => n < 5);
fluentSyntax.Dump();

// 2. Tìm tất cả các sản phẩm đã hết hàng (Product[ProID, ProName, Price, Quantity])
var querySyntax =
	from p in Product
	where p.Quantity == 0
	select new { p.ProID, p.ProName, p.Price, p.Quantity };
querySyntax.Dump();

var fluentSyntax = Product
	.Where(p => p.Quantity == 0)
	.Select(p => new { p.ProID, p.ProName, p.Price, p.Quantity });
fluentSyntax.Dump();

// 3. Tìm tất cả các sản phẩm còn hàng và có giá < 100
var querySyntax =
	from p in Product
	where p.Quantity > 0 && p.Price < 100
	select new { p.ProID, p.ProName, p.Price, p.Quantity };
querySyntax.Dump();

var fluentSyntax = Product
	.Where(p => p.Quantity == 0 && p.Price < 100)
	.Select(p => new { p.ProID, p.ProName, p.Price, p.Quantity });

// 4. Cho mảng { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
// Tìm tất cả các số có số ký tự trong tên nhỏ hơn giá trị
var textNumbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var fluentSyntax = textNumbers
	.Select((text, index) => new {text, index})
	.Where(item => item.text.Count() < item.index);
fluentSyntax.Dump();

// 5. Cho mảng { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }. Hãy cho biết mỗi số có ở đúng vị trí nếu
// mảng được sắp xếp hay không (giá trị có bằng index hay không)
var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var fluentSyntax = numbers
	.Select((n, index) => new { n, index })
	.Where(item => item.n == item.index);
fluentSyntax.Dump();

// 6. Cho mảng { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
// Liệt kê các phần tử < 5 về giá trị
var textNumbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var fluentSyntax = textNumbers
	.Select((text, index) => new { text, index })
	.Where(item => item.index < 5);
fluentSyntax.Dump();

// 7. Cho mảng A: { 0, 2, 4, 5, 6, 8, 9 } và mảng B: { 1, 3, 5, 7, 8 }
// Liệt kê tất cả các cặp phần tử từ A < phần tử từ B
var numbersA = new int[] { 0, 2, 4, 5, 6, 8, 9 };
var numbersB = new int[] { 1, 3, 5, 7, 8 };
var querySyntax =
	from n1 in numbersA
	from n2 in numbersB
	where n1 < n2
	select new { n1, n2 };
querySyntax.Dump();

var fluentSyntax = numbersA
	.SelectMany(n1 => numbersB, (n1, n2) => new { n1, n2 })
	.Where (item => item.n1 < item.n2);
fluentSyntax.Dump();

// 8. Cho mảng { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }
// Hãy liệt kê theo nhóm các phần tử đồng dư với 5
var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var querySyntax =
	from n in numbers
	let r = n % 5
	group n by r;
querySyntax.Dump();

var fluentSyntax = numbers
	.GroupBy(n => n % 5);
fluentSyntax.Dump();

// 9. Cho mảng { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }
// Hãy liệt kê các phần tử theo nhóm chữ cái đầu
var words = new string[] { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };
var querySyntax =
	from w in words
	group w by w.Substring(0, 1);
querySyntax.Dump();

var fluentSyntax = words
	.GroupBy(w => w.Substring(0, 1));
fluentSyntax.Dump();

// 10. Cho mảng { "cherry", "apple", "blueberry" }
// Hãy sắp xếp theo alphabet
var fruits = new string[] { "cherry", "apple", "blueberry" };
var querySyntax =
	from f in fruits
	orderby f
	select f;
querySyntax.Dump();

var fluentSyntax = fruits
	.OrderBy(f => f);
fluentSyntax.Dump();

// 11. Với mảng { "cherry", "apple", "blueberry" }
// Hãy sắp xếp theo độ dài của chuỗi
var fruits = new string[] { "cherry", "apple", "blueberry" };
var querySyntax =
	from f in fruits
	orderby f.Length
	select f;
querySyntax.Dump();

var fluentSyntax = fruits
	.OrderBy(f => f.Length);
fluentSyntax.Dump();

// 12. Cho mảng { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" }
// Hãy sắp xếp theo alphabet không kể hoa thường
var words = new string[] { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var querySyntax =
	from w in words
	orderby w.ToLower()
	select w;
querySyntax.Dump();

var fluentSyntax = words
	.OrderBy(w => w.ToLower());
fluentSyntax.Dump();

// 13. Cho mảng { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }
// Hãy sắp xếp theo alphabet rồi sắp xếp theo độ dài chuỗi giảm dần
var textNumbers = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var querySyntax =
	from text in textNumbers
	orderby text, text.Length descending
	select text;
querySyntax.Dump();

var fluentSyntax = textNumbers
	.OrderBy(text => text)
	.ThenByDescending(text => text.Length);
fluentSyntax.Dump();

// 14. Cho mảng { "from  ", " salt", " earn", " last  ", " near", " form  " }
// Hãy gom nhóm các chuỗi giống nhau về ký tự
var words = new string[] { "from  ", " salt", " earn", " last  ", " near", " form  " };
var fluentSyntax = words
	.GroupBy(w => w.Trim().ToCharArray().ToHashSet(), HashSet<char>.CreateSetComparer());
fluentSyntax.Dump();

// 15. Hãy gom nhóm SinhVien[HoTen, NgaySinh] theo năm sinh và theo tháng sinh
var querySyntax =
	from s in SinhVien
	group s by new { s.NgaySinh.Year, s.NgaySinh.Month };
querySyntax.Dump();

var fluentSyntax = SinhVien
	.GroupBy(s => new { s.NgaySinh.Year, s.NgaySinh.Month });
fluentSyntax.Dump();