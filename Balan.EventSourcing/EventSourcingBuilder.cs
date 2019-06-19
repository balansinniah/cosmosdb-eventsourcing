using Balan.EventSourcing.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Balan.EventSourcing
{
    public class EventSourcingBuilder : IEventSourcingBuilder
    {
        public EventSourcingBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
