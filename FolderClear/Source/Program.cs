using NLog;

namespace FolderClear
{
    internal class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            _logger.Info("Program started.");
            Cleaner folderClear = new Cleaner();
            folderClear.Run();
        }
    }
}