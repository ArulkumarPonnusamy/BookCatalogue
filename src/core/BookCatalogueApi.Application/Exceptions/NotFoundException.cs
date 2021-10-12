using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BookCatalogueApi.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : ApplicationException
    {
        [JsonIgnore]
        public CustomErrors NotFoundError { get; set; }

        protected NotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public NotFoundException(string code, string message)
        {
            NotFoundError = new CustomErrors { Code = code, Message = message };
        }
    }
}
