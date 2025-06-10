namespace Globomantics.Domain
{
    public record Bug(string title,string Description,Severity Severity , string AffectedVersion
        , int AffectedUsers,User CreatedBy ,User? AssignedTo, IEnumerable<byte[]> Images) 
        : TodoTask(title, DateTimeOffset.MinValue,CreatedBy)
    {

    }
}
