using System.ComponentModel;
using System.Reflection;

namespace GenericHandler.Core
{
    public class OnMethodInvokeArgs : CancelEventArgs
    {
        protected internal OnMethodInvokeArgs(MethodInfo method)
        {
            Method = method;
        }

        public MethodInfo Method { get; private set; }
    }
}