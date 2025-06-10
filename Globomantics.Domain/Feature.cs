namespace Globomantics.Domain
{
    public record Feature(string Title ,string Description, string Component , int Priority,User CreatedBy ,User AssignedTo) 
        : TodoTask(Title , DateTime.UtcNow,CreatedBy)
    {
    }
}
