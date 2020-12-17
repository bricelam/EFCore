// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Resources;

namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class ResCategoryAttribute : CategoryAttribute
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager(
            "Microsoft.Data.Sqlite.Properties.Resources",
            typeof(Microsoft.Data.Sqlite.Properties.Resources).Assembly);

        public ResCategoryAttribute(string category)
            : base(category)
        {
        }

        protected override string GetLocalizedString(string value)
            => _resourceManager.GetString(value);
    }
}
