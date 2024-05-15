public class NumericalExpression
{
    private enum Digit
    {
        Units,
        Tens,
        Hundereds
    };

    // constant variables
    private const int MAX_NUMBER = 999999999;
    private const int POSITION_OFFSET = 3;

    // class members
    private int _value;

    // A dictionary containing the names of each number - the names can be modified to support a different language
    static private IDictionary<string, string> _numberNames = new Dictionary<string, string>()
    {
        {"0", "Zero" }, {"1","One" },{"2","Two" },{"3","Three" },{"4","Four" },{"5","Five"},{"6","Six"},{"7","Seven"},{"8","Eight"},{"9","Nine"}
    };
    // A dictionary containing the names of each number bigger than 9 - tens - the names can be modified to support a different language
    static private IDictionary<string, string> _tensNumberNames = new Dictionary<string, string>()
    {
        {"1","Ten"},{"2","Twenty"},{"3","Thirty"},{"4","Forty"},{"5","Fifty"},{"6","Sixty"},{"7","Seventy"},{"8","Eighty"},{"9","Ninety"},
        {"11","Eleven" }, {"12","Twelve" }, {"13","Thirteen"},{"14","Fourteen"},{"15","Fifteen"},{"16","Sixteen"},{"17","Seventeen"}
        ,{"18","Eighteen"}, {"19","Nineteen"}
    };
    // A dictionary containing the names for the units - each index represents three digits meaning the second 
    // three digits in a number represent Thousands the third ones represent Millions and so on
    // new units can be added to support numbers bigger than 999,999,999 - the constant MAX_NUMBER needs to be changed accordingly
    static private IDictionary<int, string> _indexToUnits = new Dictionary<int, string>()
    {
        {0,""},{1,"Thousand" },{2,"Million"},{3,"Billion"}
    };

    // Dictionaries containing the length of each number and units - used to make the function SumLetters run more efficiently
    static private IDictionary<string, int> _numberLengths = new Dictionary<string, int>()
    {
        {"0",_numberNames["0"].Length},{"1",_numberNames["1"].Length},{"2",_numberNames["2"].Length},
        {"3",_numberNames["3"].Length},{"4",_numberNames["4"].Length},{"5",_numberNames["5"].Length},
        {"6",_numberNames["6"].Length},{"7",_numberNames["7"].Length},{"8",_numberNames["8"].Length}
        ,{"9",_numberNames["9"].Length}
    };
    static private IDictionary<string, int> _tensNumberLengths = new Dictionary<string, int>()
    {
        {"1",_tensNumberNames["1"].Length},{"2",_tensNumberNames["2"].Length},{"3",_tensNumberNames["3"].Length},
        {"4",_tensNumberNames["4"].Length},{"5",_tensNumberNames["5"].Length},{"6",_tensNumberNames["6"].Length},
        {"7",_tensNumberNames["7"].Length},{"8",_tensNumberNames["8"].Length}, {"9",_tensNumberNames["9"].Length},
        {"11",_tensNumberNames["11"].Length}, {"12",_tensNumberNames["12"].Length}, {"13",_tensNumberNames["13"].Length},
        {"14",_tensNumberNames["14"].Length}, {"15",_tensNumberNames["15"].Length},{"16",_tensNumberNames["16"].Length},
        {"17",_tensNumberNames["17"].Length}, {"18",_tensNumberNames["18"].Length}, {"19",_tensNumberNames["19"].Length}
    };

    /// <summary>
    /// Constructor, receives a value to store inside the Numerical Expression and creates a new object accordingly 
    /// </summary>
    /// <param name="value">the number that is stored inside the Numerical Expression object</param>
    public NumericalExpression(int value)
    {
       if (value > MAX_NUMBER)
       {
           this._value = MAX_NUMBER;
       }
       else
       {
           this._value = value;
       }
    }

    public int GetValue()
    {
        return this._value;
    }

    /// <summary>
    /// the function receives two strings, concatenations them along with whitespaces and returns the new string 
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="addition"></param>
    /// <returns></returns>
    private static string addToExpression(string expression, string addition)
    {
        return addition + " " + expression + " ";
    }

    /// <summary>
    /// The function receives a string and returns the string reversed
    /// </summary>
    /// <param name="str">the string received</param>
    /// <returns>the reversed string</returns>
    private static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    /// <summary>
    /// new(overridden) to string function of the Numerical Expression class
    /// the function returns a string with the value of the number stored in it in words 
    /// </summary>
    /// <returns>a string with the the number in words </returns>
    public override string ToString()
    {
        //expression variable
        string expression = "";

        //flags
        bool unitNameFlag = false; //used for the addition of unit names - Thousands,Millions etc...
        //used to indicate that a special number is encountered meaning that number is represented by two digits instead of one
        //11,12,13...
        bool specialNumberFlag = false;

        //a string containing the number in reverse order, the expression is built from the units upwards
        string number = ReverseString(this._value.ToString());

        //special case - if the number is 0
        if (string.Equals(number,"0"))
        {
            return NumericalExpression._numberNames[number[0].ToString()];
        }

        for(int i = 0; i < number.Length;i++)
        {
            if (!String.Equals(number[i].ToString(),"0")) // checking if the digits is 0 - because 0 isn't mentioned in words
            {
                // adding the unit name according to the flag - Thousands,Millions etc... the flag insures that the name would be added only once
                if (unitNameFlag)
                {
                    expression = addToExpression(expression, NumericalExpression._indexToUnits[i / POSITION_OFFSET]);
                    unitNameFlag = false; // resetting the flag
                }
                // checking which digit the current iteration is handling 0 - units 1 - tens 2 - hundreds
                switch (i % POSITION_OFFSET)
                {
                    case (int)Digit.Units:
                        // checking if the number isn't special - 11, 12, 13. and making sure that the current digit
                        // is not the end of number to avoid run time error
                        if (i+1 != number.Length && String.Equals(number[i+1].ToString(), "1"))
                        {
                            // adding the correct expression that represents the number
                            expression = addToExpression(expression, NumericalExpression._tensNumberNames[number[i+1].ToString() + number[i].ToString()]);
                            specialNumberFlag = true; // setting the special number flag to make sure the next digit is skipped
                            break;
                        }
                        // the current digit is regular - adding the regular expression for the digit
                        expression = addToExpression(expression, NumericalExpression._numberNames[number[i].ToString()]);
                        break;
                    case (int)Digit.Tens:
                        // adding the expression for the tens digit - using the tens dictionary
                        expression = addToExpression(expression, NumericalExpression._tensNumberNames[number[i].ToString()]);
                        break;
                    case (int)Digit.Hundereds:
                        // adding the expression for the hundreds digit - using the regular number dictionary and adding the word hundred to the expression accordingly
                        expression =  addToExpression(expression, NumericalExpression._numberNames[number[i].ToString()] + " Hundred");
                        ;
                        break;
                }
                // checking if the unit changes in the next digit - and setting the unit flag accordingly. 
                // if the unit changes the new units name needs to be added to the expression
                int firstComp = (i+1)/POSITION_OFFSET;
                int secondComp = i/POSITION_OFFSET;
                if(firstComp > secondComp)
                {
                    unitNameFlag = true;
                }
                if(specialNumberFlag)
                {
                    i += 1; //skipping one digit
                    specialNumberFlag = false;
                }
            }
        }
        return expression.Substring(0,expression.Length-1); // removing whitespace at the end of the expression
    }
    /// <summary>
    /// The function calculates the amount of letters that are needed to represent every number from 0 to the number inputted
    /// in words, not including white spaces
    /// </summary>
    /// <param name="num">the number</param>
    /// <returns>the number of letters needed to express all the numbers from 0-number in words not including whitespaces</returns>
    public static int SumLetters(int num)
    {
        // 0 - is a special case
        if(num == 0) return 0;
        // initializing the length counter with the length of zero
        int len = NumericalExpression._numberLengths["0"];
        for (int i = 1; i < num; i++)
        {
            //reversing each number - to be able to go from units upwards
            string number = ReverseString(num.ToString());
            // calculating the amount of units names that need to be used and adding them accordingly
            int specialWords = number.Length / POSITION_OFFSET;
            for(int j=0;j<=specialWords;j++)
            {
                len += NumericalExpression._indexToUnits[j].Length;
            }
            // going through every digit and adding the length of the number represented by it accordingly
            // using proprietary dictionaries
            for (int j=0;j<number.Length;j++)
            {
                int pos = j % POSITION_OFFSET;
                switch (pos) 
                {
                    case (int)Digit.Units:
                        //checking if the current number is a special number - 11,12,13
                        if (j + 1 != number.Length && String.Equals(number[j + 1].ToString(), "1"))
                        {
                            len += NumericalExpression._tensNumberLengths[number[j + 1].ToString() + number[j].ToString()];
                            j += 1;
                            break;
                        }
                        len += NumericalExpression._numberLengths[number[j].ToString()];
                        break; 
                    case (int)Digit.Tens:
                        len += NumericalExpression._tensNumberLengths[number[j].ToString()];
                        break;
                    case (int)Digit.Hundereds:
                        len += NumericalExpression._numberLengths[number[j].ToString()] + "Hundred".Length;
                        break;
                }
            }
        }
        return len;
    }
    // Function overloading
    /// <summary>
    /// The function calculates the amount of letters that are needed to represent every number from 0 to the number in the numerical expression inputted
    /// in words, not including white spaces
    /// </summary>
    /// <param name="num">the numerical expression</param>
    /// <returns>the number of letters needed to express all the numbers from 0-number in words not including whitespaces</returns>
    public static int SumLetters(NumericalExpression num) 
    {
        return SumLetters(num._value);
    }
}