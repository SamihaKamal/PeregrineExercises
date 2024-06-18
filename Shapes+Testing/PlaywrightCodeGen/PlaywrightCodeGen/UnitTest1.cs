using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Threading.Tasks;

namespace PlaywrightCodeGen
{
    public class Tests:PageTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            await Page.GotoAsync("http://localhost:58788/");
            await Page.GotoAsync("http://localhost:58788/Product/");
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Screenshots\\Net1.png" });
            await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
            await Page.GetByLabel("Product name").ClickAsync();
            await Page.GetByLabel("Product name").PressAsync("CapsLock");
            await Page.GetByLabel("Product name").FillAsync("C");
            await Page.GetByLabel("Product name").PressAsync("CapsLock");
            await Page.GetByLabel("Product name").FillAsync("se");
            await Page.GetByLabel("Price").ClickAsync();
            await Page.GetByLabel("Price").FillAsync("5");
            await Page.GetByLabel("Description").ClickAsync();
            await Page.GetByLabel("Description").PressAsync("CapsLock");
            await Page.GetByLabel("Description").FillAsync("W");
            await Page.GetByLabel("Description").PressAsync("CapsLock");
            await Page.GetByLabel("Description").FillAsync("cheese");
            await Page.ScreenshotAsync(new PageScreenshotOptions{Path ="Screenshots\\Net2.png"});
            await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
            await Page.ScreenshotAsync(new PageScreenshotOptions { Path = "Screenshots\\Net3.png" });


        }
    }
}