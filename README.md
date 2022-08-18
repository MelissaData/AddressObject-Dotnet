# Melissa Data Address Object Windows Example

## Purpose

This is an example of the Melissa Data Address Object using C#

The console will ask the user for:

- Address
- City
- State
- Zip

And return 

- Melissa Address Key (MAK)
- Address Line 1
- Address Line 2
- City
- State
- Zip
- ResultCodes

----------------------------------------

## Tested Environments

- Windows 64-bit .NET Core 3.1
- Powershell 5.1
- Melissa data files for 2022-07

----------------------------------------

## Required Files and Programs

#### mdAddr.dll*

This is the c++ code of the Melissa Data Object

#### mdAddrNET.dll*

This file needs to be added as a Project Dependency. This wrapper will need to be in the same directory as the program using it.

(*) These files will be downloaded by the Melissa Updater!

#### Data Files
- mdAddr.nat
- mdAddr.str
- mdAddr.dat
- mdAddr.lic
- mdCanada3.db
- dph.dte
- dph.hsa
- dph.hsc
- dph.hsf
- dph.hsv
- dph.hsx
- lcd
- month.dat
- mdLACS.dat
- mdSteLink.dat
- mdRBDI.dat
- mdSuiteFinder.db

----------------------------------------

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

#### Install the Dotnet Core SDK
Before starting, make sure that the .NET Core 3.1 SDK has been correctly installed on your machine (If you have Visual Studio installed, you most likely have it already). If you are unsure, you can check by opening a command prompt window and typing the following:

`dotnet --list-sdks`

If the .NET Core 3.1 SDK is already installed, you should see it in the following list:

![alt text](/screenshots/dotnet_output.png)

As long as the above list contains version `3.1.xxx` (underlined in red), then you can skip to the next step. If your list does not contain version 3.1, or you get any kind of error message, then you will need to download and install the .NET Core 3.1 SDK from the Microsoft website.

To download, follow this link: https://dotnet.microsoft.com/download

On the webpage, make sure you click the button that says `Download .NET Core SDK x64`:

(IMPORTANT: Make sure you download the SDK, NOT the runtime. the SDK contains both the runtime as well as the tools needed to build the project.)

![alt text](/screenshots/microsoft_website_ss.png)

Once clicked, your web browser will begin downloading an installer for the SDK. Run the installer and follow all of the prompts to complete the installation (your computer may ask you to restart before you can continue). Once all of that is done, you should be able to verify that the SDK is installed with the `dotnet --list-sdks` command.

----------------------------------------

#### Set up Powershell settings

If running Powershell for the first time, you will need to run this command in the Powershell console: `Set-ExecutionPolicy RemoteSigned`.
The console will then prompt you with the following warning shown in the image below. 
 - Enter `'A'`. 
 	- If successful, the console will not output any messages. (You may need to run Powershell as administrator to enforce this setting).
	
 ![alt text](/screenshots/powershell_executionpolicy.png)

----------------------------------------

#### Download this project
```
$ git clone https://github.com/MelissaData/AddressObject-Dotnet.git
$ cd AddressObject-Dotnet
```

#### Set up Melissa Updater

Melissa Updater is a CLI application allowing the user to update their Melissa applications/data.
- Download Melissa Updater here: <https://releases.melissadata.net/Download/Library/WINDOWS/NET/ANY/latest/MelissaUpdater.exe>
- Create a folder within the cloned repo called `MelissaUpdater`.
- Put `MelissaUpdater.exe` in the `MelissaUpdater` folder you've just created.

#### Different ways to get data files
1. Using Melissa Updater
    - It will handle all of the data download/path and dlls for you.
2. If you already have the latest DQS Release (ZIP), you can find the data files and dlls in there.
    - Use the location of where you've copied/installed the data and update the "$DataPath" variable in the powershell script.
    - Copy all the dlls mentioned above into the `MelissaDataAddressObjectWindowsNETExample` project folder.

----------------------------------------

## Run Powershell Script
Parameters:
- -address (optional): a test street address (house number & street name)
- -city (optional): a test city
- -state (optional): a test state
- -zip (optional): a test zip code

    These are convenient when you want to get results for a specific address in one run instead of testing multiple addresses in interactive mode.
- -license (optional): your license string
- -quiet (optional): add to command if you do not want to get any console output from the Melissa Updater

When you have modified the script to match your data location, let's run the script.
There are two modes:
- Interactive
    
    The script will prompt the user for an address, city, state, and zip, then use the provided inputs to test Address Object. For example:
    ```
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1
    ```
    For quiet mode:
    ```
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1 -quiet
    ```
- Command Line

    You can pass an address, city, state, zip, and a license string into the ```-address```, ```-city```, ```-state```, ```-zip```, and ```-license``` parameters respectively to test Address Object. For example:
    ```
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -license "<your_license_string>"
    or for any known (optional) parameters:
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -state "CA" 
    ```
    For quiet mode:
    ```
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -quiet
    $ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -license "<your_license_string>" -quiet
    ```
This is the expected outcome of a successful setup for interactive mode:

![alt text](/screenshots/output.JPG)

----------------------------------------

## Troubleshooting

Troubleshooting for errors found while running your example program.

### C# Errors:

| Error      | Description |
| ----------- | ----------- |
| ErrorRequiredFileNotFound      | Program is missing a required file. Please check your Data folder and refer to the list of required files above. If you are unable to obtain all required files through the Melissa Updater, please contact technical support below. |
| ErrorDatabaseExpired   | .db file(s) are expired. Please make sure you are downloading and using the latest release version. (If using the Melissa Updater, check powershell script for '$RELEASE_VERSION = {version}' and change the release version if you are using an out of date release).     |
| ErrorFoundOldFile   | File(s) are out of date. Please make sure you are downloading and using the latest release version. (If using the Melissa Updater, check powershell script for '$RELEASE_VERSION = {version}' and change the release version if you are using an out of date release).    |
| ErrorLicenseExpired   | Expired license string. Please contact technical support below. |

----------------------------------------

## Contact Us

For free technical support, please call us at 800-MELISSA ext. 4
(800-635-4772 ext. 4) or email us at tech@MelissaData.com.

To purchase this product, contact Melissa data sales department at
800-MELISSA ext. 3 (800-635-4772 ext. 3).
