using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using QCRuntime;

namespace QCSystemLib
{
    public class EchoRuntime : IRuntime
    {
        private readonly ILogger<EchoRuntime> _logger;
        public EchoRuntime(ILogger<EchoRuntime> logger) =>
            _logger = logger;


        public int Execute(string job)
        {
            _logger.LogInformation($"EchoRuntime received job : {job}");
            //Adding dummy delay to show the job Processing
             Task.Delay(2000);
             _logger.LogInformation($"EchoRuntime returning fake result: 0");
            return 0;
        }
    }
}
