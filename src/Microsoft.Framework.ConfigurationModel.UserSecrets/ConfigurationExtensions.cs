// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Framework.ConfigurationModel.UserSecrets;
using Microsoft.Framework.Internal;

namespace Microsoft.Framework.ConfigurationModel
{
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds the user secrets configuration source.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IConfigurationSourceRoot AddUserSecrets([NotNull]this IConfigurationSourceRoot configuration)
        {
            if (string.IsNullOrEmpty(configuration.BasePath))
            {
                throw new InvalidOperationException(Resources.FormatError_MissingBasePath(
                    configuration.BasePath,
                    typeof(IConfigurationSourceRoot).Name,
                    nameof(configuration.BasePath)));
            }

            var secretPath = PathHelper.GetSecretsPath(configuration.BasePath);
            return configuration.AddJsonFile(secretPath, optional: true);
        }

        /// <summary>
        /// Adds the user secrets configuration source with specified secrets id.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IConfigurationSourceRoot AddUserSecrets([NotNull]this IConfigurationSourceRoot configuration, [NotNull]string userSecretsId)
        {
            var secretPath = PathHelper.GetSecretsPathFromSecretsId(userSecretsId);
            return configuration.AddJsonFile(secretPath, optional: true);
        }
    }
}