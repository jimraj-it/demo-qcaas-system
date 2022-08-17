using Microsoft.Extensions.Logging;

namespace QCRuntime
{
    public class Runtime : IRuntime
    {
        private readonly ILogger<Runtime> _logger;

        public Runtime(ILogger<Runtime> logger) =>
            _logger = logger;

        public int Execute(string job)
        {
            _logger.LogInformation($"Runtime received job : {job}");
            //Dummy implementation
            var result = GetRandomNumber();
            return result % 2 == 0 ? 0 : result;
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
}