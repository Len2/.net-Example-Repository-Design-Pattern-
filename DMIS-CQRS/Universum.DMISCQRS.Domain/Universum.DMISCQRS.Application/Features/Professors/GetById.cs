using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Universum.DMISCQRS.Application.Interfaces;
using static Universum.DMISCQRS.Application.Features.Professors.Get;

namespace Universum.DMISCQRS.Application.Features.Professors
{
    public class GetById
    {
        public class Query : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response>
        {
            private readonly IApplicationDbContext _context;
            public QueryHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var professor = await _context.Professors.FindAsync(request.Id);

                if (professor == null) throw new Exception($"Request Professor with ID {request.Id} has not been found.");

                return new Response
                {
                    FirstName = professor.FirstName,
                    LastName = professor.LastName,
                    Id = professor.Id,
                };
            }
        }

        public class Resposne
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
