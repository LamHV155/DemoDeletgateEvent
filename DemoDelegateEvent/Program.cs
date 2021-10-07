using System;
using System.Text;

namespace DemoDelegateEvent
{
    public delegate void ShowLog(string msg);

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            DemoDelegate();
        }

    


        #region Delegate
        static void DemoDelegate()
        {
            //---basic-------------------
            ShowLog log = null;
            log = Success;
            log += Error;
            log += Success;

            // if (log != null)
            //     log("Hello");
            log?.Invoke("Hello");


            //Action
            Action<string> showLog; // ~ delegate void Name(string)
            showLog = Success;
            showLog?.Invoke("Hello from Action");

            Action<int, int, ShowLog> PrintCalc;  // ~ delegate void Name(int, int, delegate)
            PrintCalc = PrintResMulti;
            PrintCalc?.Invoke(3, 2, Success);


            //Func: delegate có kiểu trả về
            Func<int, int, string> Calc; // ~ delegate string Name(int, int)
            Calc = Sum;
            Console.WriteLine(Calc?.Invoke(3, 2));
            Calc = Sub;
            Console.WriteLine(Calc?.Invoke(3, 2));

        }

        static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static string Sum(int a, int b) => $"Tổng {a}, {b} là {a + b}";
        static string Sub(int a, int b) => $"Hiệu {a}, {b} là {a - b}";
        static void PrintResMulti(int a, int b, ShowLog log)
        {
            log?.Invoke($"Tích {a}, {b} là {a * b}");
        }
        #endregion
    }
}
