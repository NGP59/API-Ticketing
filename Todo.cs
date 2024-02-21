namespace Ticketing
{
    public record Todo(int id, string titre, DateTime startDate, DateTime? endDate = null);
}