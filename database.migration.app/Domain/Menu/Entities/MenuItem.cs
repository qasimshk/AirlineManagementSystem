using airline.management.sharedkernal.Common;
using database.migration.app.Domain.Menu.ValueObjects;

namespace database.migration.app.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
#pragma warning disable CS8618
        private MenuItem() { }
#pragma warning restore CS8618

        private MenuItem(
            MenuItemId menuItemId, 
            string name, 
            string description) 
            : base(menuItemId ?? MenuItemId.CreateUnique())
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public static MenuItem Create(
            string name, 
            string description)
        {
            return new(
                MenuItemId.CreateUnique(), 
                name, 
                description);
        }
    }

}
