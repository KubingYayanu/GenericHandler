using System;
using System.ComponentModel;
using GenericHandler.Core;
using GenericHandler.Core.Attributes;
using GenericHandler.Core.Models;
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

            var result = new Result { Success = true, Message = $"Hello {name}!" };

            return result;
        }

        [HttpPost]
        public object SendPersonData(Person person)
        {
            var result = new Result<Person> { Success = true, Data = person };

            return result;
        }
    }
}