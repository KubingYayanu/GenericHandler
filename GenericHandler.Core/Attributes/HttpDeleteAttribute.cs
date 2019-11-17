namespace GenericHandler.Core.Attributes
{
    public class HttpPutAttribute : HttpVerbAttribute
    {
        public override string HttpVerb
        {
            get { return "PUT"; }
        }
    }
}