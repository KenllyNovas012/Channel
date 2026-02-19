using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Channels
{
    public class Details
    {
        public class Query : IRequest<Channel>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Channel>
        {
            private AplicationDataContext _context;

            public Handler(AplicationDataContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public async Task<Channel> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Channels.FindAsync(request.Id);
            }
        }
    }
}
