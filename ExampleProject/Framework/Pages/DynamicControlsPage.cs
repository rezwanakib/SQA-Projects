using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class DynamicControlsPage : Form
    {
        //implement class itself
        private const string PageName = "Dynamic Controls";

        private IButton enableBtn = ElementFactory.GetButton(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, "Enable")),"Status Enable");
        private ITextBox inputField = ElementFactory.GetTextBox(By.XPath("//*[@id=\"input-example\"]//input"),"Input Element");
        public DynamicControlsPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public void ClickEnableBtn()
        {
            enableBtn.Click();
        }

        public bool IsInputEnabled()
        {
            return inputField.State.WaitForEnabled();
        }
                
        public void InputText(string text)
        {
            inputField.ClearAndType(text);
        }

        public string GetInputTextvatue()
        {
            return inputField.Value;
        }


    }
}
