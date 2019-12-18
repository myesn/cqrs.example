using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.AsyncRequestHandlers
{
    public class UserCreateRequest : IRequest
    {
        public UserCreateRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
    public class UserCreateHandler : AsyncRequestHandler<UserCreateRequest>
    {
        protected override Task Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("user.create.successful");
            return Task.CompletedTask;
        }
    }

    public class PreUserCreate : IRequestPreProcessor<UserCreateRequest>
    {
        public Task Process(UserCreateRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("before.user.create");
            return Task.CompletedTask;
        }
    }

    public class PostUserCreate : IRequestPostProcessor<UserCreateRequest, Unit>
    {
        public Task Process(UserCreateRequest request, Unit response, CancellationToken cancellationToken)
        {
            Console.WriteLine("after.user.create");
            return Task.CompletedTask;
        }
    }
}
