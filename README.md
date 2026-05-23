# Pathfinder Kingmaker Base Mod

## What is this project?

This project is supposed to be used as base for any kind of mod you wish to create.

## Requirements
- Dotnet framework 4.8
- Pathfinder Kingmaker installed
- Unity Mod Manager (UMM)

## How do I create a mod?
In the **Main.cs** file, you will find  an example of dialogue alteration for you to try, there's also a method logger for you to see all the available methods that you can try during your mod creation. There are a lot of methods some may be confusing and/or misleading, that's why I suggest you use AI to filter the methods you may need for your mod and avoid frustration.

### How do I build it?

Since this mod requires dotnet framework, you may build the project using the following commands:

**In the mod's root folder**:
```bash
dotnet clean
dotnet restore
dotnet build -c Release
```

Create a folder for your mod like ```CompanionDialogueExpansion\```, Go to ```bin\Release\``` and copy the .dll file (something like **BaseMod.dll**) and paste it in your mod folder, then create a file named ```info.json``` in your mod folder.

**OBS: the folder name is supposed to be the ```Id``` of the ```info.json``` file.**

An ```info.json``` example:
```json
{
  "Id": "CompanionDialogueExpansion",
  "DisplayName": "Companion Dialogue Expansion",
  "Author": "Your name",
  "Version": "1.0.0",
  "ManagerVersion": "0.22.0",
  "AssemblyName": "BaseMod.dll",
  "EntryMethod": "BaseMod.Main.Load"
}
```

Finishing, your mod folder should be something like this:
```
CompanionDialogueExpansion\
├── BaseMod.dll  
└── info.json
```

To make installable by UMM (Unity Mod Manager) you will need to compress into a zip file, like ```CompanionDialogueExpansion.zip```

### Limitation
Due to the required dotnet framework version, I didn't find a way to build the mod in linux, not even with **mono**.
So as you may have guessed, if you are in linux as I am, you need to create a windows virtual machine to build your mod, if you find a way let me know, so I can update this info.