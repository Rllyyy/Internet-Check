<div class="Head">
<p>  
     <h1 align="center"> <img src="https://github.com/Rllyyy/Internet-Check/blob/master/Internet%20Check/icons/Internet-Check-Logo.png" height="35" alt="LogoText"> </h1>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/Rllyyy/Internet-Check/master/Internet%20Check/icons/InternetSymbolPNG.png" height="100">
</p>
</div>
<div class="Badges">
  <p align="center">
      <a href="https://github.com/Rllyyy/Internet-Check/releases">
          <img src="https://img.shields.io/github/downloads/Rllyyy/Internet-Check/total?color=%232C974B&label=Downloads&style=flat-square" alt="GitHub All Releases">
       </a>
      <a href="https://github.com/Rllyyy/Internet-Check/releases">
          <img src="https://img.shields.io/github/v/release/rllyyy/Internet-Check?color=%232C974B&label=Release&style=flat-square" alt="GitHub All Releases">
      </a>
      <a href="https://en.wikipedia.org/wiki/C_Sharp_(programming_language)" target="_blank">
          <img src="https://img.shields.io/github/languages/top/Rllyyy/Internet-Check?color=%232C974B&style=flat-square" alt="GitHub top language"> 
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE">
          <img src="https://img.shields.io/github/license/rllyyy/Internet-Check?color=%232C974B&label=License&style=flat-square" alt="GitHub License">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues">
          <img src="https://img.shields.io/github/issues-raw/rllyyy/Internet-Check?label=Open%20Issues%2FFeature%20Requests&style=flat-square" alt="GitHub issues">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues?q=is%3Aissue+is%3Aclosed">
          <img src="https://img.shields.io/github/issues-closed-raw/Rllyyy/Internet-Check?color=%232C974B&label=Closed%20Issues%2FImplemented%20Features&style=flat-square"                 alt="GitHub issues">
      </a>   
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master">
          <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/rllyyy/Internet-Check?color=%232C974B&label=Last%20Commit&style=flat-square">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master">
          <img alt="GitHub commits since latest release (by date)" src="https://img.shields.io/github/commits-since/rllyyy/internet-check/latest?color=%232C974B&label=Commits%20Since%20Last%20Release&style=flat-square">
       </a>
   </p>
</div>
<div class = "Description"> <p align = "center"><b><i>This program periodically checks if the computer is connected to the internet and logs offline time.</i></b></p></div>

## User Guide

- After opening the program set an **interval** in which the Internet should be checked. (Default is 30 seconds)
- Click on **Start** to start collecting data.
- To stop the program click on **Stop**.
- Results can be viewed by clicking on **Open**.
- The current status of the application is displayed in the bottom right.
- By default the program will only show the offline time and not the time the computer is connected to the internet.
  - Programmers can change this by uncommenting the relevant lines in Form1.CheckAndWrite().
- Results are cleared by pressing **Clear** and then either "Clear Everything" or "Clear Only Irrelevant Data".
  - Note: Make sure that the program is not currently logging data. (Status bottom right: Waiting . . .)
  - Warning: A clear can not be undone.

## Install Guide

1. [Visit the download page](https://github.com/Rllyyy/Internet-Check/releases/latest), open the setup and follow the instructions.
2. Start InternetCheck.exe from either the destop or the appData folder.

## DarkMode

1. Tick the Checkbox "Use DarkMode". The UI now switches to Darkmode.

- Note: The color of the title background may still appear white. These Windows settings can only be changed by the user. [Here](https://www.hellotech.com/guide/for/how-to-enable-dark-mode-in-windows-10) is how.

## Start Application on Windows Start-Up

1. Tick the Checkbox "Start with Windows" in the settings menu.

- Warning: If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the system tray or by running the .exe again.

## Only show in system tray

1. Tick the "Show only in system tray" Checkbox if you want to hide the application when minimized.

- Warning: If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the system tray or by running the .exe again.

## Errors

Error messages are implemented into the program itself.
Please report issues or crashes [here](https://github.com/Rllyyy/Internet-Check/issues/new/choose).

## Legal Note

Although this program uses just 1 Byte (0.000001 Megabytes) to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS.
We therefore advise the user to put in an interval that is bigger or equal to 30 seconds.
The servers we are pinging (Googles DNS and Cloudflare) can handle the request with ease.
For any programmers we advice against increasing the buffer size in the ping method and to only ping servers that are used to higher traffic.
The author is not liable for any claim, damages or other liability whether in an action of contract, tort or otherwise, arising from,
out of or in connection with the software or the use or other dealings in the software. Read the hole license [here](https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE)

## Libraries and other external Software (no need to download them)

- TaskScheduler from https://github.com/dahall/TaskScheduler

      Errors, feature request or code changes can be submitted to GitHub under the "Issues" tab.
