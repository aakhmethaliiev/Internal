using log4net;
using log4net.Config;

namespace AddLog4Net
{
    public class Bar
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Bar));

        public void DoIt()
        {
            log.Debug("Did it again!");
        }
    }
}
