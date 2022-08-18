# QC System Demo application:

A system to allow client to submit a string commands for a single qubit, system will submit the valid commands in Quantum runtime and return results. Implemented using .Net 6.0 for rapid developement, saved as solution file to allow compile/run in visual studio.

Sample screenshot:
![image](https://user-images.githubusercontent.com/109734217/185272920-d92a6b85-defd-4d05-b32f-88099423576a.png)

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

**Run Tests**
- To run tests, go to test explorer tab and click first menu button "Run all"
- Individual tests results or errors can be viewed in summary tab in left side
![image](https://user-images.githubusercontent.com/109734217/185259233-0e2b3610-5120-4ffe-9d1f-1bd8a2307a1c.png)

# Phase 1 : 
**Branch main:**
![image](https://user-images.githubusercontent.com/109734217/185224490-fd2702b7-fa7a-42d6-85ff-a04a7557acf2.png)

# Phase 2 Updates: 
**Branch feature/phase2:**

Three different modes for execution of jobs impleneted, user is allowed to select one of the mode and exeucte his job in it.
- User can select from dropdown and execute the jobs
- Jobs validation logic improved and tested
- UI results and Console logs to reflect the different modes selected
![image](https://user-images.githubusercontent.com/109734217/185272920-d92a6b85-defd-4d05-b32f-88099423576a.png)


# Phase 3 Updates: 
**Branch feature/phase3:**

Asynchrnous job submission and result check is implemented to over point 3 from test. also features from point 5 of test is implemented as user will be able to see historical job details by GetStatus search using jobID and view details.

- User can submit job and Job Id will be displayed in UI for reference
- Aync job will run in the backgorund and user can use UI check feature
- User can enter job Id in the text box and search for it.
- When no match found it will reply Not found in Run time message
- When Job is present in the Runtime history it will return status
- If the job is in progressi it will display corresponding message
- If completed it will print the full detaisl of job with time taken to complete.
- Note: Database implmentation not included, historical data is kept in app for demo purpose.
![image](https://user-images.githubusercontent.com/109734217/185417150-b8bd25f0-f1c5-4871-a195-ecf45c395bb9.png)

