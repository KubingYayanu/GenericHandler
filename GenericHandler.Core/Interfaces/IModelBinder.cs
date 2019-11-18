using System.Web;

namespace GenericHandler.Core.Interfaces
{
    public interface IModelBinder
    {
        /// <summary>
        /// Intercept the execution right before authorization is valid
        /// </summary>
        /// <param name="context"></param>
        void ValidateAuthorization(HttpContext context);

        /// <summary>
        /// Intercept the execution right before the handler method is called
        /// </summary>
        /// <param name="e"></param>
        void OnMethodInvoke(OnMethodInvokeArgs e);

        /// <summary>
        /// Intercept the execution right after the handler method is called
        /// </summary>
        /// <param name="result"></param>
        void AfterMethodInvoke(object result);

        void ProcessRequest(HttpContext context);
    }
}