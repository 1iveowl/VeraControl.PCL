﻿using System;
using System.Threading.Tasks;

namespace IVeraControl.Model
{
    public interface IUpnpStateVariable
    {
        string VariableName { get; set; }
        Type Type { get; set; }
        string Value { get; set; }

        Task<dynamic> GetStateVariable(ConnectionType connectionType);
        Task<string> SetStateVariable(string value, ConnectionType connection);
    }
}
