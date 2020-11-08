// a. Liệt kê tất cả các số có chữ số tận cùng là 5 và không lớn hơn 1000001.
var queryExpressionA = from n in Enumerable.Range(0, 1000002)
                       where n % 10 == 5
                       select n;
queryExpressionA.Dump();

// b. Liệt kê tất cả các số nguyên tố nhỏ hơn 1000001
var fluentSyntaxB = Enumerable.Range(0, 1000002)
    .Where(n =>
    {
        bool result = true;

        if (n <= 3)
        {
            result = n > 1;
        }
        else if (n % 2 == 0 || n % 3 == 0)
        {
            result = false;
        }
        else
        {
            int i = 5;

            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    result = false;
                }

                i += 6;
            }
        }

        return result;
    });
fluentSyntaxB.Dump();

// c. Liệt kê tất cả các số có ít nhất 3 chữ số 7 và nhỏ hơn 1000001.
var fluentSyntaxC = Enumerable.Range(0, 1000002)
    .Where(n =>
    {
        int count = 0;

        while (n > 0)
        {
            if (n % 10 == 7)
            {
                count++;
            }

            n /= 10;
        }

        return count >= 3;
    });
fluentSyntaxC.Dump();

// d. Liệt kê tất cả các số hoàn chỉnh nhỏ hơn 1000001.
var fluentSyntaxD = Enumerable.Range(0, 1000002)
    .Where(n =>
    {
        int sum = 1;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                sum += i + n / i;
            }
        }

        return sum == n;
    });
fluentSyntaxD.Dump();

// e. Liệt kê tất cả các số chính phương nhỏ hơn 1000001
var fluentSyntaxE = Enumerable.Range(0, 1000002)
    .Where(n => Math.Sqrt(n) - Math.Floor(Math.Sqrt(n)) == 0);
fluentSyntaxE.Dump();