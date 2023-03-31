using airline.management.sharedkernal.Common;
using System;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu.ValueObjects
{
    public class MenuItemId : ValueObject
    {
        private MenuItemId() { }

        public Guid Value { get; private set; }

        private MenuItemId(Guid value)
        {
            Value = value;
        }

        public static MenuItemId CreateUnique()
        {
            // TODO: enforce invariants - check
            return new MenuItemId(Guid.NewGuid());
        }

        public static MenuItemId Create(Guid value)
        {
            // TODO: enforce invariants - check
            return new MenuItemId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
