using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class UserDataViewModel
    {
        public int PK { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
