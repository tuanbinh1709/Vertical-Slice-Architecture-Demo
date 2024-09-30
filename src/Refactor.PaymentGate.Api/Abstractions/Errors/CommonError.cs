namespace Refactor.PaymentGate.Api.Abstractions.Errors;

public sealed partial class Error
{
    /// <summary>
    /// Create an Error based on the entity type name and the id that was not found
    /// </summary>
    /// <param name="name">name of the entity type. Use "nameof(TValue)" syntax</param>
    /// <param name="id">id of the entity that was not found</param>
    /// <returns>NotFound error</returns>
    public static Error NotFound<TEntity>(int id)
        where TEntity : EntityBase
    {
        return New($"{typeof(TEntity).Name}.{nameof(NotFound)}", $"{typeof(TEntity).Name} with id '{id}' was not found.");
    }

    /// <summary>
    /// Create an NotFound Error based on the entity type name and the unique value
    /// </summary>
    /// <param name="name">name of the entity type. Use "nameof(TValue)" syntax</param>
    /// <param name="uniqueValue">unique value of the entity that was not found</param>
    /// <returns>NotFound error</returns>
    public static Error NotFound<TEntity>(string uniqueValue)
        where TEntity : EntityBase
    {
        return New($"{typeof(TEntity).Name}.{nameof(NotFound)}", $"{typeof(TEntity).Name} for '{uniqueValue}' was not found.");
    }

    /// <summary>
    /// Create an NotFound Error based on the entity type name and the unique value
    /// </summary>
    /// <param name="name">name of the entity type. Use "nameof(TValue)" syntax</param>
    /// <param name="uniqueValue">unique value of the entity that was not found</param>
    /// <returns>NotFound error</returns>
    public static Error NotFound(string subjectToFind, string uniqueValue, string additionalMessage)
    {
        return New($"{subjectToFind}.{nameof(NotFound)}", $"{subjectToFind} for '{uniqueValue}' was not found. {additionalMessage}");
    }

    /// <summary>
    /// Create an Error based on the unique key
    /// </summary>
    /// <param name="key">unique key of the entity that is already in the database</param>
    /// <returns>AlreadyExists error</returns>
    public static Error AlreadyExists<TUniqueKey>(TUniqueKey key)
        where TUniqueKey : class
    {
        return New($"{typeof(TUniqueKey).Name}.{nameof(AlreadyExists)}", $"{typeof(TUniqueKey).Name} '{key}' already exists.");
    }

    /// <summary>
    /// Create an Error based on the unique key
    /// </summary>
    /// <param name="key">unique key of the entity that is already in the database</param>
    /// <returns>AlreadyExists error</returns>
    public static Error AlreadyExists(string subject, string key)
    {
        return New($"{subject}.{nameof(AlreadyExists)}", $"{subject} '{key}' already exists.");
    }

    /// <summary>
    /// Create an Error describing that the Entity has <paramref name="keyOne"/> and <paramref name="keyTwo"/> value already exists 
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <param name="uniqueValue">Unique value</param>
    /// <returns>AlreadyExists error</returns>
    public static Error AlreadyExists<TEntity>(string uniqueValue)
        where TEntity : EntityBase
    {
        return New($"{typeof(TEntity).Name}.{nameof(AlreadyExists)}", $"The {typeof(TEntity).Name} have '{uniqueValue}' already exists.");
    }

    /// <summary>
    /// Create an Error describing that the collection is null or empty
    /// </summary>
    /// <returns>NullOrEmpty error</returns>
    public static Error NullOrEmpty(string collectionName)
    {
        return New($"{collectionName}.{nameof(NullOrEmpty)}", $"{collectionName} is null or empty.");
    }

    /// <summary>
    /// Create an Error describing that the batch command is invalid
    /// </summary>
    /// <returns>InvalidBatchCommand error</returns>
    public static Error InvalidBatchCommand(string batchCommand)
    {
        return New($"{batchCommand}.{nameof(InvalidBatchCommand)}", $"{batchCommand} is invalid.");
    }

    /// <summary>
    /// Create an Error describing that the invalid operation was invoked
    /// </summary>
    /// <returns>InvalidOperation error</returns>
    public static Error InvalidOperation(string message)
    {
        return New($"{nameof(InvalidOperation)}", message);
    }

    /// <summary>
    /// Create an Error describing that the request is duplicated (same key)
    /// </summary>
    /// <returns>DuplicatedRequest error</returns>
    //public static Error DuplicatedRequest<TBusinessKey>(TBusinessKey key)
    //    where TBusinessKey : IUniqueKey
    //{
    //    return New($"{nameof(DuplicatedRequest)}", $"Duplicated request for key '{key}'.");
    //}

    /// <summary>
    /// Create an Error from the thrown exception
    /// </summary>
    /// <param name="exceptionMessage">Exception message</param>
    /// <returns>Exception error</returns>
    public static Error Exception(string exceptionMessage)
    {
        return New($"{nameof(Exception)}", exceptionMessage);
    }

    /// <summary>
    /// Create an Error describing that value was not parsed properly
    /// </summary>
    /// <param name="errorMessage">Exception message</param>
    /// <returns>ParseFailure error</returns>
    public static Error ParseFailure<ParseType>(string valueParsedName)
    {
        return New($"{nameof(ParseFailure)}", $"Parsing '{valueParsedName}' to type '{nameof(ParseType)}' failed.");
    }
}
