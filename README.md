FileHelper
----

Simple demo project for working with/manipulating XML files.


Requirements
----

Check that you have node and npm installed.


Usage
----

**Installation**
```bash
git clone https://github.com/doctorviolence/FileHelper.git
```

**Run server (@FileHelper.Api)**
```bash
$ dotnet run
```

**Run tests (@FileHelper.Tests)**
```bash
$ dotnet test
```

**Run client (@filehelper.client)**
```bash
$ npm start
```


Notes
----

Note that at the time of writing this program I didn't have access to .NET Framework. I hence wrote it in .NET CORE (ASP.NET MVC) as well as created a simple client in React to make calls to the program.

Design wise I stuck to the SOLID principles and FileHelper.Core contains the logic to solve both tasks. FileCounter counts the no. of XML files in a given directory (Task 1), whereas FileSorter sorts CustomerOrders.xml by order date (Task 2). Both classes were written so that they could easily be scaled in future versions of the program.

In addition, unit tests were written in xUnit and I used System.IO.Abstractions.TestingHelpers to create mock directory trees. A sample of a sorted XML file can be found in the FileHelper.Core.Tests folder.

As for the client, whilst I would have preferred to have written the program in Windows Forms/WPF I had to settle for a web client. Obvious drawbacks to this approach is that the user has to manually type in the directory/file path in order to execute the program instead of simply selecting a folder/file (due to security reasons pertaining to modern browsers...). In future versions of this program this would be the first area of improvement, but I still felt it was necessary to create a simple UI for the program. (Luckily, though, because of the SOLID design choices made in the backend this would be an easy fix!)


Screenshots
----

![screenshot](https://i.imgur.com/zJihwIe.png)
