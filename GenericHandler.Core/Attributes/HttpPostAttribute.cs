namespace GenericHandler.Core.Attributes
{
    public class HttpPostAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "POST"; }
        }
    }
}