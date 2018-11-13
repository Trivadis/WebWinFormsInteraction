# WebWinFormsInteraction - An approach to use parts of your legacy app in a modern web app 

This demo was made for an article in the Windows Developer magazine which was printed in November 2018.

The article descripts an approach to migrate a huge legacy pc app to a modern web app step-by-step. To release asap the usage of old functionality in the new app is a good option. Usually it's not possible to migrate code from decades within a year.

In the Demo the web client an the locally installed WinForms app communicate through a SignalR Hub which is also installed on the users computer.

## Prerequisites
- Windows (WinForms)
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
- Restore Nuget Packages
- Run App by Pressing F5. SignalR Hub (Console App), WebAPI (AspNet .NetCore) and WinForms App will be started.

### Explore
- Start "Old App" from the starter form.
- Open the Web App by klicking the button top left.
- Choose and change person in the "New Web App" and observe the synchronization in the old App.
- Press "Edit" on the person -> the old App changes to Edit Mode and appear in front.
- Save... Edit... Change person... close WinForms App (not the Starter Form) -> Web App logs out. Re-open old App -> Web is awailable again...
- ...

## Architecture
In the sequence they usually grow...
*Old WinForms App "DotNetParts.WinFormsFrontend":* ...
*WebAPI "DotNetPartsPersonApi":* ...
*SignalR Hub "DotNetParts.FrontendInteractionHub":* ...
*New Web App "WebFrontend":* ...

## It is
- an inspiration for people having the challenge to migrate huge legacy apps to the web.
- an example how old technologies and web can interact.

## It isn't...
- a general recipe for migrating old apps. 
- a tutorial how to secure a production app.

Check, design, protoype and challenge your situation in your environment! My article in the Windows Developer magazine (December 2018) might give your additional useful thoughts to this topic.
