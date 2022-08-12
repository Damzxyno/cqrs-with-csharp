using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ZeroToHero.Handlers.Queries
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class BookQuery : IRequest<List<Book>>
    {
        public string Name { get; set; }
    }

    public class BookQueryHandler : IRequestHandler<BookQuery, List<Book>>
    {
        public Task<List<Book>> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            List<Book> list = new List<Book>();
            list.Add(new Book { ID = 1, Name = "Eze goes to school" });
            list.Add(new Book { ID = 2, Name = "Mustapha is hungry" });
            list.Add(new Book { ID = 3, Name = "Na IT dey sell now o!" });

            var tcs = new TaskCompletionSource<List<Book>>();
            tcs.SetResult(list);
            //return tcs.Task;
            return Task.FromResult(list);
        }
    }
}
