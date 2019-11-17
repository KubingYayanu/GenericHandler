using System;

namespace GenericHandler.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public abstract class HttpVerbAttribute : Attribute
    {
        public abstract string HttpVerb { get; }
    }
}