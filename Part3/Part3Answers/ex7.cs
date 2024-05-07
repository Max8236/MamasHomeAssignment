public class NumericalExpression
{
    private const int POSITION_OFFSET = 3;
    private int _value;

    static private IDictionary<string, string> _numberNames = new Dictionary<string, string>()
    {
        {"0", "Zero" }, {"1","One" },{"2","Two" },{"3","Three" },{"4","Four" },{"5","Five"},{"6","Six"},{"7","Seven"},{"8","Eight"},{"9","Nine"}
    };
    static private IDictionary<string, string> _tensNumberNames = new Dictionary<string, string>()
    {
        {"1","Ten"},{"2","Twenty"},{"3","Thirty"},{"4","Forty"},{"5","Fifty"},{"6","Sixty"},{"7","Seventy"},{"8","Eighty"},{"9","Ninety"},
        {"11","Eleven" }, {"12","Twelve" }, {"13","Thirteen"},{"14","Fourteen"},{"15","Fifteen"},{"16","Sixteen"},{"17","Seventeen"}
        ,{"18","Eighteen"}, {"19","Nineteen"}
    };
    static private IDictionary<int, string> _indexToUnits = new Dictionary<int, string>()
    {
        {0,""},{1,"Thousand" },{2,"Million"},{3,"Billion"}
    };
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
    public NumericalExpression(int value)
    {
       this._value = value;
    }
    public int GetValue()
    {
        return this._value;
    }
    private static string addToExpression(string expression, string addition)
    {
        return addition + " " + expression + " ";
    }
    private static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public string ToString()
    {
        string expression = "";
        bool unitNameFlag = false;
        bool specialNumberFlag = false;
        string number = ReverseString(this._value.ToString());
        if (string.Equals(number,"0"))
        {
            return NumericalExpression._numberNames[number[0].ToString()];
        }
        for(int i = 0; i < number.Length;i++)
        {
            if (!String.Equals(number[i].ToString(),"0"))
            {
                if (unitNameFlag)
                {
                    expression = addToExpression(expression, NumericalExpression._indexToUnits[i / POSITION_OFFSET]);
                    unitNameFlag = false;
                }
                switch (i % POSITION_OFFSET)
                {
                    case 0:
                        if (i+1 != number.Length && String.Equals(number[i+1].ToString(), "1"))
                        {
                            expression = addToExpression(expression, NumericalExpression._tensNumberNames[number[i+1].ToString() + number[i].ToString()]);
                            specialNumberFlag = true;
                            break;
                        }
                        expression = addToExpression(expression, NumericalExpression._numberNames[number[i].ToString()]);
                        break;
                    case 1:
                        expression = addToExpression(expression, NumericalExpression._tensNumberNames[number[i].ToString()]);
                        break;
                    case 2:
                        expression =  addToExpression(expression, NumericalExpression._numberNames[number[i].ToString()] + " Hundred");
                        ;
                        break;
                }
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
        return expression.Substring(0,expression.Length-1); // removing space at end of expression
    }
    public static int SumLetters(int num)
    {
        if(num == 0) return 0;
        int len = NumericalExpression._numberLengths["0"];
        for (int i = 1; i < num; i++)
        {
            string number = ReverseString(num.ToString());
            int specialWords = number.Length / POSITION_OFFSET;
            for(int j=0;j<=specialWords;j++)
            {
                len += NumericalExpression._indexToUnits[j].Length;
            }
            for (int j=0;j<number.Length;j++)
            {
                int pos = j % POSITION_OFFSET;
                switch (pos) 
                {
                    case 0:
                        if (j + 1 != number.Length && String.Equals(number[j + 1].ToString(), "1"))
                        {
                            len += NumericalExpression._tensNumberLengths[number[j + 1].ToString() + number[j].ToString()];
                            j += 1;
                            break;
                        }
                        len += NumericalExpression._numberLengths[number[j].ToString()];
                        break; 
                    case 1:
                        len += NumericalExpression._tensNumberLengths[number[j].ToString()];
                        break;
                    case 2:
                        len += NumericalExpression._numberLengths[number[j].ToString()] + "Hundred".Length;
                        break;
                }
            }
        }
        return len;
    }
    // Function overloading
    public static int SumLetters(NumericalExpression num) 
    {
        int len = 0;
        for (int i = 0; i < num._value; i++)
        {
            len += new NumericalExpression(num._value).ToString().Replace(" ", string.Empty).Length;
        }
        return len;
    }
}