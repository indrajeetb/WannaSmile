# Offline fix for WannaCry 
Runs a local server and localhost to the wannaCry kill-switch by appending hosts file. This is done so that when the ransomware tried to connect to the website it does not fail which will eventually stop the ransomware.

## Instructions
- Install the `wannaSmile` service by running the `setup.exe` from [this release](https://github.com/indrajeetb/WannaSmile/releases/tag/0.1). (Download the `wannasmile.zip` file)
- After Installing you need to start the service once and then it will do the rest automatically
- The easiest way to do that is to simply **restart your computer**. *(Recommended)* 

- The other *not so easy* way is to do the following
	- Open start menu
	- Search `services`
	- Open the `Services` desktop app (a gear icon)
	- Inside `Services` search for `WannaSmile` (The list is alphabatical)
	- `right click` on WannaSmile and click `start`
- The service will be running and the wanna cry IPs will be blocked along with the SMBs

## Uninstall Instructions
When you think there is no more danger from wannaCry, you can simply uninstall WannaSmile
- Simply go to `control panel` and click `uninstall a program` and uninstall it.

## Issues
- Other than security concerns there is one [issue](https://github.com/indrajeetb/WannaSmile/issues/1) with the host file appending [HELP WANTED]
