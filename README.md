# FolderCleaner
Small utility tool that keeps a specified folder clean by deleting all items inside (e.g. browser downloads folder, temporary files folder) to be used with Windows Task Scheduler to run on a specified schedule.

# Usage
* Open up the .exe once so it creates a configuration _(.Config)_ file used by the program.
* Open the newly created _.Config_ file with any text editor and change the value of the _"Folder"_ key to the folder you want to keep clean _(full path)_.
* Use **Windows Task Scheduler** to [**create a task**](https://technet.microsoft.com/en-us/library/cc748993(v=ws.11).aspx) that runs the program .exe file as often as you wish.
* Done!
