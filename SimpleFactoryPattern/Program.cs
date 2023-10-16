namespace SimpleFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("請輸入運算子：(+, -, *, /) ：");
                    char opr = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    ISimpleCaculate caculator = SimpleCaculateFactory.CreateCaculator(opr);
                    caculator.InputOperandsAndCheck();
                    caculator.Caculate();
                    caculator.Output();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
                Console.WriteLine("繼續(Y), 結束(N)");
                char repeat = Console.ReadKey().KeyChar;
                if (repeat != 'Y' && repeat != 'y')
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            Console.WriteLine("結束");
        }
    }

    /// <summary>
    /// 簡單工廠類別
    /// </summary>
    public class SimpleCaculateFactory
    {
        /// <summary>
        /// 以靜態方法產生運算器
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        public static ISimpleCaculate CreateCaculator(char opr)
        {
            if (opr == '+')
            {
                return new Addition();
            }
            else if (opr == '-')
            {
                return new Subtraction();
            }
            else if (opr == '*')
            {
                return new Multiplication();
            }
            else //if (opr == '/')
            {
                return new Division();
            }
        }
    }

    /// <summary>
    /// 計算器介面 Interface
    /// </summary>
    public interface ISimpleCaculate
    {
        /// <summary>
        /// 運算元 ~ A
        /// </summary>
        int OperandA { get; set; }

        /// <summary>
        /// 運算元 ~ B
        /// </summary>
        int OperandB { get; set; }

        /// <summary>
        /// 計算結果
        /// </summary>
        float Result { get; set; }

        /// <summary>
        /// 輸入運算元並檢查
        /// </summary>
        void InputOperandsAndCheck();

        /// <summary>
        /// 計算
        /// </summary>
        void Caculate();

        /// <summary>
        /// 輸出
        /// </summary>
        void Output();
    }

    /// <summary>
    /// 加法器
    /// </summary>
    public class Addition : ISimpleCaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void InputOperandsAndCheck()
        {
            Console.Write("請輸入被加數： ");
            var a = Console.ReadLine();
            Console.Write("請輸入加數： ");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);
        }

        public void Caculate()
        {
            Result = OperandA + OperandB;
        }

        public void Output()
        {
            Console.WriteLine("{0} + {1} = {2} ", OperandA, OperandB, (int)Result);
        }


    }

    /// <summary>
    /// 減法器
    /// </summary>
    public class Subtraction : ISimpleCaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void InputOperandsAndCheck()
        {
            Console.Write("請輸入被減數： ");
            var a = Console.ReadLine();
            Console.Write("請輸入減數： ");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);
        }


        public void Caculate()
        {
            Result = OperandA - OperandB;
        }

        public void Output()
        {
            Console.WriteLine("{0} - {1} = {2} ", OperandA, OperandB, (int)Result);
        }
    }

    /// <summary>
    /// 乘法器
    /// </summary>
    public class Multiplication : ISimpleCaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void InputOperandsAndCheck()
        {
            Console.Write("請輸入被乘數： ");
            var a = Console.ReadLine();
            Console.Write("請輸入乘數： ");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);

        }

        public void Caculate()
        {
            Result = OperandA * (float)OperandB;
        }

        public void Output()
        {
            Console.WriteLine("{0} * {1} = {2} ", OperandA, OperandB, Result);
        }

    }

    /// <summary>
    /// 除法器
    /// </summary>
    public class Division : ISimpleCaculate
    {
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public float Result { get; set; }

        public void InputOperandsAndCheck()
        {
            Console.Write("請輸入被除數： ");
            var a = Console.ReadLine();
            Console.Write("請輸入除數： ");
            var b = Console.ReadLine();
            OperandA = Convert.ToInt32(a);
            OperandB = Convert.ToInt32(b);
            if (OperandB == 0)
            {
                throw new DivideByZeroException();
            }
        }

        public void Caculate()
        {
            Result = OperandA / (float)OperandB;
        }

        public void Output()
        {
            Console.WriteLine("{0} / {1} = {2} ", OperandA, OperandB, Result);
        }

    }



}