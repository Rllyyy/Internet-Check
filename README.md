<div class="Head">
<p align="center" id="title">  
  <img src="./.github/Logo.png">
</p>
<p align="center">
  <img src="./.github/previewPic.png">
</p>
</div>
<div class="Badges">
  <p align="center">
      <a href="https://github.com/Rllyyy/Internet-Check/releases/latest">
          <img src="https://img.shields.io/github/downloads/Rllyyy/Internet-Check/total?color=%232C974B&label=Downloads&style=flat-square" alt="Downloads">
       </a>
      <a href="https://github.com/Rllyyy/Internet-Check/releases/latest">
          <img src="https://img.shields.io/github/v/release/rllyyy/Internet-Check?color=%232C974B&label=Release&style=flat-square" alt="Latest Releases">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE" target="_blank">
          <img src="https://img.shields.io/github/license/rllyyy/Internet-Check?color=%232C974B&label=License&style=flat-square" alt="GitHub License">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues" target="_blank">
          <img src="https://img.shields.io/github/issues-raw/rllyyy/Internet-Check?label=Open%20Issues%2FFeature%20Requests&style=flat-square" alt="Open issues">
      </a>
      <a href="https://github.com/Rllyyy/Internet-Check/issues?q=is%3Aissue+is%3Aclosed" target="_blank">
          <img src="https://img.shields.io/github/issues-closed-raw/Rllyyy/Internet-Check?color=%232C974B&label=Closed%20Issues%2FImplemented%20Features&style=flat-square"  alt="Fixed issues">
      </a>   
      <a href="https://github.com/Rllyyy/Internet-Check/commits/master" target="_blank">
          <img alt="Commits since last release" src="https://img.shields.io/github/commits-since/rllyyy/internet-check/latest?color=%232C974B&label=Commits%20Since%20Last%20Release&style=flat-square">
       </a>
   </p>
</div>
<div class = "Description"> <p align = "center"><b><i>This program periodically checks if the computer is connected to the internet and logs offline time. It can also be used to check custom servers. Ping and packet lost are not measured.</i></b></p></div>

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

1. <b>[Visit the Download page](https://github.com/Rllyyy/Internet-Check/releases/latest)</b> and <b>Download <i>Internet-Check.Setup.msi</i></b> or <b>[Download the latest version directly](https://github.com/Rllyyy/Internet-Check/releases/download/v1.6.4/Internet-Check-v1.6.4.Setup.msi)</b>
2. Start the Setup
3. If the message "Windows protected your PC" pops up, click on "More info" and then "Run Anyway"
4. Follow the instructions in the Setup
5. Start InternetCheck.exe from either the Desktop or navigate to <i>Program Files (x86)\4PointsInteractive\InternetCheck.exe </i>

<details>
  <summary><b><i>View System Requirements</i></b></summary>
  <p>
  <ul>
  <li><b>.NET Framework 4.7.2</b> (included in <b>Windows 10</b> April 2018 Update) but should also work on Windows 7+ or Windows Server 2008 R2+ </li>
  <li>Memory: 30 MB RAM</li>
  <li>Storage: 5 MB available space</li>
</ul>
  </p>
</details>

# In-App Settings

### Basic Settings

<!--DarkMode-->
<details>
  <summary><b>DarkMode</b></summary>
  <ol>
  <li><b>Tick the Checkbox "Use DarkMode".</b> The UI now switches to a darker colour pattern. </li>
  </ol>
  <span><i><b>Note:</b></i> The color of the title background may still appear white. These Windows settings can only be changed by the user. <a href="https://www.hellotech.com/guide/for/how-to-enable-dark-mode-in-windows-10">Here</a> is a quick guide.
  </span>
</details>

<!--System Tray-->
<details>
  <summary><b>Show only in System Tray when minimized</b></summary>
  <ol>
  <li><b>Tick the "Show only in System Tray" Checkbox</b> if you want to hide the application when minimized. </li>
  </ol>
  <span><i><b>Warning:</b></i> If both "Start with Windows" and "Show only in System Tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the System Tray or by running the .exe again.
  </span>
</details>

<!--Show Minimized Info-->
<details>
  <summary><b>Show Ballon tip when minimized</b></summary>
  <p>
  Set this value to false if the balloon item that shows up if the application is minimized to the system tray should not be displayed. Make sure that the focus assist is off.
  </p>
  <p>
  <img src=".\.github\balloonTip.png" alt="Ballon Tip">
  </p>
</details>

<!--Windows-Start-->
<details>
  <summary><b>Start with Windows (Task Scheduler)</b></summary>
  <ol>
  <li>Start the Application with admin rights.</li>
  <li><b>Tick the Checkbox "Start with Windows" in the settings menu.</b></li>
  </ol>
  <span><i><b>Warning:</b></i> If both "Start with Windows" and "Show only in System Tray" are ticked the program is not directly visible to the user and will run in the background. It can still be accessed through the System Tray or by running the .exe again.
  </span>
</details>

<!--Connection lost/established Notification-->
<details>
  <summary><b>Connection lost/established Notification</b></summary>
  <p>
  Set this value to false if the balloon item that shows up if the connection is lost or re-established should not be displayed. Make sure that the focus assist is off.
  </p>
  <p>
  <img src="./.github/connectionLostEstablished.png" alt="Connection lost/established Ballon Tip">
  </p>
</details>

<!--Update Notifications-->
<details>
  <summary><b>Disable Update Notifications</b></summary>
  <ol>
  <li><b>Tick the "Show only in System Tray" Checkbox</b> if you don't want to receive any update notifications</li>
  </ol>
</details>

### Advanced Settings

<!--Double Check Servers Method-->
<details>
  <summary><b>Set the Action on a failed Ping event (Double Check Server)</b></summary>
  <span>
  Select what the program does if there is a failed ping.
  <ul>
    <li><b>None</b>: No double check just write the failed ping to the .txt file.</li>
    <li><b>Same</b>: Double check the same server again and on second fail write to the .txt file.</li>
    <li><b>Google</b>: Double check Google server (8.8.8.8) and note a failed ping if original server didn't respond but Google did. Can only be set if custom servers are used.</li>
    <li><b>Next</b>: Double check the next server and on second fail write the failed ping to the .txt file.</li>
  <ul>
  </span>
</details>

<!--Alternative Ping Method-->
<details>
  <summary><b>Use alternative Ping Method</b></summary>
  <span>
  Set this value to true if you only get the message that the server didn't respond although there is an active internet connection. This error might occur if the ping protocol is blocked by the router or host.
  Request will be send to google.com/generate_204.
  </span>
</details>

<!--Show all Ping Results-->
<details>
  <summary><b>Show all Ping Results</b></summary>
  <span>
  If this value is set to true both successful and unsuccessful pings will be noted. If set to false (default) only unsuccessful pings are recorded.
  </span>
</details>

<!--Use Custom Servers-->
<details>
  <summary><b>Use Custom Servers</b></summary>
  <span>
   Activate this setting if you want to check specific servers. Servers can only be edited if the option is enabled. Only add IP addresses to this list and not domain names (like www.example.com) so the router or DNS server doesn't return a false value. Server can be deleted by highlighting them (with a click) and clicking "Delete". The list can be saved and closed with "Save". "Cancel" will not save the settings. If the program is collecting Data and the servers are changed the collecting process will automatically restart.
   </span>
</details>

### Task Scheduler

<!--Stop application after X days-->
<details>
  <summary><b>Stop the Application after X days</b></summary>
  <span>
  This setting stops the task if the pc is running longer than the value in days. This only applies if the option "Start with Windows" is selected and the application was started by windows itself. If the program is started by the user this setting will not be applied.
  </span>
</details>

<!--Disallow start if on batteries-->
<details>
  <summary><b>Disallow Start if on Batteries</b></summary>
  <span>If this setting is set to true the app will not be launched by the Task Scheduler if the pc is not connected to a power source and is instead running on batteries. Only applies to laptops.
  </span>
</details>

<!--Stop If Going On Batteries-->
<details>
  <summary><b>Stop if going on Batteries</b></summary>
  <span>
  If this setting is set to true the app will stop if the power source is disconnected (running on battery) and the program was started with Windows.
  </span>
</details>

### Update

<!--Download Updates-->
<details>
  <summary><b>Download and Install Updates</b></summary>
  <span>
  New Updates can be installed from the application. If there is a new Update you can click the link to install it.
  </span>
</details>

# FAQ

<details>
  <summary><b>Why does the program tell me that I don't have internet although my internet is working fine? </b></summary>
  <span>Some routers may block the ping protocol. For users experiencing this problem please follow the instructions in "use alternative ping method" under advanced settings in this readme.
  </span>
</details>

<details>
  <summary><b>Why does the program sometimes show that the connection is disrupted?</b></summary>
  <span>A failed ping is noted when two servers (depending on the method set in AdvancedSettings.xml) don't respond within 2.5 seconds. Often this is the result of a packet loss within the users network. A very few servers may also not respond within the given time frame of 2.5 seconds or temporary block the users ip address (ping to death prevention). The severs that come with this program should respond within the time frame and won't block the user. The ping protocol doesn't use TCP which would resend data and instead is using ICMP.
  </span>
</details>
<details>
  <summary><b>How do I use this program to check my servers</b></summary>
  <span>In the settings check the Checkbox "Use Custom Servers". Click the button "Edit Servers". Write the IP address into the textbox and click "Add". Highlight servers to delete them. When using custom servers you can check against google servers. Meaning that a failed ping is only noted if your server (defined in Custom Servers) failed a ping but Google didn't. This can be used to rule out the case that just the computer (on which this program is running) lost connection.
  Make sure to click "Save" in both the "Edit Server" and Settings form to apply the new settings.
  </span>
</details>
<details>
  <summary><b>I found a bug, have a feature request or want to make a proposition for a code change. Where can they be reported?</b></summary>
  <span>Bugs, feature request or code changes can be submitted to GitHub under the <a href="https://github.com/Rllyyy/Internet-Check/issues/new/choose">"Issues"</a> tab.
  </span>
</details>
<details>
  <summary><b>Where are the program files saved?</b></summary>
  <span>
  <ul>
    <li><b>Main Files:</b> <i>C:\Program Files (x86)\4PointsInteractive\Internet-Check</i></li>
    <li><b>connection_issues.txt:</b> <i>C:\Users\UserName\Documents\Internet-Check</i></li>
    <li><b>Updates:</b> <i>C:\Users\UserName\Documents\Internet-Check\Updates</i></li>
    <li><b>User Config:</b> <i>C:\Users\UserName\AppData\Local\4PointsInteractive\Internet_Check.exe_Url_{Hash}\1.0.0.0\user.config</i></li>
  </ul>
  <p>
  Some of these files won't be deleted after an uninstall (.txt, Updates and config).
  </p>
  </span>
</details>

# Legal Note

Although this program uses less than 100 Bytes (0.000100 Megabytes) to ping a server in an interval (of min. 5 seconds) it may be seen as a (D)DOS or ping of death attack.
We therefore advise the user to put in an interval that is bigger or equal to 30 seconds.
The servers we are pinging (Googles DNS and Cloudflare) should handle the request with ease.
For any programmers we advice against increasing the buffer size in the ping method and to only ping servers that are used to higher traffic.
The author is not liable for any claim, damages or other liability whether in an action of contract, tort or otherwise, arising from,
out of or in connection with the software or the use or other dealings in the software. Read the whole license [here](https://github.com/Rllyyy/Internet-Check/blob/master/LICENSE).

# Libraries and other external Software

The following libraries and packages are used (no need to download them):

- Core.System.Configuration.Install from https://github.com/flamencist/Core.System.Configuration.Install
- Newtonsoft.Json from https://github.com/JamesNK/Newtonsoft.Json
- Octokit.net (GitHub API client library) from https://github.com/octokit/octokit.net
- TaskScheduler from https://github.com/dahall/TaskScheduler

      Bugs, feature request or code changes can be submitted to GitHub under the "Issues" tab.
