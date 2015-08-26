using System;
using disk.Core;
using disk.Core.Data;

namespace disk.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new DiskException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                    
                case "sqlserver":
                    return new SqlServerDataProvider();
                /*case "sqlce":
                    return new SqlCeDataProvider();
                     * */
                case "mysql":
                    return new MySqlServerDataProvider();
                default:
                    throw new DiskException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
