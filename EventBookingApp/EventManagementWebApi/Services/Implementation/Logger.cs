using System.Runtime.CompilerServices;
using System;
namespace EventManagementWebApi.Services.Implementation
{
    public class AppLogger :IAppLogger
    {
        private static readonly Lazy<AppLogger> _instance = new(() => new AppLogger());
        public static AppLogger Instance => _instance.Value;
        private static readonly object _userJourneyLock = new();
        private static readonly object _exceptionLock = new();
        private string _currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        private string _userJourneyLogPath;
        private string _exceptionLogPath;
        public AppLogger()
        {
            Directory.CreateDirectory("Logs");
            UpdateLogPaths();
        }
        private void UpdateLogPaths()
        {
            _userJourneyLogPath = Path.Combine("Logs", $"UserJourney-{_currentDate}.txt");
            _exceptionLogPath = Path.Combine("Logs", $"Exceptions-{_currentDate}.txt");
        }

        private void EnsureLogPathsAreCurrent()
        {
            var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
            if (today != _currentDate)
            {
                lock (_userJourneyLock)
                    lock (_exceptionLock)
                    {
                        _currentDate = today;
                        UpdateLogPaths();
                    }
            }
        }

        public void ActivityLog(string message, [CallerMemberName] string methodName = "",[CallerFilePath] string filePath = "")
        {
            EnsureLogPathsAreCurrent();
            var className = Path.GetFileNameWithoutExtension(filePath);
            lock (_userJourneyLock)
            {
                File.AppendAllText(_userJourneyLogPath, $"[{DateTime.Now:u}] [{className}.{methodName}] [INFO] {message}\n");
            }
        }

        public void ExceptionLog(Exception ex, string message, [CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            EnsureLogPathsAreCurrent();

            lock (_exceptionLock)
            {
                File.AppendAllText(_exceptionLogPath,
                    $"[{DateTime.UtcNow:u}] [ERROR] {message}\n{ex}\n");
            }
        }
    }
}
