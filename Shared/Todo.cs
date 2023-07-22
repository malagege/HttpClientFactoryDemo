using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientFactoryDemo.Shared
{

    public record class Todo(
        int UserId,
        int Id,
        string Title,
        bool Completed);
}