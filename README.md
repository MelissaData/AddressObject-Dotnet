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

## Tested Environments

- Windows 64-bit .NET Core 3.1 and .NET 5.0
- Powershell 5.1
- Melissa data files for 2022-10

## Required File(s) and Programs

#### mdAddr.dll

This is the c++ code of the Melissa Data Object

#### Data File(s)
- Addr.dbf
- Congress.csv
- dph256.dte
- dph256.hsa
- dph256.hsc
- dph256.hsf
- dph256.hsn
- dph256.hsv
- dph256.hsx
- ews.txt
- lcd256
- mdAddr.dat
- mdAddr.lic
- mdAddr.nat
- mdAddr.str
- mdAddrKey.db
- mdAddrKeyCA.db
- mdCanada3.db
- mdCanadaPOC.db
- mdLACS256.dat
- mdRBDI.dat
- mdSteLink256.dat
- mdSuiteFinder.db
- month256.dat

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

This project is compatible with both .NET Core 3.1 and .NET 5.0. If you would like to run this project for .NET 5.0, proceed with the following procedures but check for and download .NET 5.0 instead.

#### Install the Dotnet Core SDK
Before starting, make sure that the .NET Core 3.1 SDK has been correctly installed on your machine (If you have Visual Studio installed, you most likely have it already). If you are unsure, you can check by opening a command prompt window and typing the following:

`dotnet --list-sdks`

If the .NET Core 3.1 SDK is already installed, you should see it in the following list:

![alt text](/screenshots/dotnet_output.png)

As long as the above list contains version `3.1.xxx` (underlined in red), then you can skip to the next step. If your list does not contain version 3.1, or you get any kind of error message, then you will need to download and install the .NET Core 3.1 SDK from the Microsoft website.

To download, follow this link: https://dotnet.microsoft.com/en-us/download/dotnet

Select `.NET Core 3.1` and you will be navigated to the download page.

Click and download the `x64` SDK installer for your operating system.

(IMPORTANT: Make sure you download the SDK, NOT the runtime. the SDK contains both the runtime as well as the tools needed to build the project.)

![alt text](/screenshots/.net3.1.JPG)

Once clicked, your web browser will begin downloading an installer for the SDK. Run the installer and follow all of the prompts to complete the installation (your computer may ask you to restart before you can continue). Once all of that is done, you should be able to verify that the SDK is installed with the `dotnet --list-sdks` command.

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

----------------------------------------

#### Different ways to get data file(s)
1. Using Melissa Updater
    - It will handle all of the data download/path and dll(s) for you.
2. If you already have the latest DQS Release (ZIP), you can find the data file(s) and dll(s) in there
    - Use the location of where you've copied/installed the data and update the "$DataPath" variable in the powershell script.
    - Copy all the dll(s) mentioned above into the `MelissaDataAddressObjectWindowsNETExample` project folder.

----------------------------------------

#### Configure Target Framework

Depending on your target .NET framework, you may need to configure the powershell script. In order to do this, open up the `MelissaDataAddressObjectWindowsNETExample.ps1` for editing, proceed to the bottom of the script where you will find this section of code.

Default set for .NET Core 3.1
```
#dotnet publish -f="net5.0" -c Release -o $ProjectPath\Build MelissaDataAddressObjectWindowsNETExample\MelissaDataAddressObjectWindowsNETExample.csproj
dotnet publish -f="netcoreapp3.1" -c Release -o $ProjectPath\Build MelissaDataAddressObjectWindowsNETExample\MelissaDataAddressObjectWindowsNETExample.csproj
```

The target framework is specified with the -f flag found in the command line. If you wish to use the .NET 5.0 framework, please uncomment the line containing that framework and comment out the line containing the .NET Core 3.1 framework (# to comment).

## Run Powershell Script
Parameters:
- -address: a test street address (house number & street name)
- -city (optional): a test city
- -state (optional): a test state
- -zip (optional): a test zip code

    These are convenient when you want to get results for a specific address in one run instead of testing multiple addresses in interactive mode.

- -license (optional): a license string to test the address object 
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

With all parameters:
```
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688"
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -license "<your_license_string>"
```

With any known (optional) parameters:
```
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -state "CA" 
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -state "CA" -license "<your_license_string>"
```

For quiet mode:
```
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -quiet
$ .\MelissaDataAddressObjectWindowsNETExample.ps1 -address "22382 Avenida Empresa" -city "Rancho Santa Margarita" -state "CA" -zip "92688" -license "<your_license_string>" -quiet
```
This is the expected outcome of a successful setup for interactive mode:

![alt text](/screenshots/output.JPG)

## Troubleshooting

Troubleshooting for errors found while running your example program.

### C# Errors:

| Error      | Description |
| ----------- | ----------- |
| ErrorRequiredFileNotFound      | Program is missing a required file. Please check your Data folder and refer to the list of required files above. If you are unable to obtain all required files through the Melissa Updater, please contact technical support below. |
| ErrorDatabaseExpired   | .db file(s) are expired. Please make sure you are downloading and using the latest release version. (If using the Melissa Updater, check powershell script for '$RELEASE_VERSION = {version}' and change the release version if you are using an out of date release).     |
| ErrorFoundOldFile   | File(s) are out of date. Please make sure you are downloading and using the latest release version. (If using the Melissa Updater, check powershell script for '$RELEASE_VERSION = {version}' and change the release version if you are using an out of date release).    |
| ErrorLicenseExpired   | Expired license string. Please contact technical support below. |

## Contact Us

For free technical support, please call us at 800-MELISSA ext. 4
(800-635-4772 ext. 4) or email us at tech@MelissaData.com.

To purchase this product, contact Melissa Data sales department at
800-MELISSA ext. 3 (800-635-4772 ext. 3).
