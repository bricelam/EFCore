// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections;
using Microsoft.EntityFrameworkCore.Tools.Properties;

namespace Microsoft.EntityFrameworkCore.Tools.Commands
{
    // ReSharper disable once ArrangeTypeModifiers
    internal partial class DbContextInfoCommand
    {
        protected override int Execute()
        {
            var result = CreateExecutor().GetContextInfo(Context.Value());

            if (_json.HasValue())
            {
                ReportJsonResult(result);
            }
            else
            {
                ReportResult(result);
            }

            return base.Execute();
        }

        private static void ReportJsonResult(IDictionary result)
        {
            Reporter.WriteData("{");
            Reporter.WriteData("  \"providerName\": " + Json.Literal(result["ProviderName"]) + ",");
            Reporter.WriteData("  \"databaseName\": " + Json.Literal(result["DatabaseName"]) + ",");
            Reporter.WriteData("  \"dataSource\": " + Json.Literal(result["DataSource"]) + ",");
            Reporter.WriteData("  \"options\": " + Json.Literal(result["Options"]) + ",");
            Reporter.WriteData("  \"hasPendingModelChanges\": " + Json.Literal(result["HasPendingModelChanges"]));
            Reporter.WriteData("}");
        }

        private static void ReportResult(IDictionary result)
        {
            Reporter.WriteData(Resources.ProviderName(result["ProviderName"]));
            Reporter.WriteData(Resources.DatabaseName(result["DatabaseName"]));
            Reporter.WriteData(Resources.DataSource(result["DataSource"]));
            Reporter.WriteData(Resources.Options(result["Options"]));

            if (result["HasPendingModelChanges"] as bool? == true)
            {
                Reporter.WriteWarning(Resources.HasPendingModelChanges);
            }
        }
    }
}
