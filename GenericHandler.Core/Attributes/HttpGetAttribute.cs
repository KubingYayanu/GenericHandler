namespace GenericHandler.Core.Attributes
{
    public class HttpGetAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "GET"; }
        }
    }
}