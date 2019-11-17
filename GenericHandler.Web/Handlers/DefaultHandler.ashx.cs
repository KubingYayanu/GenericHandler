using System;
using System.ComponentModel;
using GenericHandler.Core;
using GenericHandler.Core.Attributes;
using GenericHandler.Web.Models;

namespace GenericHandler.Web.Handlers
{
    /// <summary>
    /// DefaultHandler 的摘要描述
    /// </summary>
    public class DefaultHandler : BaseHandler
    {
        [HttpGet]
        [Description("Greets the name passed as an argument.")]
        public object GreetMe(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)}", $"{nameof(name)} is required.");
            }

            return string.Format("Hello {0}!", name);
        }

        [HttpPost]
        public object SendPersonData(Person person)
        {
            return person;
        }
    }
}