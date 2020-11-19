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

- After opening the program set an **interval** in which the Internet should be checked.
- Click on **Start** to start collecting data.
- To stop the program click on **Stop**.
- Results can be viewed by clicking on **Open**.
- The current status of the application is displayed in the bottom right.
- By default the program will only show the offline time and not the time the computer is connected to the internet.
  - To change this read "show all Ping Results" in the chapter Advanced Settings.
- Results are cleared by pressing **Clear** and then either "Clear Everything" or "Clear Only Irrelevant Data".
  - Note: Make sure that the program is not currently logging data. (Status bottom right: Waiting . . .)
  - Warning: A clear can not be undone.

# Install Guide & System Requirements

1. <b>[Visit the download page](https://github.com/Rllyyy/Internet-Check/releases/latest)</b>, open the setup and follow the instructions.
2. Start InternetCheck.exe from either the Desktop or the appData folder.

<details>
  <summary><b><i>View System Requirements</i></b></summary>
  <p>
  <ul>
  <li><b>.NET Framework 4.7.2</b> (included in <b>Windows 10</b> April 2018 Update) but should also work on Windows 7+ or Windows Server 2008 R2+ </li>
  <li>Memory: 20 MB RAM</li>
  <li>Storage: 800 KB available space</li>
</ul>
  </p>
</details>

# In-App Settings (DarkMode, Windows Autostart, System Tray)

## DarkMode

1. Tick the **Checkbox "Use DarkMode"**. The UI now switches to a darker colour pattern.

**_Note:_** The color of the title background may still appear white. These Windows settings can only be changed by the user. [Here](https://www.hellotech.com/guide/for/how-to-enable-dark-mode-in-windows-10) is a quick guide.

## Start Application on Windows Start-Up

1. Start the Application with admin rights.
1. Tick the **Checkbox "Start with Windows"** in the settings menu.

**_Warning:_** If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the System Tray or by running the .exe again.

## Show only in System Tray

1. Tick the **"Show only in system tray" Checkbox** if you want to hide the application when minimized.

**_Warning:_** If both "Start with Windows" and "Show only in system tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the System Tray or by running the .exe again.

# FAQ

<details>
  <summary><b>Why does the program tell me that I don't have internet although my internet is working fine? </b></summary>
  <span>Some routers may block the ping protocol. For users experiencing this problem please follow the instructions in "use alternative ping method" under advanced settings in this readme.
  </span>
</details>

<details>
  <summary><b>Why does the program sometimes show that the connection is disrupted?</b></summary>
  <span>A failed ping is noted when the server doesn't respond within 2.5 seconds. Often this is the result of a packet loss within the users network. A very few servers may also not respond within the given time frame of 2.5 seconds or temporary block the users ip address (ping to death prevention). The severs that come with this program should respond within the time frame and won't block the user. The ping protocol doesn't use TCP which would resend data and instead is using ICMP.
  </span>
</details>
<details>
  <summary><b>I found a bug, have a feature request or want to make a proposition for a code change. Where can they be reported?</b></summary>
  <span>Bugs, feature request or code changes can be submitted to GitHub under the <a href="https://github.com/Rllyyy/Internet-Check/issues/new/choose">"Issues"</a> tab.
  </span>
</details>
<details>
  <summary><b>Where are the program files saved?</b></summary>
  <span>The program files live in Users\[userName]\AppData\Local\4PointsInteractive\Internet-Check.
  To make the setup work we sadly had to save the application inside the users appData folder which is not visible by default.
  <a href="https://cybertext.wordpress.com/2012/05/29/cant-see-the-appdata-folder/">Here</a> is a guide to make the appData folder visible.
  </span>
</details>

# Advanced Settings

These settings allow to the advanced user to further change certain aspects of the application. Applying incorrect or incomplete settings may prevent the application from running. AdvancedSettings.xml lives inside the AppData folder and can be edited by any editor (notepad, notepad++ or VSCode).
For the exact file location read "Where are the program files saved?" in the FAQ.

<!--Servers-->
<details>
  <summary><b>Edit Servers that are Pinged</b></summary>
  Create a value tag and write the IP address inside. Only add IP addresses to this list and not domain names (like www.example.com) so the router or DNS server doesn't return a false value. The application automatically detects if a server has been added or removed when the user clicks on the start button. Please make sure to save the XML file in beforehand.
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
  <summary><b>Use alternative Ping Method</b></summary>
  Set this value to true if you only get the message that the server did not respond although there is an active internet connection. This error might 
  occur if the ping protocol is blocked by the router.
  Server from the node "Servers" will be ignored and the application now sends a request to google.com/generate_204. Save the XML file and click on start in Internet Check.
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
  <summary><b>Show all Ping Results</b></summary>
  If this value is set to true both successful and unsuccessful pings will be noted. If set to false only unsuccessful pings are recorded. Please click on start again in the application to apply the change and make sure that the XML file was saved beforehand.
  <p>

```xml
<setting name="ShowAllPingResults">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Show Minimized Info-->
<details>
  <summary><b>Show minimized Info Notification</b></summary>
  <p>
  Set this value to false if the balloon item that shows up if the application is minimized and "show only in System Tray" is active should  not be displayed. This setting will be applied the next time the application is minimized. Make sure to save AdvancedSettings.xml! The standard value is true.
  </p>
  <p>
  <img src=".\.github\balloonTip.png" alt="BallonTip">
  </p>
  <p>

```xml
<setting name="ShowMinimizedInfo">
  <value>true</value>
</setting>
```

  </p>
</details>

<!--Stop application after X days-->
<details>
  <summary><b>Stop the Application after X days (Task Scheduler)</b></summary>
  This setting stops the task if the pc is running longer than the value in days. This only applies if the option "start with windows" is selected and the application was therefore started by windows itself. If the program is started by the user this setting will not be applied.
  After changing this value in the XML file and the setting was already active value, please deselect the checkbox and select the option "Start with Windows" again. If the setting was not active it will be applied if the user ticks the checkbox "Start with Windows".
  <p>

```xml
<setting name="TaskSchedulerStopTaskAfterDays">
  <value>5</value>
</setting>
```

  </p>
</details>

<!--Disallow start if on batteries-->
<details>
  <summary><b>Disallow Start if on Batteries (Task Scheduler)</b></summary>
  <p>If this setting is set to true the app will not be launched by the Task Scheduler if the pc is not connected to a power source and is instead running on batteries.
  After changing this value in the XML file and the setting was already active value, please deselect the checkbox and select the option "Start with Windows" again. If the setting was not active it will be applied if the user ticks the checkbox "Start with Windows". The standard value is false.
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
  <summary><b>Stop if going on Batteries (Task Scheduler)</b></summary>
  
  <p>If this setting is set to true the app will stop if it was launched by the Task Scheduler and the pc is just running from the battery.
    After changing this value in the XML file and the setting was already active value, please deselect the checkbox and select the option "Start with Windows" again. If the setting was not active it will be applied if the user ticks the checkbox "Start with Windows".
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
  <summary><b>Stop the program if returning from an Idle State (Task Scheduler)</b></summary>
  
  <p>If this setting is set to true the app will stop if it was launched by the Task Scheduler and the pc is returning from an idle state (i.e. if the laptop returns from sleep mode).
  After changing this value in the XML file and the setting was already active value, please deselect the checkbox and select the option "Start with Windows" again. If the setting was not active it will be applied if the user ticks the checkbox "Start with Windows".
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

Although this program uses less than 100 Bytes (0.000100 Megabytes) to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS or ping of death attack.
We therefore advise the user to put in an interval that is bigger or equal to 30 seconds.
The servers we are pinging (Googles DNS and Cloudflare) should handle the request with ease.
For any programmers we advice against increasing the buffer size in the ping method and to only ping servers that are used to higher traffic.
The author is not liable for any claim, damages or other liability whether in an action of contract, tort or otherwise, arising from,
out of or in connection with the software or the use or other dealings in the software. Read the whole license [here](https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE).

# Libraries and other external Software (no need to download them)

- TaskScheduler from https://github.com/dahall/TaskScheduler

      Bugs, feature request or code changes can be submitted to GitHub under the "Issues" tab.
