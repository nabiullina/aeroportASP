using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AeroportASP {
    public class MyExceptionAttribute: ExceptionFilterAttribute {
        readonly Log logger;
        public MyExceptionAttribute(Log lg) {
            logger = lg;
        }
        public override void OnException(ExceptionContext context) {
            logger.WriteLog("Message:" + context.Exception.Message);
            logger.WriteLog("Trace: " + context.Exception.StackTrace);
            context.Result = new ViewResult() { ViewName = "Exception" };
        }
    }
}
