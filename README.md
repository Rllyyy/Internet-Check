# Internet-Check
This program periodically checks if the computer is connected to the internet and saves offline time. 

___Leagl Note:___
- Using the MIT Licence (open the "Licence" file to read more)
- Although this program uses just 32 Bytes to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS or Slow Loris attack by the server. We therefore advise the user to put in an interval that is bigger than 30 seconds and only ping servers that are used to higher traffic (Googles DNS Server 8.8.8.8 or www.google.com). For any programmers we advice against increasing the buffer size in the ping method.
  - We also implemented a feature that prevents multiple instances of the application running even if the program is opened more than once

**Using Guide:**
- After opening the program set an interval in which the Internet should be checked. (Default is 30 seconds)
- Click on Start
- To Stop the programm click on Stop
- The current status of the application is displayed in the bottom right
- Results can be viewed by clicking on Open
- Results are cleared by pressing Clear. Note: this can not be undone

**Install Guide:**
1. Download and extract the zip or rar File
2. Start InternetCheck.exe

**DarkMode:**
1. Tick the Checkbox "Use DarkMode". The UI now switches to Darkmode
  - Note: The color of the title background may still apear white. This is because of the Windows settings. You need to adjust those manually

**Start Application on Windows Start-Up:**
- Tick the Checkbox "Start with Windows" in the settings menu.
  - Note: you still need to manually click on Start.
  
**Only show in Systemtray:**
- Tick the "Show only in Systemtray" Checkbox if you want to hide the application when minimized. The program will continue to run in the background regardless

**Libraries and other external Software**
- TaskScheduler from https://github.com/dahall/TaskScheduler

**Errors:**
- Error messages are implemented into the program itself. Please read them


      Errors or feature request can be submitted to GitHub under the "Issues" tab.
