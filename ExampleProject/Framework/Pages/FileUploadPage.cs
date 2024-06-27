using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace ExampleProject.Framework.Pages
{
    internal class FileUploadPage : Form
    {
        private const string PageName = "File Upload";

        //implement locator
        private readonly ITextBox choosefileTextBox = ElementFactory.GetTextBox(By.Id("file-upload"),"Choose file button");
        private readonly IButton fileSubmitBtn = ElementFactory.GetButton(By.Id("file-submit"),"Submit file field");
        private readonly ILabel uploadedFileField = ElementFactory.GetLabel(By.Id("uploaded-files"),"Uploaded file field");
        public FileUploadPage() : base(By.XPath(string.Format(LocatorConstants.PreciseTextLocator, PageName)), PageName)
        {
        }

        public void SendKeysChoosefileTextBox(string value)=> choosefileTextBox.SendKeys(value);

        public void ClickFileSubmitBtn()=>fileSubmitBtn.Click();

        public string GetNameUploadedFile()=>uploadedFileField.Text;
    }
}
