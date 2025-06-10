using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Domain
{
    public record TodoTask(string Title , DateTime DueDate,User CreatedBy) 
        : Todo(Guid.NewGuid(), Title , DateTimeOffset.UtcNow, CreatedBy)
    {
        public DateTime DueDate { get; set; }
    }
}
