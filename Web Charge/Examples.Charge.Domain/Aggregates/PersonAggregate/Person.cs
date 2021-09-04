using Abp.Events.Bus;
using System;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class Person
    {
        public int BusinessEntityID { get; set; }

        public string Name { get; set; }

        public ICollection<PersonPhone> Phones { get; set; }

        public ICollection<IEventData> DomainEvents => throw new NotImplementedException();
    }
}
