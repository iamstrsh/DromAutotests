﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DromAutotest.Pages
{
    class AutoDromPage
    {
        private IWebDriver driver;

        //Элементы страницы
        private readonly By _brandFilter = By.XPath("//input[@placeholder='Марка']");
        private readonly By _brandToyota = By.XPath("//div[contains(text(), 'Toyota') and @role='option']");
        private readonly By _modelFilter = By.XPath("//input[@placeholder='Модель']");
        private readonly By _modelHarrier = By.XPath("//div[contains(text(), 'Harrier') and @role='option']");
        private readonly By _fuelFilter = By.XPath("//button[text()='Топливо']");
        private readonly By _fuelHybrid = By.XPath("//div[text()='Гибрид' and @role='option']");
        private readonly By _unsoldCheckboxFilter = By.XPath("//label[@for='sales__filter_unsold']");
        private readonly By _advancedFilterButton = By.XPath("//button[@data-ftid='sales__filter_advanced-button']");

        public AutoDromPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        
        // Выставляет фильтр Марка - Toyota
        public void ChooseBrandFilter()
        {
            driver.FindElement(_brandFilter).Click();
            driver.FindElement(_brandFilter).SendKeys("Toyota");
            driver.FindElement(_brandToyota).Click();
        }

        // Выставляет фильтр Модель - Harrier
        public void ChooseModelFilter()
        {
            WebDriverWait iWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            iWait.Until(ExpectedConditions.ElementToBeClickable(_modelFilter));
            driver.FindElement(_modelFilter).Click();
            driver.FindElement(_modelFilter).SendKeys("Harrier");
            iWait.Until(ExpectedConditions.ElementToBeClickable(_modelHarrier));
            driver.FindElement(_modelHarrier).Click();
        }

        // Выставляет фильтр Топливо - Гибрид
        public void ChooseFuelTypeFilter()
        {
            driver.FindElement(_fuelFilter).Click();
            driver.FindElement(_fuelHybrid).Click();
        }

        // Активирует чекбокс - Непроданнные
        public void ActivateUnsoldCheckbox()
        {
            driver.FindElement(_unsoldCheckboxFilter).Click();
        }

        // Раскрывает фильтры расширенного поиска
        public void OpenAdvancedFilters()
        {
            driver.FindElement(_advancedFilterButton).Click();
        }
    }
}
