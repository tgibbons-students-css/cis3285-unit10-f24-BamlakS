using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private ITradeDataProvider origProvider;
        public AdjustTradeDataProvider(ITradeDataProvider origProvider)
        {
            this.origProvider = origProvider;
        }
        public async IAsyncEnumerable<string> GetTradeData()
        {
            await foreach (var line in origProvider.GetTradeData())
            {
                // Replace "GBP" with "EUR" in each line
                yield return line.Replace("GBP", "EUR");
            }
            //Call original GetTradeData
            //IEnumerable<string> lines = origProvider.GetTradeData();

            //lines = lines.Select(line => line.Replace("GBP", "EUR"));

            //List<string> result = new List<string>();
            //Change "GBP" to "EUR" in all the text lines

            //foreach (String line in lines)
            //{
            //    String newLine = line.Replace("GBP", "EUR");
            //    result.Add(newLine);
            //}

            //return lines;

        }
    }
}
