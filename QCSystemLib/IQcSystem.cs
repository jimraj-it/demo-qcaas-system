using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCRuntime;

namespace QCSystemLib
{
    public interface IQcSystem
    {
        public int SubmitQcJob(string job);
        public int SubmitQcJobAsync(string job, int jobId);

        public bool CheckJobComplete(int jobId);
        public bool CheckJobPresent(int jobId);

        public int GetJobStatus(int jobId);

        public JobResult? GetJobResult(int jobId);
    }
}
