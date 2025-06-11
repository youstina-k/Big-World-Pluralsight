namespace Globomantics.Domain
{
    public record Bug(string title,string Description,Severity Severity , string AffectedVersion
        , int AffectedUsers,User CreatedBy ,User? AssignedTo) 
        : TodoTask(title, DateTime.UtcNow,CreatedBy)
    {

    }
}
