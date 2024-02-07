using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DromAutotest.Pages;

namespace DromAutotest
{
    class DromAutotests
    {
        
        static void Main()
        {            
        }
 }

class DromTests
    {
        private IWebDriver driver;

        

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("http://auto.drom.ru/");
            driver.Manage().Window.Maximize();
        }
         

        [Test]
        [TestCase(Description = "2.1")]
        public void Filtering_Test()
        {
            var autoDromPage = new AutoDromPage(driver);
            //Фильтр Марка = Toyota
            autoDromPage.ChooseBrandFilter();

            //Фильтр Модель = Harrier
            autoDromPage.ChooseModelFilter();

            //Фильтр Топливо - Гибрид
            autoDromPage.ChooseFuelTypeFilter();

            //Фильтр Непроданнные
            autoDromPage.ActivateUnsoldCheckbox();

            //Раскрывает фильтры расширенного поиска
            autoDromPage.OpenAdvancedFilters();

            //Фильтр Пробег от,км.
            autoDromPage.ApplyMileageFromFilter();

            //Фильтр Год от
            autoDromPage.ApplyYearFromFilter();
        }
    }
}
