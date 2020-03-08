using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.WebApi.Contract
{
    [JsonObject("error")]
    public class Error
    {
        public const string TYPE_AUTHENTICATION = "AUTHENTICATION";
        public const string TYPE_NOT_FOUND = "NOT FOUND";
        public const string TYPE_BAD_REQUEST = "BAD REQUEST";
        public const string TYPE_INTERNAL_SERVER = "INTERNAL SERVER";
        public const string TypeGatewayTimeout = "GATEWAY TIMEOUT";
        public const string TYPE_AUTHORISATION = "AUTHORISATION";

        private List<string> _messages;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName ="type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "httpStatusCode")]
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "messages")]
        public List<string> Messages { get { return _messages ?? new List<string>(); } set { _messages = value; } }

        #region Creation Helpers

        /// <summary>
        /// Creates a new instance of Error prepopulated for Authentication errors
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static Error CreateAuthenticationError(List<string> messages)
        {
            Error result = new Error();

            result.Type = TYPE_AUTHENTICATION;
            result.HttpStatusCode = 401;
            result.Messages = messages;

            return result;
        }

        /// <summary>
        /// Creates a new instance of Error prepopulated for NotFound errors
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static Error CreateNotFoundError(List<string> messages)
        {
            Error result = new Error();

            result.Type = TYPE_NOT_FOUND;
            result.HttpStatusCode = 404;
            result.Messages = messages;

            return result;
        }

        /// <summary>
        /// Creates a new instance of Error prepopulated for BadRequest errors
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static Error CreateBadRequestError(List<string> messages)
        {
            Error result = new Error();

            result.Type = TYPE_BAD_REQUEST;
            result.HttpStatusCode = 400;
            result.Messages = messages;

            return result;
        }

        /// <summary>
        /// Creates a new instance of Error prepopulated for Forbidden errors
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static Error CreateForbiddenError(List<string> messages)
        {
            var result = new Error
            {
                Type = TYPE_AUTHORISATION,
                HttpStatusCode = 403,
                Messages = messages
            };

            return result;
        }

        public static Error CreateInternalServerError(List<string> messages)
        {
            Error result = new Error();

            result.Type = TYPE_INTERNAL_SERVER;
            result.HttpStatusCode = 500;
            result.Messages = messages;

            return result;
        }

        /// <summary>
        /// Creates a new instance of Error prepopulated for NotFound errors
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static Error CreateGatewayTimeoutError(List<string> messages)
        {
            Error result = new Error();

            result.Type = TypeGatewayTimeout;
            result.HttpStatusCode = 504;
            result.Messages = messages;

            return result;
        }
        #endregion

        /// <summary>
        /// Check if two instances of Error are the same by comparing their properties
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool result = false;

            if (obj is Error)
            {
                Error other = (Error)obj;

                result = Equals(other.HttpStatusCode, this.HttpStatusCode) &&
                            Equals(other.Type, this.Type);

                result = result && other.Messages.SequenceEqual(this.Messages);
            }

            return result;
        }
    }
}
