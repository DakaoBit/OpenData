using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    [Serializable]
    public class ExecuteResultModel
    {
        public bool isSuccess { get; set; }

        public List<string> message = new List<string>();
    }
}
