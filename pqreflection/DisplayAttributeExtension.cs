﻿using System.ComponentModel.DataAnnotations;

namespace pqreflection
{
    // The extension methods from this class are typically used on enum members that use 'DataAnnotations.DisplayAttribute'
    // and may otherwise be used by any member that is using 'DisplayAttribute'.
    public static class DisplayAttributeExtension
    {
        static AttributeHelper _attributeHelper = new AttributeHelper();

        // Gets 'DisplayAttribute.Description' for the 'member'.
        public static string GetDescription<T>(this T member)
        {
            bool success = _attributeHelper.TryGetSpecifiedAttribute(member, out DisplayAttribute attribute);
            if (success && !string.IsNullOrEmpty(attribute?.Description))
                return attribute.Description;
            return string.Empty;
        }

        // Gets 'DisplayAttribute.Name' for the 'member'.
        public static string GetName<T>(this T member)
        {
            bool success = _attributeHelper.TryGetSpecifiedAttribute(member, out DisplayAttribute attribute);
            if (success && !string.IsNullOrEmpty(attribute?.Name))
                return attribute.Name;
            return string.Empty;
        }

        // Gets 'DisplayAttribute.ShortName' for the 'member'.
        public static string GetShortName<T>(this T member)
        {
            bool success = _attributeHelper.TryGetSpecifiedAttribute(member, out DisplayAttribute attribute);
            if (success && !string.IsNullOrEmpty(attribute?.ShortName))
                return attribute.ShortName;
            return string.Empty;
        }
    }
}
