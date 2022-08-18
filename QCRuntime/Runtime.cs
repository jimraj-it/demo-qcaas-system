using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace QCRuntime
{
    public class Runtime : IRuntime
    {
        private readonly ILogger<Runtime> _logger;

        //Storing job resutls in dictonary temperarly,
        //TODO : results should be saved in database  
        public static Dictionary<int, JobResult> JobResults =  new Dictionary<int, JobResult>();

        public Runtime(ILogger<Runtime> logger) =>
            _logger = logger;

        public int Execute(string job)
        {
            _logger.LogInformation($"Runtime received job : {job}");
            //Dummy implementation
            var result = GetRandomNumber();
            return result % 2 == 0 ? 0 : result;
        }

        public async void ExecuteAsync(string job, int jobId)
        {
            _logger.LogInformation($"Runtime received Async JobId: {jobId}");
            var startTime = DateTime.UtcNow;
            var jobResult = new JobResult(jobId, -1, 0, job);
            JobResults.Add(jobId, jobResult);

            //Adding dummy waits to process longer calls
            await Task.Delay(5000);

            _logger.LogInformation($"Runtime started processing");
            var result=Execute(job);

            //Adding dummy waits 
            await Task.Delay(5000);

            //Adding dummy waits 
            var ts=  DateTime.UtcNow-startTime;
            // var jobResult = new JobResult(jobId, result,(int)ts.TotalMilliseconds, job);
            jobResult.Result = result;
            jobResult.TimeTaken = (int)ts.TotalMilliseconds;
            JobResults[jobId]= jobResult;

            _logger.LogInformation($"Runtime completed processing Result: {jobResult}");
        }

        public bool CheckJobComplete(int jobId)
        {
            return (JobResults.ContainsKey(jobId) && JobResults[jobId].Result >=0);
        }

        public bool CheckJobPresent(int jobId)
        {
            return JobResults.ContainsKey(jobId);
        }


        public int GetJobStatus(int jobId)
        {
            if (CheckJobComplete(jobId))
            {
                return JobResults[jobId].Result;
            }

            return -1;
        }

        public JobResult? GetJobResult(int jobId)
        {
            return CheckJobComplete(jobId) ? JobResults[jobId] : null;
        }

        private static int GetRandomNumber()
        {
            //Dummy implementation to return 0 most of the time, else integer number as error code
            const double maximum = 10;
            const double minimum = 0;
            var random = new Random();
            return (int)Math.Round((random.NextDouble() * (maximum - minimum) + minimum), 0);
        }
    }

    public class JobResult
    {
        public int JobId;
        public int Result;
        public int TimeTaken;
        public string Input;

        public  JobResult(int id, int result, int timeTaken, string input)
        {
            JobId = id;
            Result=result;
            TimeTaken = timeTaken;
            Input = input;
        }

        public new string ToString()
        {
            return ($" Job ID: {JobId}, Input: {Input}, Result: {Result}, TimeTaken in Ms: {TimeTaken}");
        }
    }
}