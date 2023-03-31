using airline.management.sharedkernal.Common;
using database.migration.app.Domain.Menu.Entities;
using database.migration.app.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();

        private Menu() {}

        private Menu(
            MenuId menuId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections)
            : base(menuId)
        {
            Name = name;
            Description = description;            
            AverageRating = averageRating;
            _sections = sections;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public AverageRating AverageRating { get; private set; }

        public string ReferenceNumber { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public static Menu Create(
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                AverageRating.CreateNew(),
                sections ?? new());
        }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }
    }
}
