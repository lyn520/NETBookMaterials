using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单的日志程序
{
    public class Test1
    {
        private readonly ILogger<Test1> logger;
        public Test1(ILogger<Test1> logger)
        {
            this.logger = logger;
        }

        public void Test()
        {
            logger.LogTrace("Hello 0");
            logger.LogDebug("Hello 1");
            logger.LogInformation("Hello 2");
            logger.LogWarning("Hello 3");
            logger.LogError("Hello 4");
            logger.LogCritical("Hello 5");
        }
    }
}
