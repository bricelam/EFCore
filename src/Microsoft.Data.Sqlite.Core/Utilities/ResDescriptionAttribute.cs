// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Resources;

namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class ResDescriptionAttribute : DescriptionAttribute
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager(
            "Microsoft.Data.Sqlite.Properties.Resources",
            typeof(Microsoft.Data.Sqlite.Properties.Resources).Assembly);

        private bool _replaced;

        public ResDescriptionAttribute(string description)
            : base(description)
        {
        }

        public override string Description
        {
            get
            {
                if (!_replaced)
                {
                    DescriptionValue = _resourceManager.GetString(base.Description);
                    _replaced = true;
                }

                return base.Description;
            }
        }
    }
}
