using System.Collections.Generic;

namespace IVeraControl.Model
{
    public interface IUpnpService
    {
        string ServiceUrn { get; }

        IEnumerable<IAction> Actions { get; set; }
    }
}
