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
      <a href="https://github.com/Rllyyy/Internet-Check/releases/latest">
          <img src="https://img.shields.io/github/downloads/Rllyyy/Internet-Check/total?color=%232C974B&label=Downloads&style=flat-square" alt="GitHub All Releases">
       </a>
      <a href="https://github.com/Rllyyy/Internet-Check/releases/latest">
          <img src="https://img.shields.io/github/v/release/rllyyy/Internet-Check?color=%232C974B&label=Release&style=flat-square" alt="GitHub All Releases">
      </a>
      <a href="https://en.wikipedia.org/wiki/C_Sharp_(programming_language)" target="_blank">
          <img src="https://img.shields.io/github/languages/top/Rllyyy/Internet-Check?color=%232C974B&style=flat-square" alt="GitHub top language"> 
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE" target="_blank">
          <img src="https://img.shields.io/github/license/rllyyy/Internet-Check?color=%232C974B&label=License&style=flat-square" alt="GitHub License">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues" target="_blank">
          <img src="https://img.shields.io/github/issues-raw/rllyyy/Internet-Check?label=Open%20Issues%2FFeature%20Requests&style=flat-square" alt="GitHub issues">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues?q=is%3Aissue+is%3Aclosed" target="_blank">
          <img src="https://img.shields.io/github/issues-closed-raw/Rllyyy/Internet-Check?color=%232C974B&label=Closed%20Issues%2FImplemented%20Features&style=flat-square"                 alt="GitHub issues">
      </a>   
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master" target="_blank">
          <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/rllyyy/Internet-Check?color=%232C974B&label=Last%20Commit&style=flat-square">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master" target="_blank">
          <img alt="GitHub commits since latest release (by date)" src="https://img.shields.io/github/commits-since/rllyyy/internet-check/latest?color=%232C974B&label=Commits%20Since%20Last%20Release&style=flat-square">
       </a>
   </p>
</div>
<div class = "Description"> <p align = "center"><b><i>This program periodically checks if the computer is connected to the internet and logs offline time.</i></b></p></div>

# User Guide

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

# Install Guide

1. [Visit the download page](https://github.com/Rllyyy/Internet-Check/releases/latest), open the setup and follow the instructions.
2. Start InternetCheck.exe from either the Desktop or the appData folder.

# In-App Settings (DarkMode, Windows Autostart, System Tray)

## DarkMode

1. Tick the **Checkbox "Use DarkMode"**. The UI now switches to a darker colour pattern.

**_Note:_** The color of the title background may still appear white. These Windows settings can only be changed by the user. [Here](https://www.hellotech.com/guide/for/how-to-enable-dark-mode-in-windows-10) is a quick guide.

## Start Application on Windows Start-Up

1. Start the Application with admin rights.
1. Tick the **Checkbox "Start with Windows"** in the settings menu.

**_Warning:_** If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the system tray or by running the .exe again.

## Show only in System Tray

1. Tick the **"Show only in system tray" Checkbox** if you want to hide the application when minimized.

**_Warning:_** If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the system tray or by running the .exe again.

# Advanced Settings

These settings allow to the advanced user to further change certain aspects of the application. Applying incorrect or incomplete settings may prevent the application from running. AdvancedSettings.xml lives inside the AppData folder and can be edited by any editor (notepad, notepad++ or VSCode).

<!--Servers-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Select Servers To Ping</span></summary>
  Create a value tag and write the the ip address inside. Only add Ip-addresses to this list and not domain names like www.example.com so the router or dns server doesn't return a false value. The application automatically detects if a server has been added or removed but for now it needs to be restarted.
  <p>

```xml
<setting name="Servers">
  <value>8.8.8.8</value>
  <value>8.8.4.4</value>
  <value>1.1.1.1</value>
  <value>Your.New.IP.Address</value>
</setting>
```

  </p>
</details>

<!--Ping Methods-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Alternative Ping Method</span></summary>
  Set this value to true if you only get the message that the server did not respond although there is an active internet connection. This error might 
  occur if the ping protocol is blocked by the router.
  Server from the node "Servers" will be ignored and the application now sends a request to google.com/generate_204. Restart the app to apply the changes.
  <p>

```xml
<setting name="UseAlternativePingMethod">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Show all Ping Results-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Show all Ping Results</span></summary>
  If this value is set to true both successful and unsuccessful pings will be noted. If set to false only unsuccessful pings are recorded.
  <p>

```xml
<setting name="ShowAllPingResults">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Stop application after X days-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Stop the Application after X days (Task Scheduler)</span></summary>
  This setting stops the task if the pc is running longer than the value in days. This only applies if the option "start with windows" is selected and the application was therefore started by windows itself. If the program is started by the user this setting will not be applied.
  After changing this value in the xml file and the setting was already active value, please deselect the checkbox, click on back, go into settings again and select the option "Start with Windows".
  <p>

```xml
<setting name="TaskschedulerStopTaskAfterDays">
  <value>5</value>
</setting>
```

  </p>
</details>

<!--Disallow start if on batteries-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Disallow Start if on Batteries (Task Scheduler)</span></summary>
  
  <p>If this setting is set to true the app will not be launched by the Task Scheduler if the pc is not connected to a power source and is instead running on batteries.
  If "Start with Windows" was already active, please deselect the setting, click on back, go into settings again and select the option "Start with Windows". The standard value is false.
  </p>
  <p>

```xml
<setting name="DisallowStartIfOnBatteries">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Stop If Going On Batteries-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Stop if going on Batteries (Task Scheduler)</span></summary>
  
  <p>If this setting is set to true the app will stop if it was launched by the Task Scheduler and the pc is just running from the battery.
    If "Start with Windows" was already active, please deselect the setting, click on back, go into settings again and select the option "Start with Windows".
    The standard value is false.
  </p>
  <p>

```xml
<setting name="StopIfGoingOnBatteries">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Stop On Idle End-->
<details>
  <summary> <span style="font-size:22px; font-weight: bolder; color: black">Stop the program if returning from an Idle State (Task Scheduler)</span></summary>
  
  <p>If this setting is set to true the app will stop if it was launched by the Task Scheduler and the pc is returning from an idle state (i.e. if the laptop returns from sleep mode).
  If "Start with Windows" was already active, please deselect the setting, click on back, go into settings again and select the option "Start with Windows".
  The standard value is false.
  </p>
  <p>

```xml
<setting name="StopOnIdleEnd">
  <value>true</value>
</setting>
```

  </p>
</details>

# Legal Note

Although this program uses just 1 Byte (0.000001 Megabytes) to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS.
We therefore advise the user to put in an interval that is bigger or equal to 30 seconds.
The servers we are pinging (Googles DNS and Cloudflare) should handle the request with ease.
For any programmers we advice against increasing the buffer size in the ping method and to only ping servers that are used to higher traffic.
The author is not liable for any claim, damages or other liability whether in an action of contract, tort or otherwise, arising from,
out of or in connection with the software or the use or other dealings in the software. Read the whole license [here](https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE).

# Libraries and other external Software (no need to download them)

- TaskScheduler from https://github.com/dahall/TaskScheduler

      Errors, feature request or code changes can be submitted to GitHub under the "Issues" tab.
