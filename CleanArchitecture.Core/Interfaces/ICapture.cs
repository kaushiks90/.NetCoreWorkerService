using CleanArchitecture.Core.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface ICapture
    {
        void CaptueImage(EntryPointSettings entryPoint);
    }
}
