# WannaSmile

WannaCry Ransomware is spreading like wild fire. It uses vulnerability in Microsoft's SMB ( which is turned on by default ).

On 13th may 2017 , security researcher going with the handle @malwaretech and Darien Huss found a 'kill-switch' which paused the ransomware. Basically the ransomware opens a unregistered domain and if fail to open then the system is infected. So @malwaretech registered the domain which stopped the ransomware.

Soon Cyber criminals around the world DDOSed it to take it down so that the ransomware can continue affecting. 

**Also the 'kill-switch' won't work if :**
-  System is not connected to internet
-  If the 'kill-switch' domain is down
-  If it is blocked by the isp or firewall

## The solution

**WannaSmile** is a simple program which can solve the problem

It can do the following :

-  It will disable SMB in your system ( which is enabled by default )
-  ( OnlineFix ) It will edit your host file and add google's IP to the **'kill-switch'** ( which means even if the site goes down you wont be affected )
-  ( OfflineFix ) It will create a lightweight local web server and add localhost to **'Kill-switch'**

## Tip

-  Use the OnlineFix if you are always connected to the internet
-  Use the OfflineFix if you are not connected to the internet.






