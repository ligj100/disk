using System.Web.Mvc;

namespace disk.Web.Framework.Mvc
{
    public class DiskModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext);
            if (model is BaseDiskModel)
            {
                ((BaseDiskModel)model).BindModel(controllerContext, bindingContext);
            }
            return model;
        }
    }
}
