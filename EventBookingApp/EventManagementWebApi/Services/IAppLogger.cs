using System.Runtime.CompilerServices;
using System;
namespace EventManagementWebApi.Services
{
    public interface IAppLogger
    {
        void ActivityLog(string message, [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "");
        void ExceptionLog(Exception ex, string message, [CallerMemberName] string methodName = "",
        [CallerFilePath] string filePath = "");
    }
}
