# WebWinFormsInteraction - An approach to use parts of your legacy app in a modern web app 

This demo was made for an article in the Windows Developer magazine which was printed in November 2018.

The article descripts an approach to migrate a huge legacy pc app to a modern web app step-by-step. To release asap the usage of old functionality in the new app is a good option. Usually it's not possible to migrate code from decades within a year.

In the Demo the web client an the locally installed WinForms app communicate through a SignalR Hub which is also installed on the users computer.

## Prerequisits
- Visual Studio 2017
- Git: https://git-scm.com/downloads
- Node.js und NPM: https://nodejs.org
- Angular CLI: npm install -g @angular/cli (https://cli.angular.io/)
- Recommended: Visual Studio Code (or similar): https://code.visualstudio.com/Download

## Getting started
### Clone this repo
- Start Command Line Console in the directory you want to have the code
- run `git clone https://github.com/AngularAtTrivadis/WebWinFormsInteraction.git`

### Install and run Webserver for Angular App
- Navigate (cmd) to the folder 'WebFrontend'
- run `code .` to open the folder in VS Code and return to the console
- run `npm install` to restore the node_modules (npm packages)
- run `ng serve`

### Install and run API, SignalR Hub and WinForms App
- Navigate to the folder 'DotNetParts' and open DotNetParts.sln with Visual Studio

### Explore

## Architecture

## What it is

## What it isn't
