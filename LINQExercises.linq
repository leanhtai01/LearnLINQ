var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var words = new string[] { "aPPLE", "BlUeBeRrY", "cHeRry" };

// 1. Cho mảng: { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }. Tạo mảng mới sao cho mỗi
// phần tử đều lớn hơn 1 đơn vị với mảng đã cho ở vị trí tương ứng
var fluentSyntax1 = numbers.Select(n => n + 1);
var queryExp1 =
    from n in numbers
    select n + 1;
fluentSyntax1.Dump();
queryExp1.Dump();

// 2. Cho mảng: { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }. Hãy cho biết có bao nhiêu số lẻ
// trong mảng
var fluentSyntax2 = numbers.Where(n => n % 2 != 0).Count();
var queryExp2 =
        (from n in numbers
         where n % 2 != 0
         select n).Count();
fluentSyntax2.Dump();
queryExp2.Dump();

// 3. Cho mảng số: { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }. Hãy xuất mảng dưới
// dạng chuỗi (5 là "five", 6 là "six",...)
var fluentSyntax3 = numbers.Select(n => n switch
{
    0 => "zero",
    1 => "one",
    2 => "two",
    3 => "three",
    4 => "four",
    5 => "five",
    6 => "six",
    7 => "seven",
    8 => "eight",
    9 => "nine",
    _ => "unknow"
});
var queryExp3 =
    from n in numbers
    select n switch
    {
        0 => "zero",
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => "unknow"
    };
fluentSyntax3.Dump();
queryExp3.Dump();

// 4. Cho mảng: { "aPPLE", "BlUeBeRrY", "cHeRry" }. Hãy liệt kê mảng
// với kiểu viết HOA và thường.
var fluentSyntaxUpperWords = words.Select(w => w.ToUpper());
var fluentSyntaxLowerWords = words.Select(w => w.ToLower());
var queryExpUpperWords =
    from w in words
    select w.ToUpper();
var queryExpLowerWords =
    from w in words
    select w.ToLower();
fluentSyntaxUpperWords.Dump();
fluentSyntaxLowerWords.Dump();
queryExpUpperWords.Dump();
queryExpLowerWords.Dump();

// 5. Cho mảng: { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 }. Hãy xuất mảng dưới dạng chuỗi
// và đồng thời cho biết giá trị là chẵn hay lẻ.
var fluentSyntax5 = numbers.Select(n => n switch
{
    0 => "zero",
    1 => "one",
    2 => "two",
    3 => "three",
    4 => "four",
    5 => "five",
    6 => "six",
    7 => "seven",
    8 => "eight",
    9 => "nine",
    _ => "unknow"
} + ":" + n switch
{
    int a when a % 2 == 0 => "even",
    int a when a % 2 != 0 => "odd",
    _ => "unknow"
});
var queryExp5 =
    from n in numbers
    select n switch
    {
        0 => "zero",
        1 => "one",
        2 => "two",
        3 => "three",
        4 => "four",
        5 => "five",
        6 => "six",
        7 => "seven",
        8 => "eight",
        9 => "nine",
        _ => "unknow"
    } + ":" + n switch
    {
        int a when a % 2 == 0 => "even",
        int a when a % 2 != 0 => "odd",
        _ => "unknow"
    };
fluentSyntax5.Dump();
queryExp5.Dump();