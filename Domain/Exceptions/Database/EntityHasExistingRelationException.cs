using System;

namespace Domain.Exceptions.Database;

public class EntityHasExistingRelationException: Exception
{
    public EntityHasExistingRelationException() { }
    public EntityHasExistingRelationException(string message) : base(message) { }
    public EntityHasExistingRelationException(string message, Exception innerException)
        : base(message, innerException) { }
}