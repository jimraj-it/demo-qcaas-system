﻿using Microsoft.Extensions.Logging;
using QCRuntime;

namespace QCSimulator
{
    public class Simulator : IRuntime
    {
        private readonly ILogger<Simulator> _logger;

        public Simulator(ILogger<Simulator> logger) =>
            _logger = logger;

        

        public int Execute(string job)
        {
            _logger.LogInformation($"Simulator received job : {job}");
            //Dummy implementation
            var result = GetRandomNumber();
            return result % 2 == 0 ? 0 : result;
        }

        public void ExecuteAsync(string job, int jobId)
        {
            throw new NotImplementedException();
        }

        public bool CheckJobComplete(int jobId)
        {
            throw new NotImplementedException();
        }

        public bool CheckJobPresent(int jobId)
        {
            throw new NotImplementedException();
        }

        public int GetJobStatus(int jobId)
        {
            throw new NotImplementedException();
        }

        public JobResult? GetJobResult(int jobId)
        {
            throw new NotImplementedException();
        }

        private static int GetRandomNumber()
        {
            //Dummy implementation to return 0 most of the time, else integer number as error code
            const double maximum = 20;
            const double minimum = 11;
            var random = new Random();
            return (int)Math.Round((random.NextDouble() * (maximum - minimum) + minimum), 0);
        }
    }
}