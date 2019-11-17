using System;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using GenericHandler.Core.Interfaces;
using GenericHandler.Core.Models;

namespace GenericHandler.Core
{
    public abstract partial class BaseHandler : IModelBinder, IHttpHandler, IRequiresSessionState
    {
        public HttpContext context { get; private set; } = null;

        public virtual object GET()
        {
            return "Default GET Response";
        }

        public virtual object POST()
        {
            return "Default POST Response";
        }

        public virtual object PUT()
        {
            return "Default PUT Response";
        }

        public virtual object DELETE()
        {
            return "Default DELETE Response";
        }

        /// <summary>
        /// Intercept the execution right before the handler method is called
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnMethodInvoke(OnMethodInvokeArgs e) { }

        /// <summary>
        /// Intercept the execution right after the handler method is called
        /// </summary>
        public virtual void AfterMethodInvoke(object result) { }

        /// <summary>
        /// Method used to handle the request as a normal ASHX.
        /// To use this method just pass handlerequest=true on the request query string.
        /// </summary>
        /// <param name="context"></param>
        public virtual void HandleRequest() { }

        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            var result = new Result<object>();
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            try
            {
                // it's possible to the requestor to be able to handle everything himself, overriding all this implementation
                string handleRequest = context.Request["handlerequest"];
                if (!string.IsNullOrEmpty(handleRequest) && handleRequest.ToLower() == "true")
                {
                    HandleRequest();
                    return;
                }

                var ajaxCall = new AjaxCallSignature(context);
                if (!string.IsNullOrEmpty(ajaxCall.returnType))
                {
                    switch (ajaxCall.returnType)
                    {
                        case "json":
                            context.Response.ContentType = "application/json";
                            break;

                        case "xml":
                            context.Response.ContentType = "application/xml";
                            break;

                        case "jpg":
                        case "jpeg":
                        case "image/jpg":
                            context.Response.ContentType = "image/jpg";
                            break;

                        default:
                            break;
                    }
                }

                // call the requested method
                result.Data = ajaxCall.Invoke(this, context);

                // if neither on the arguments or the actual method the content type was set then make sure to use the default content type
                if (string.IsNullOrEmpty(context.Response.ContentType) && !SkipContentTypeEvaluation)
                {
                    context.Response.ContentType = DefaultContentType();
                }

                result.Success = true;
                context.Response.Write(jsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                result.Message = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.Write(jsonSerializer.Serialize(result));
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the default content type returned by the handler.
        /// </summary>
        /// <returns></returns>
        public virtual string DefaultContentType()
        {
            return "application/json";
        }

        public void SetResponseContentType(string value)
        {
            context.Response.ContentType = value;
        }

        /// <summary>
        /// Setting this to false will make the handler to respond with exactly what the called method returned.
        /// If true the handler will try to serialize the content based on the ContentType set.
        /// </summary>
        public bool SkipDefaultSerialization { get; set; }

        /// <summary>
        /// Setting this to true will avoid the handler to change the content type wither to its default value or to its specified value on the request.
        /// This is useful if you're handling the request yourself and need to specify it yourself.
        /// </summary>
        public bool SkipContentTypeEvaluation { get; set; }
    }
}