using System.Collections.Generic;
using disk.Core.Configuration;

namespace disk.Core.Domain.Security
{
    public class SecuritySettings : ISettings
    {

        /// <summary>
        /// Gets or sets an encryption key
        /// </summary>
        public string EncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets a list of adminn area allowed IP addresses
        /// </summary>
        public List<string> AdminAreaAllowedIpAddresses { get; set; }
    }
}