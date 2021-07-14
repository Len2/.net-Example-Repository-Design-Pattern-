using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Universum.DMISCQRS.Application.Interfaces;

namespace Universum.DMISCQRS.Application.Features.Professors
{
    public class Get
    {
        public class Query : IRequest<IEnumerable<Response>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, IEnumerable<Response>>
        {
            private readonly IApplicationDbContext _context;
            public QueryHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<IEnumerable<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Professors.Select(prof => new Response
                {
                    Id = prof.Id,
                    FirstName = prof.FirstName,
                    LastName = prof.LastName
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
