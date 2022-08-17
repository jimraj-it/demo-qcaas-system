using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using QCRuntime;
using QCSystemLib;
using Xunit.Abstractions;


namespace QCSystemLibTest
{
    public class QcSystemTest
    {
        

        [Fact]
        public void Given_QCSystem_Runtime_ExecuteJobs_Returns_Result()
        {
            //Arrange
            var mock = new Mock<IRuntime>();
            mock.Setup(r => r.Execute("X(90), Y(180), Z(90)")).Returns(0);
            IQcSystem qSystem = new QcSystem(mock.Object, getTestLogger());

            // Act
            var result = qSystem.SubmitQcJob("X(90), Y(180), Z(90)");

            // Assert
            Assert.Equal(0, result);

        }

        [Fact]
        public void Given_QCSystem_Runtime_ExecuteJobs_Returns_Error()
        {
            //Arrange
            var mock = new Mock<IRuntime>();
            mock.Setup(r => r.Execute("X(90), Y(180), Z(90)")).Returns(0);
            IQcSystem qSystem = new QcSystem(mock.Object, getTestLogger());

            // Act
            var result = qSystem.SubmitQcJob("InvalidCommand");

            // Assert
            Assert.Equal(111, result);

        }

        private ILogger<QcSystem> getTestLogger()
        {
            //using var logFactory = LoggerFactory.Create(builder => builder.AddFilter("Microsoft", LogLevel.Warning));
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var logFactory = serviceProvider.GetService<ILoggerFactory>();
            return logFactory.CreateLogger<QcSystem>();
        }
    }
}