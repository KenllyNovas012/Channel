using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Channels
{
    public class List
    {
        public class Query : IRequest<List<Channel>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Channel>>
        {
            private AplicationDataContext _contex;
            private readonly ILogger<List> _logger;
            public Handler(AplicationDataContext aplicationDataContext, ILogger<List> logger)
            {
                _contex= aplicationDataContext ?? throw new ArgumentNullException(nameof(aplicationDataContext));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }
            public async Task<List<Channel>> Handle(Query request, CancellationToken cancellationToken)
            {
               

                return await _contex.Channels.ToListAsync();
            }
        }
        
    }
}
