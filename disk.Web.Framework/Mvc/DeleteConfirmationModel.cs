namespace disk.Web.Framework.Mvc
{
    public class DeleteConfirmationModel : BaseDiskEntityModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string WindowId { get; set; }
    }
}