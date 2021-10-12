using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using FluentValidation.Results;

namespace BookCatalogueApi.Application.Exceptions
{
    public class CustomErrors
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    [Serializable]
    public class ValidationException : ApplicationException
    {
        [JsonIgnore]
        public List<CustomErrors> ValidationErrors { get; set; }

        public string BaseErrorMessage { get; set; }
        public string BaseErrorCode { get; set; }

        protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public ValidationException(List<ValidationFailure> validationResult)
        {

            ValidationErrors = new List<CustomErrors>();

            foreach (ValidationFailure validationError in validationResult)
            {
                ValidationErrors.Add(new CustomErrors { Code = validationError.ErrorCode, Message = validationError.ErrorMessage });
            }
        }

        public ValidationException(string code, string message)
        {
            ValidationErrors = new List<CustomErrors>
            {
                new CustomErrors { Code = code, Message = message }
            };
        }
    }
}
