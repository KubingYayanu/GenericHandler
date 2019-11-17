namespace GenericHandler.Core.Attributes
{
    public class HttpDeleteAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "DELETE"; }
        }
    }
}