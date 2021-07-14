using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Universum.DMISCQRS.Application.Interfaces;

namespace Universum.DMISCQRS.Application.Features.Students
{
    public class Get
    {
        public class Query : IRequest<IEnumerable<Response>> { }

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Response>>
        {
            private readonly IApplicationDbContext _context;

            public QueryHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<IEnumerable<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Students.Select(student => new Response
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                }).ToListAsync();
            }
        }

        public class Response
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
