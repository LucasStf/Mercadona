# Mercadona

Mercadona is a website that allow the user to see products in promotion.

It work on Windows, Linux and Mac OS with a web browser.

Url : https://mercadona20230425233536.azurewebsites.net/


# Installation

- [Windows]
```
https://www.mozilla.org/fr/firefox/download/thanks/
```
- [Linux : Ubuntu]
```
sudo apt install flatpak
flatpak remote-add --if-not-exists flathub https://flathub.org/repo/flathub.flatpakrepo
flatpak install flathub org.mozilla.firefox
```
- [Linux : Arch]
```
sudo pacman -S flatpak
flatpak install flathub org.mozilla.firefox
```
- [MacOS]
```
https://www.mozilla.org/fr/firefox/mac/
```

## Building Mercadona from source

### All platforms

- .NET 6 SDK (can be obtained from [here](https://dotnet.microsoft.com/download/dotnet/6.0) - You want the SDK for your platform, Linux users should install via package manager where possible)

#### Windows
Visual Studio : https://visualstudio.microsoft.com/fr/vs/

#### Linux

Visual Studio Code : https://code.visualstudio.com/

Open a terminal and run :

```
dotnet run
```


#### MacOS

Visual Studio Code : https://code.visualstudio.com/

Open a terminal and run :

```
dotnet run
```
