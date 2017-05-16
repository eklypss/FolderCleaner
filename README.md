# FolderCleaner
Small utility tool that keeps a specified folder clean by deleting all items inside (e.g. browser downloads folder, temporary files folder) to be used with Windows Task Scheduler to run on a specified schedule.

# Usage
* Open up the .exe once so it creates a configuration file.
* Open the .Config file in the folder with any text editor and change the value of the "Folder" key to the folder you want to keep clean.
* Use Windows Task Scheduler to [create a task](https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx) that runs the program .exe file as often as you wish.
* Done!
