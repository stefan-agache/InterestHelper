using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace InterestHelper.WebDataAccessLayer
{
    internal class HtmlInputProcessor
    {
        private readonly HtmlDocument _document;
        private const string Robor3MHeaderName = "BBZ_BOR3M";
        private const string TableName = "GridView1";
        private const string DateHeaderName = "BBZ_DATA";

        public HtmlInputProcessor(string result)
        {
            _document = new HtmlDocument();
            _document.LoadHtml(result);
        }

        public IEnumerable<Tuple<DateTime, string>> Process()
        {
            var mainDataTable = _document.GetElementbyId(TableName);
            var tableRows = mainDataTable.Descendants("tr").ToList();

            var indexOfDateColumn = tableRows[1].Descendants("td").Select(x => x.InnerText).ToList().IndexOf(DateHeaderName);
            var indexOfRobor3MColumn = tableRows[1].Descendants("td").Select(x => x.InnerText).ToList().IndexOf(Robor3MHeaderName);

            var result = new List<Tuple<DateTime, string>>();
            for (var i = 2; i < tableRows.Count; i++)
            {
                var date = DateTime.Parse(tableRows[i].Descendants("td").ToList()[indexOfDateColumn].InnerText);
                var value = tableRows[i].Descendants("td").ToList()[indexOfRobor3MColumn].InnerText;

                result.Add(new Tuple<DateTime, string>(date, value));
            }

            return result;
        }
    }
}