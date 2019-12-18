using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Abstractions.Notification
{
    public class Ping : INotification
    {
        public Ping(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }


    public class Pong1 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Pong1)} received:{ notification.Name}");
            return Task.CompletedTask;
        }
    }

    public class Pong2 : INotificationHandler<Ping>
    {
        public Task Handle(Ping notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(Pong2)} received:{ notification.Name}");
            return Task.CompletedTask;
        }
    }
}
