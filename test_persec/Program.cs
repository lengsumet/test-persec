using System.Text;
/*-------------------------Case 1------------------------------*/
//string bracket = "{))}((";
//bool testBrackets = TestPersec.CheckBrackets(bracket);
//Console.WriteLine($"Brackets => {testBrackets}", );


/*-------------------------Case 2------------------------------*/
//List<string> listChar = new List<string>()
//{
//    "TH19", "SG20" , "TH2"
//};

//List<string> listCharInstance = new List<string>()
//{
//    "SG20", "TH2" , "TH19"
//};

//List<string> sortListChar = TestPersec.OrderChar(listChar, listCharInstance);
//string charSort = string.Join(", ", sortListChar);
//Console.WriteLine("sortListChar => {charSort}");

/*-------------------------Case 3------------------------------*/

//string search = "th";
//List<string> items = new List<string>()
//{
//    "Mother", "Think", "Worthy", "Apple", "Android"
//};
//int maxResult = 2;
//List<string> searchText = TestPersec.Autocomplete(search, items, maxResult);
//string searchString = string.Join(", ", searchText);
//Console.WriteLine($"searchString => {searchString}");


/*-------------------------Case 4------------------------------*/
//int number = 3141;
//string roman = TestPersec.NumberToRoman(number);
//Console.WriteLine(roman);
//int numberFromRoman = TestPersec.RomanToNumber(roman);
//Console.WriteLine(numberFromRoman);


/*-------------------------Case 5------------------------------*/

int numberOrder = 3141;
int orderedNumber = TestPersec.OrderDigitNumber(numberOrder);
Console.WriteLine(orderedNumber);

public class TestPersec
{
    public static bool CheckBrackets(string brackets)
    {
        int curly = 0;
        int square = 0;
        int round = 0;
        foreach (char bracket in brackets)
        {
            switch (bracket)
            {
                case '{': curly++; break;
                case '}': curly--; break;
                case '[': square++; break;
                case ']': square--; break;
                case '(': round++; break;
                case ')': round--; break;
            }
        }
        return curly == 0 && square == 0 && round == 0;
    }

    public static List<string> OrderChar(List<string> listChar, List<string> instanceListChar)
    {
        List<string> orderedListChar = listChar.OrderBy(x => instanceListChar.IndexOf(x)).ToList();
        return orderedListChar;
    }

    public static List<string> Autocomplete(string search, List<string> items, int maxResult)
    {
        List<string> searchList = items.Where(x => x.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
        List<string> orderBySearch = searchList.OrderBy(x =>
        {
            if (x.StartsWith(search, StringComparison.CurrentCultureIgnoreCase)) return 0;
            if (x.EndsWith(search, StringComparison.CurrentCultureIgnoreCase)) return 2;
            else return 1;
        }).ToList();
        return orderBySearch.Take(maxResult).ToList();
    }

    public static string NumberToRoman(int number)
    {
        (int, string)[] values = new[]
        {
            (1000, "M"),
            (500, "D"),
            (900, "CM"),
            (100, "C"),
            (400, "CD"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I"),
        };
        StringBuilder roman = new StringBuilder();
        for( int i = 0; i < values.Length; i++ )
        {
            while(number >= values[i].Item1)
            {
                number -= values[i].Item1;
                roman.Append(values[i].Item2);
            }
        }
        return roman.ToString();
    }

    public static int RomanToNumber(string roman)
    {
       (int, string)[] values = new[]
       {
            (1000, "M"),
            (500, "D"),
            (100, "C"),
            (50, "L"),
            (10, "X"),
            (5, "V"),
            (1, "I"),
        };
        int number = 0;
        for ( int i = 0; i < roman.Length; i++ ) 
        {
            int currentValue = values.FirstOrDefault(x => x.Item2 == roman[i].ToString()).Item1;  
            int nextValue = (i + 1 < roman.Length) ? values.FirstOrDefault(x => x.Item2 == roman[i+1].ToString()).Item1 : 0;
            if ( currentValue < nextValue)
            {
                number -= currentValue;
            } else
            {
                number += currentValue;
            }
        }
        return number;
    }

    public static int OrderDigitNumber(int number)
    {
        if (number > 0)
        {
            List<int> numberDigit = number.ToString().Select(x => int.Parse(x.ToString())).ToList();
            List<int> orderNumber = numberDigit.OrderByDescending(x => x).ToList();
            int finalNumber = int.Parse(string.Join("", orderNumber));
            return finalNumber;
        }
        return 0;
    }

    public static List<int> Tribonacci(List<int> startValue, int totalIndex)
    {
        if (startValue.Count > totalIndex) 
        {
            throw new ArgumentException("total index less than startValue!");
        }   
        if (startValue.Any())
        {

        } 
        else
        {

        }
    }
}