using airline.management.sharedkernal.Common;
using System;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuId() {}

        private MenuId(Guid value)
        { 
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            // TODO: enforce invariants - check
            return new MenuId(Guid.NewGuid());
        }

        public static MenuId Create(Guid value)
        {
            // TODO: enforce invariants - check
            return new MenuId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
