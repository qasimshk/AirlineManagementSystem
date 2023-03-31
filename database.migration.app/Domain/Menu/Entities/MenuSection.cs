﻿using airline.management.sharedkernal.Common;
using database.migration.app.Domain.Menu.ValueObjects;
using System.Collections.Generic;

namespace database.migration.app.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

#pragma warning disable CS8618
        private MenuSection() { }
#pragma warning restore CS8618

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items) 
            : base(menuSectionId ?? MenuSectionId.CreateUnique())
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem>? items = null)
        {
            return new(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items);
        }
    }
}
