using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVeraControl.Model
{
    public interface IPermission
    {
        int PkPermission { get; }
        int Mode { get; }
    }
}
