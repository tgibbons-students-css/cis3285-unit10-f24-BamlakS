using System.Collections.Generic;
using System.IO;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class StreamTradeDataProvider : ITradeDataProvider
    {
        public StreamTradeDataProvider(Stream stream, ILogger logger)
        {
            this.stream = stream;
            this.logger = logger;
        }

        public async IAsyncEnumerable<string> GetTradeData()
        {
            // var tradeData = new List<string>();
            // logger.LogInfo("Reading trades from file stream.");
            logger.LogInfo("Reading trades from file stream asynchronously.");
            using (var reader = new StreamReader(stream))
            {
                string line;
                // while ((line = reader.ReadLine()) != null)
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    //tradeData.Add(line);
                    yield return line;
                    await Task.Yield();
                }
            }
           // return tradeData;
        }

        private readonly Stream stream;
        private readonly ILogger logger;
    }
}
