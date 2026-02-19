using Domain;
using MediatR;
using Persistence;

namespace Application.Channels
{
    public class Create
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Handler: IRequestHandler<Command>
        {
            private readonly AplicationDataContext _context;

            public Handler(AplicationDataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Creación del nuevo objeto Channel con los datos del request
                var channel = new Channel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description
                };

                // Adición del canal al contexto
                _context.Channels.Add(channel);

                // Guardado asíncrono en la base de datos y verificación de éxito
                var success = await _context.SaveChangesAsync() > 0;

                // Si el guardado fue exitoso, retornamos el valor Unit (equivalente a void en MediatR)
                if (success) return Unit.Value;

                throw new Exception("Problema al guardar los cambios");
            }
        }
    }
}
