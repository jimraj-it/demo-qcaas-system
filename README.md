# QC System Demo application:

A system to allow client to submit a string commands for a single qubit, system will submit the valid commands in Quantum runtime and return results. Implemented using .Net 6.0 for rapid developement, saved as solution file to be compile/run in visual studio.

Sample screenshot
![image](https://user-images.githubusercontent.com/109734217/185224490-fd2702b7-fa7a-42d6-85ff-a04a7557acf2.png)

#Getting started

### Development environment setup
- Install [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- Install [Visual Studio 2022](https://docs.microsoft.com/en-us/visualstudio/releases/2022/release-notes)

**Open and Run**
- Open solution file demo-qcaas-system.sln using visual studio
- Build the solution using menu option
![image](https://user-images.githubusercontent.com/109734217/185226708-50321240-c8e8-48c5-be17-f6516fe984b3.png)
- Run WebUI project in IIS Express using below options and click on "Start without Debugging" button or press ctrl + f5
![image](https://user-images.githubusercontent.com/109734217/185226881-14445374-977c-438d-b2fd-99bd935ab526.png)
- New browser window should launch with WebUI for submitting jobs

**Submitting Jobs**
- Input your commands in the text box or use the auto filled values, press submit
- System will validate the input process submitted commands
- Incase of invalid command Error Code 111 will be returned from QC system.
- Results from runtime will be returned as sucess or error codes
![image](https://user-images.githubusercontent.com/109734217/185228047-feecca98-8098-488f-9933-4607a85d04be.png)

**Viewing Logs**
- In visual studio output window select WebUI from the list of ouputs, UI and runtime logs will be displayed here
![image](https://user-images.githubusercontent.com/109734217/185227867-0b7101c4-99e4-409a-b8c8-cd3290aadaa0.png)

