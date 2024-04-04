// See https://aka.ms/new-console-template for more information
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;

Console.WriteLine("== Web Scrapping with DotneCore ====");
////
///1. We need to have 2 nuget packages 1. HtmlAgilityPack and 2. HtmlAgilityPack.CssSelectors.NetCore
///2. we can take any web url and start scrapping required info from it directly using DOM tree.
/// next how to run webpages with Selleneum Web Driver and scrap the contents and why need this scnarios to implement in project ??


var htmlDoc = new HtmlWeb().Load("https://en.wikipedia.org/wiki/List_of_cities_by_GDP");
var rows = htmlDoc.QuerySelectorAll("tbody tr");

for (int i = 2; i < rows.Count; i++)
{
    var cells = rows[i].QuerySelectorAll("td");

    if (cells.Count == 5)
    {
        var dataList = new
        {
            rank = cells[0].InnerHtml.Trim(),
            city = cells[1].InnerHtml.Trim(),
            country = cells[2].InnerHtml.Trim(),
            gdpInBillionUSD = cells[3].InnerHtml.Trim(),
            population = cells[4].InnerHtml.Trim()
            // gdpPerCapita = cells[5].InnerHtml.Trim()
        };

        Console.WriteLine(
              "Rank: " + dataList.rank + "\n"
            + "City: " + dataList.city + "\n"
            + "Country: " + dataList.country + "\n"
            + "GDPInBillionUSD: " + dataList.gdpInBillionUSD + "\n"
            // + "GDPPerCapita: " + dataList.gdpPerCapita + "\n"
            );
    }

}