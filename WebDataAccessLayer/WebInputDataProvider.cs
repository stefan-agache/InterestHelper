using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InterestHelper.IDataAccessLayer;

namespace InterestHelper.WebDataAccessLayer
{
    public class WebInputDataProvider : IInputDataProvider
    {
        public static readonly string Url = $@"http://www.bnr.ro/StatisticsReportHTML.aspx?icid=800&table=642&column=&startDate={DateTime.Now.AddDays(-7):dd-MM-yyyy}&stopDate={DateTime.Now:dd-MM-yyyy}";

        public async Task<IEnumerable<Tuple<DateTime, string>>> GetRawDataAsync(DateTime start, DateTime end)
        {
            string result = null;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(Url))
            using (var content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }

            var processor = new HtmlInputProcessor(result);
            return processor.Process();
        }
    }
}
