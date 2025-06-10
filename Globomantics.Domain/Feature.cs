namespace Globomantics.Domain
{
    public record Feature(string Title ,string Description, string Component ,DateTimeOffset DueDate, int Priority,User CreatedBy ,User AssignedTo) 
        : TodoTask(Title , DueDate,CreatedBy)
    {
    }
}
