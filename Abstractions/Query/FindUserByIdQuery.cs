using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Query
{
    public class FindUserByIdQuery : IRequest<FindUserByIdQueryResult>
    {
        public FindUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class FindUserByIdQueryResult
    {
        public string Name { get; set; }
    }

    public class FindUserByIdQueryHandler : IRequestHandler<FindUserByIdQuery, FindUserByIdQueryResult>
    {
        public Task<FindUserByIdQueryResult> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new FindUserByIdQueryResult
            {
                Name = "myesn"
            });
        }
    }
}
