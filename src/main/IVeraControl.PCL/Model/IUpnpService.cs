using System.Collections.Generic;

namespace IVeraControl.Model
{
    public interface IUpnpService
    {
        string ServiceUrn { get; }

        string ServiceName { get;}

        IEnumerable<IUpnpAction> Actions { get; set; }
    }
}
