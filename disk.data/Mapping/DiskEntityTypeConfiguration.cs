using System.Data.Entity.ModelConfiguration;

namespace disk.Data.Mapping
{
    public abstract class DiskEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected DiskEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
            
        }
    }
}