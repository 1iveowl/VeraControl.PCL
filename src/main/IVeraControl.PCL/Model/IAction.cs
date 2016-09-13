using System;
using VeraControl.Model;

namespace IVeraControl.Model
{
    public interface IAction
    {
        string ActionName { get; }
        string ArgumentName { get; }
        string Value { get; }
        Direction Direction { get; }
        Type Type { get; }
    }
}
