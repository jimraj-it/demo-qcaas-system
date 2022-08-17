
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using QCRuntime;
using Xunit.Abstractions;

namespace QCRuntimeTest
{
    public class RuntimeTest
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

            var logger = logFactory.CreateLogger<Runtime>();
            

            IRuntime runtime= new Runtime(logger);

            // Act
            var result = runtime.Execute("X(90), Y(180), Y(90)");

            // Assert
            Assert.True( result is >= 0 and <= 100 );

        }
    }
}