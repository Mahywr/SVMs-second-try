using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVM.VirtualMachine
{
    public interface IVirtualMachine
    {
        
        Stack Stack { get; }
        int ProgramCounter { get; set; }
        
    }
}
