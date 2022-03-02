using System;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Serilog;

namespace CustomExceptionHandler
{
    public static class ExceptionHandler
    {
        private static readonly string jsonConfigFilePath = ConfigurationManager.AppSettings["jsonConfigFilePath"];
        private static readonly IConfiguration configuration = new ConfigurationBuilder().AddJsonFile(jsonConfigFilePath).Build();//get configuration to read log settings

        public static string ExceptionEngine(Exception ex, string className, string methodName, string businessFunctionality)
        {
            string logInformation = SegregateException(ex, className, methodName, businessFunctionality);//create log information
            WriteLog(logInformation);//write logs to target
            return configuration["Dialog"];
        }
        private static void WriteLog(string logInformation)//writes exception logs to target 
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Error(logInformation);//writes exception logs to target specified in configuration
            Log.CloseAndFlush();
        }
        private static string SegregateException(Exception ex, string className, string methodName, string businessFunctionality)//create exception log information which can be written to the target like text file etc.
        {
            string logInformation = string.Join(Environment.NewLine,
                                     "",
                                    $"{Constants.ClassName}{ className}, {Constants.MethodName} {methodName},",
                                    $"{Constants.BusinessFun} {businessFunctionality},",
                                    $"{Constants.StackTrace}{ex.StackTrace},",
                                    $"{Constants.InnerException} {ex.InnerException}",
                                    $"{Constants.LineSeparator}"
                );
            return logInformation;
        }
        private static string GetStackTrace(Exception ex)//can be defined later to get stack trace
        {
            return null;
        }
        private static Exception GetInnerException(Exception ex)//can be defined later to get inner exception
        {
            return null;
        }        
    }
}
