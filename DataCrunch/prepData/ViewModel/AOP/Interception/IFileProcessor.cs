using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.AOP.Interception
{
    public interface IFileProcessor
    {
        void CheckFile(SupportFile file);
    }
}
