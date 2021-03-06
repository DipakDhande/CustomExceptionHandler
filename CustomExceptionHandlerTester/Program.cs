using System;
using CustomExceptionHandler;

namespace CustomExceptionHandlerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                try
                {
                    int c = 10;
                    int d = c / 0;
                }
                catch (Exception ex)
                {

                    string message = ExceptionHandler.ExceptionEngine(ex, "Program", "Some Inner Method", "A program to test custom exception handler");
                }
                int a = 10;
                int b = a / 0;
            }
            catch (Exception ex)
            {
                string message = ExceptionHandler.ExceptionEngine(ex, "Program", "Main", "A program to test custom exception handler");
            }
        }
    }
}
