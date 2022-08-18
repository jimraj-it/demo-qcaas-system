using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using QCRuntime;

namespace QCSystemLib
{
    public class QcSystem : IQcSystem
    {

        private readonly ILogger<QcSystem> _logger;
        private readonly IRuntime _runtime;

        public QcSystem(IRuntime runtime, ILogger<QcSystem> logger) 
        {
            _runtime = runtime;
            _logger = logger;
        }

        public int SubmitQcJob(string job)
        {
            if (ValidateJob(job))
            {
                var result= _runtime.Execute(job);
                _logger.LogInformation($" Executed  job: {job} returned result {result}");

                return result;
            }
            else
            {
                _logger.LogInformation($"Job {job} submitted not viable, please retry with different job input");
                return RuntimeErrors.INVALID_JOB_STRING;
            }
        }

        private bool ValidateJob(string job)
        {
            // Sample validation logic to ensure job is viable, must be reimplemented to validate
            // all boundary conditions using pattern matching
            if (string.IsNullOrEmpty(job) || !job.Contains(",")) return false;

            var axisInfo = job.Split(",").ToList();
            //Return false if three parts are not present
            if (axisInfo.Count != 3) return false;

            var xValue = axisInfo[0].Trim().ToUpper();
            var yValue = axisInfo[1].Trim().ToUpper();
            var zValue = axisInfo[2].Trim().ToUpper();

            //Extract values of Angle for X,Y and Z
            var xAngle= xValue.Substring(xValue.IndexOf("X")+2, xValue.Length-3);
            var yAngle = yValue.Substring(yValue.IndexOf("Y") +2, yValue.Length - 3);
            var zAngle = zValue.Substring(zValue.IndexOf("Z") + 2, zValue.Length - 3);

            if (int.TryParse(xAngle, out var intXAngle) 
                && int.TryParse(yAngle, out var intYAngle) 
                && int.TryParse(zAngle, out var intZAngle)
                && intXAngle is >= 0 and <= 180 && intYAngle is >= 0 and <= 180 && intZAngle is >= 0 and <= 180)
            {
                _logger.LogInformation($"Validated QC job string to be valid, X Angle : {intXAngle}, Y Angle : {intYAngle}, Z Angle : {intZAngle}");
                return true;
            }

            return false;
        }

        public int SubmitQcJobAsync(string job , int jobId)
        {
            if (ValidateJob(job))
            {
                _runtime.ExecuteAsync(job, jobId); 
                _logger.LogInformation($" Submitted Async job: {job} returning in proess result -1");

                return -1;
            }
            else
            {
                _logger.LogInformation($"Job {job} submitted not viable, please retry with different job input");
                return RuntimeErrors.INVALID_JOB_STRING;
            }
        }

        public bool CheckJobComplete(int jobId)
        {
            return _runtime.CheckJobComplete(jobId);
        }

        public bool CheckJobPresent(int jobId)
        {

            return _runtime.CheckJobPresent(jobId);
        }

        public int GetJobStatus(int jobId)
        {
            return _runtime.GetJobStatus(jobId);
        }
        public JobResult? GetJobResult(int jobId)
        {
            return _runtime.GetJobResult(jobId);
        }

        public int ReadAsyncQcJobStatus(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}