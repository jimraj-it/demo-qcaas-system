using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCSystemLib
{
    public interface IQcSystem
    {
        public int SubmitQcJob(string job);
        public int SubmitQcJobAsync(string job);
        public int ReadAsyncQcJobStatus(int jobId);
    }
}
