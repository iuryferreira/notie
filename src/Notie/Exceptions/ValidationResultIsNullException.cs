using System;

namespace Notie.Exceptions;

/// <summary>
///     The exception is thrown when a null validation result is passed to the method that does not allow this operation.
/// </summary>
public class ValidationResultIsNullException : Exception
{
    private new const string Message = "ValidationResult cannot be null.";

    /// <summary>
    ///     Initialize a new instance of ValidationResultIsNullException with default message.
    /// </summary>
    public ValidationResultIsNullException () : base(Message) { }
}
