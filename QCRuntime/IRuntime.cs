using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCRuntime
{
    public interface IRuntime
    {
        public int Execute(string job);

        public void ExecuteAsync(string job, int jobId);

        public bool CheckJobComplete(int jobId);
        public bool CheckJobPresent(int jobId);

        public int GetJobStatus(int jobId);

        public JobResult? GetJobResult(int jobId);

    }
}
