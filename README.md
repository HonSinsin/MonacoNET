I am forked from op0x59/MonacoNET , thank a lot

# Monaco.NET
Monaco.NET is a C# Binding for the Monaco Editor.
You can find the Original Monaco Editor (By Microsoft), here on github: https://github.com/Microsoft/monaco-editor

## How It Works
The Control is a WebBrowser that loads a native monaco configuration with features that help with .NET API.

## How to Setup the Editor
You can setup the Monaco.NET Editor by adding the DLL as a Reference.
You can either also add it in your toolbox or create it from code.
You also need the Monaco Folder in your project's bin/release folder.

Example of Creating the Editor using Code:
```CSharp
Monaco.NET.Monaco monaco = new Monaco.NET.Monaco();
monaco.Size = new Size(500, 500);
this.Controls.Add(monaco);
```

## Roadmap
I'm going to be sticking to a specific roadmap of development for Monaco.NET
Here is the Current Roadmap I have planned out:
  - Support for More Bindings and API Features
  - Fixing Bugs
  - Feature Requests
  
This project has been discontinued due to people taking code from this project and claiming it's theirs.
I'll most likely recontinue this sometime, but for now I'm just done with this.

## Images
![GIF1](https://i.imgur.com/ED8wFzC.gif)
