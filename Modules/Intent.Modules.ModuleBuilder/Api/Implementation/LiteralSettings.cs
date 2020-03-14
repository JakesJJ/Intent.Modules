﻿using System;
using System.Collections.Generic;
using Intent.Metadata.Models;
using Intent.Modules.Common;

namespace Intent.Modules.ModuleBuilder.Api
{
    internal class LiteralSettings : ILiteralSettings
    {
        public const string SpecializationType = "Literal Settings";
        private readonly IElement _element;

        public LiteralSettings(IElement element)
        {
            if (element.SpecializationType != SpecializationType)
            {
                throw new ArgumentException($"Invalid element [{element}]");
            }

            _element = element;

            Icon = IconModel.CreateIfSpecified(element.GetStereotype("Icon (Full)"));
            Text = element.GetStereotypeProperty("Additional Properties", "Text", "New " + element.Name);
            Shortcut = element.GetStereotypeProperty("Additional Properties", "Shortcut", default(string));
            DefaultName = element.GetStereotypeProperty("Additional Properties", "Default Name", default(string));
            AllowRename = element.GetStereotypeProperty<bool>("Additional Properties", "Allow Rename");
            AllowDuplicateNames = element.GetStereotypeProperty<bool>("Additional Properties", "Allow Duplicate Names");
            AllowFindInView = element.GetStereotypeProperty<bool>("Additional Properties", "Allow Find in View");
        }

        public string Id => _element.Id;
        public string Name => _element.Name;
        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public IconModel Icon { get; set; }

        public string Text { get; set; }

        public string Shortcut { get; set; }

        public string DefaultName { get; set; }

        public bool? AllowRename { get; set; } = true;

        public bool? AllowDuplicateNames { get; set; }

        public bool? AllowFindInView { get; set; }

        public override string ToString()
        {
            return $"{nameof(SpecializationType)} = '{SpecializationType}', " +
                   $"{nameof(Text)} = '{Text}'";
        }
    }
}