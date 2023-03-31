using airline.management.sharedkernal.Common;
using System;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu.ValueObjects
{
    public class MenuSectionId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuSectionId() { }

        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            // TODO: enforce invariants - check
            return new MenuSectionId(Guid.NewGuid());
        }

        public static MenuSectionId Create(Guid value)
        {
            // TODO: enforce invariants - check
            return new MenuSectionId(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
