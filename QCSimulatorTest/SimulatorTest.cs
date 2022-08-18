using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QCRuntime;
using QCSimulator;

namespace QCSimulatorTest
{
    public class SimulatorTest
    {

        [Fact]
        public void GivenRuntime_ExecuteJob_ReturnsIntResult()
        {
            //Arrange
            //using var logFactory = LoggerFactory.Create(builder => builder.AddFilter("Microsoft", LogLevel.Warning));
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var logFactory = serviceProvider.GetService<ILoggerFactory>();

            var logger = logFactory.CreateLogger<Simulator>();


            IRuntime runtime = new Simulator(logger);

            // Act
            var result = runtime.Execute("X(90), Y(180), Y(90)");

            // Assert
            Assert.True(result is >= 0 and <= 100);

        }
    }
}