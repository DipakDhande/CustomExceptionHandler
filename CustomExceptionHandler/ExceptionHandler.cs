using System;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Serilog;

namespace CustomExceptionHandler
{
    public class ExceptionHandler
    {
        public string ExceptionEngine(Exception ex, string className, string methodName, string businessFunctionality)
        {
            string logInformation = SegregateException(ex, className, methodName, businessFunctionality);//create log information
            WriteLog(logInformation);//write logs to target
            return "Exception occured.";
        }
        private void WriteLog(string logInformation)//writes exception logs to target 
        {
            string jsonConfigFilePath = ConfigurationManager.AppSettings["jsonConfigFilePath"];
            var configuration = new ConfigurationBuilder().AddJsonFile(jsonConfigFilePath).Build();//get configuration to read log settings

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Error(logInformation);//writes exception logs to target specified in configuration
            Log.CloseAndFlush();
        }
        private string SegregateException(Exception ex, string className, string methodName, string businessFunctionality)//create exception log information which can be written to the target like text file etc.
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
        private string GetStackTrace(Exception ex)//can be defined later to get stack trace
        {
            return null;
        }
        private Exception GetInnerException(Exception ex)//can be defined later to get inner exception
        {
            return null;
        }        
    }
}
