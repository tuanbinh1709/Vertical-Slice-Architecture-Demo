using Refactor.PaymentGate.Api.Abstractions.Exceptions;

namespace Refactor.PaymentGate.Api.Abstractions.Responses;

public sealed class CursorPageResponse<TValue> : PageResponse<TValue>
    where TValue : IResponse
{
    /// <summary>
    /// Current page cursor. Id from which we query records
    /// </summary>
    public string CurrentCursor { get; private init; }

    /// <summary>
    /// Next page cursor. Id of next record to query or Ulid.Empty if the last record was reached
    /// </summary>
    public string NextCursor { get; private init; }

    public CursorPageResponse(IList<TValue> items, string currentCursor, string nextCursor)
        : base(items)
    {
        var notLastPage = nextCursor != string.Empty;
        var invalidCursor = currentCursor.CompareTo(nextCursor) > 0;

        if (notLastPage && invalidCursor)
        {
            throw new BadRequestException($"Selected cursor '{currentCursor}' is greater than next cursor '{nextCursor}'");
        }

        CurrentCursor = currentCursor;
        NextCursor = nextCursor;
    }
}