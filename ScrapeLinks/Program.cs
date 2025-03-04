using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        string baseUrl = "https://pcpartpicker.com/products/cpu/";
        string filePath = "cpujsonlinks.txt";

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-blink-features=AutomationControlled");
        options.AddExcludedArgument("enable-automation");

        // Load VPN extension to bypass potential restrictions
        options.AddArgument("--load-extension=C:\\Users\\batuhan.ulukan\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions\\omghfjlpggmjjaagoclmmobgdodcjboh\\3.88.4_0"); // Browsec VPN

        // Create a temporary Chrome user profile directory to avoid tracking
        var tempProfileDir = Path.Combine(Path.GetTempPath(), "SeleniumChromeProfile_" + Guid.NewGuid());
        Directory.CreateDirectory(tempProfileDir);
        options.AddArgument($"--user-data-dir={tempProfileDir}");

        using (var driver = new ChromeDriver(options))
        {
            driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(5000); // Wait for the page to fully load

            // Find the highest page number in pagination
            var paginationLinks = driver.FindElements(By.CssSelector(".pagination a"));
            int lastPage = paginationLinks
                .Select(e => e.Text)
                .Where(text => int.TryParse(text, out _))
                .Select(int.Parse)
                .DefaultIfEmpty(1)
                .Max();

            Console.WriteLine($"Total number of pages: {lastPage}");
            var allLinks = new HashSet<string>();

            for (int i = 1; i <= lastPage; i++)
            {
                string pageUrl = baseUrl + "#page=" + i;
                driver.Navigate().GoToUrl(pageUrl);
                Thread.Sleep(3000); // Wait for the page to fully load

                var productLinks = driver.FindElements(By.CssSelector(".td__name a"));
                foreach (var link in productLinks)
                {
                    string href = link.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        allLinks.Add(href);
                        Console.WriteLine(href);
                    }
                }
            }

            // Write the links to a file
            File.WriteAllLines(filePath, allLinks);
            Console.WriteLine("All product links have been saved: " + filePath);
        }
    }
}

// Note: You can manually adjust this script for different categories by changing the `baseUrl` and modifying the CSS selectors if needed.
// Don't forget to name the jsonlink file according to the category.
