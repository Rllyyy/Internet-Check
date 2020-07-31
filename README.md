<div class="Head">
<p>  
     <h1 align="center"> <img src="https://github.com/Rllyyy/Internet-Check/blob/master/Internet%20Check/icons/Internet-Check-Logo.png?raw=true" height="40" alt="LogoText"> </h1>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/Rllyyy/Internet-Check/master/Internet%20Check/icons/InternetSymbolPNG.png" height="100">
</p>
</div>
<div class="Badges">
  <p align="center">
      <a href="https://github.com/Rllyyy/Internet-Check/releases">
          <img src="https://img.shields.io/github/downloads/Rllyyy/Internet-Check/total?color=%232C974B&label=Downloads&style=flat-square" alt="GitHub All Releases"></a>
      <a href="https://github.com/Rllyyy/Internet-Check/releases">
          <img src="https://img.shields.io/github/v/release/rllyyy/Internet-Check?color=%232C974B&label=Release&style=flat-square" alt="GitHub All Releases"></a>
      <img src="https://img.shields.io/github/languages/top/Rllyyy/Internet-Check?color=%232C974B&style=flat-square" alt="GitHub top language"></a>
      <img src="https://img.shields.io/github/license/rllyyy/Internet-Check?color=%232C974B&label=License&style=flat-square" alt="GitHub License"></a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues">
          <img src="https://img.shields.io/github/issues-raw/rllyyy/Internet-Check?label=Open%20Issues%2FFeature%20Requests&style=flat-square" alt="GitHub issues"></a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues?q=is%3Aissue+is%3Aclosed">
          <img src="https://img.shields.io/github/issues-closed-raw/Rllyyy/Internet-Check?color=%232C974B&label=Closed%20Issues%2FImplemented%20Features&style=flat-square"                 alt="GitHub issues"></a>   
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master">
          <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/rllyyy/Internet-Check?color=%232C974B&label=Last%20Commit&style=flat-square"></a>
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master">
          <img alt="GitHub commits since latest release (by date)" src="https://img.shields.io/github/commits-since/rllyyy/internet-check/latest?color=%232C974B&label=Commits%20Since%20Last%20Release&style=flat-square"></a>
   </p>
</div>


___This program periodically checks if the computer is connected to the internet and saves offline time.___

**User Guide:**
- After opening the program set an interval in which the Internet should be checked. (Default is 30 seconds)
- Click on Start
- To Stop the programm click on Stop
- The current status of the application is displayed in the bottom right
- Results can be viewed by clicking on Open
- Results are cleared by pressing Clear and then either "Clear Everything" or "Clear Only Irrelevant Data". Note: this can not be undone

**Install Guide:**
1. [Download](https://github.com/Rllyyy/Internet-Check/releases/download/v1.4/Internet.Check.-.v1.4.zip) and extract the zip or rar File
2. Start InternetCheck.exe

**DarkMode:**
1. Tick the Checkbox "Use DarkMode". The UI now switches to Darkmode.
  - Note: The color of the title background may still apear white. These Windows settings can only be changed by the user.

**Start Application on Windows Start-Up:**
- Tick the Checkbox "Start with Windows" in the settings menu.
  - Note: you still need to manually click on Start.
  
**Only show in Systemtray:**
- Tick the "Show only in Systemtray" Checkbox if you want to hide the application when minimized. The program will continue to run in the background regardless

**Libraries and other external Software:** (no need to download them)
- TaskScheduler from https://github.com/dahall/TaskScheduler

**Errors:**
- Error messages are implemented into the program itself. Please read them.
    
___Legal Note:___
- Using the MIT Licence (open the "Licence" file to read more)
- Although this program uses just 32 Bytes to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS or Slow Loris attack by the server. We therefore advise the user to put in an interval that is bigger than 30 seconds and only ping servers that are used to higher traffic (Googles DNS Server 8.8.8.8 or www.google.com). For any programmers we advice against increasing the buffer size in the ping method.



          Errors or feature request can be submitted to GitHub under the "Issues" tab. Please use the template.
