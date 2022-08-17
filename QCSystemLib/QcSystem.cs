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
                _logger.LogInformation($" Executed Runtime for job: {job} returned result {result}");

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
            if (axisInfo.Count != 3) return false;

            var xAngle=axisInfo[0].Substring(2, axisInfo[0].Length-3);
            var yAngle = axisInfo[1].Trim().Substring(2, axisInfo[1].Length - 4);
            var zAngle = axisInfo[2].Trim().Substring(2, axisInfo[2].Length - 4);

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

        public int SubmitQcJobAsync(string job)
        {
            throw new NotImplementedException();
        }

        public int ReadAsyncQcJobStatus(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}