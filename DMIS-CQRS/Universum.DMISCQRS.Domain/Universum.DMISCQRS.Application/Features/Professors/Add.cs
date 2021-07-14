using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Universum.DMISCQRS.Application.Interfaces;
using Universum.DMISCQRS.Domain.Entities;

namespace Universum.DMISCQRS.Application.Features.Professors
{
    public class Add
    {
        public class Command : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public DateTime DateOfBirth { get; set; }

            public Professor ToEntity()
            {
                return new Professor
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Address = Address,
                    DateOfBirth = DateOfBirth
                };
            }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly IApplicationDbContext _context;
            private readonly CommandValidator _validator;
            public CommandHandler(IApplicationDbContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _validator = new CommandValidator();
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var validations = _validator.Validate(request);

                if (validations.Errors.Count > 0) throw new Exception("Validations failed");

                _context.Professors.Add(request.ToEntity());

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName)
                    .NotEmpty()
                    .WithMessage("First name is required.")
                    .MaximumLength(50)
                    .WithMessage("First name cannot be longer than 50");

                RuleFor(x => x.LastName)
                    .NotEmpty()
                    .WithMessage("Last name is required.")
                    .MaximumLength(50)
                    .WithMessage("Last name cannot be longer than 50");

                RuleFor(x => x.Address)
                    .NotEmpty()
                    .WithMessage("Address cannot be empty");

                RuleFor(x => x.DateOfBirth)
                    .NotEmpty()
                    .WithMessage("Date of birth cannot be empty.");
            }
        }
    }
}
