using NLog;
using System;
using System.Configuration;
using System.IO;

namespace FolderClear
{
    public class Cleaner
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public string GetFolder()
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settingsHandle = configFile.AppSettings.Settings;
                if (settingsHandle["Folder"] == null)
                {
                    _logger.Debug("Configuration key was not found. Trying to create it.");
                    settingsHandle.Add("Folder", "Set folder path here");
                }
                configFile.Save(ConfigurationSaveMode.Minimal);
                return settingsHandle["Folder"].Value;
            }
            catch (ConfigurationErrorsException ex)
            {
                Console.WriteLine("Failed to read or write configuration file. See log.ini for more detailed information.");
                Console.ReadKey();
                _logger.Info("Failed to read or write configuration file.");
                _logger.Error($"Error message: {ex.Message} at line {ex.Line}.");
                _logger.Error($"StackTrace: {ex.StackTrace} InnerException: {ex.InnerException}.");
                throw;
            }
        }

        internal void Run()
        {
            if (Directory.Exists(GetFolder()))
            {
                foreach (var file in Directory.GetFiles(GetFolder()))
                {
                    try
                    {
                        _logger.Info($"Trying to delete file: {file}.");
                        File.Delete(file);
                        _logger.Info($"File deleted: {file}.");
                    }
                    catch (IOException ex)
                    {
                        _logger.Error($"Could not delete file: {file}: {ex.Message}.");
                        throw;
                    }
                }
            }
            else
            {
                _logger.Error("Invalid folder path given.");
                Console.WriteLine("Invalid folder path given. Change the folder path in the .Config file.");
                Console.ReadKey();
            }
        }
    }
}