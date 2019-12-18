using Abstractions.AsyncRequestHandlers;
using Abstractions.Notification;
using Abstractions.Query;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static Program()
        {
            var services = new ServiceCollection();

            services.AddMediatR(typeof(UserCreateHandler).Assembly);

            var provider = services.BuildServiceProvider();

            _mediator = provider.GetRequiredService<IMediator>();
        }
        private static readonly IMediator _mediator;
        static async Task Main(string[] args)
        {
            // command
            await _mediator.Send(new UserCreateRequest("myesn"));

            // query
            var result = await _mediator.Send(new FindUserByIdQuery(Guid.Empty));
            Console.WriteLine($"find.user.by.id.result: {result.Name}");

            // notification
            await _mediator.Publish(new Ping("myesn"));
        }
    }
}
