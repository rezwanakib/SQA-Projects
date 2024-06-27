using ExampleProject.Framework.Pages;
using ExampleProject.Framework.Utils;
using NUnit.Framework;

namespace ExampleProject.Framework.Tests
{
    internal class FileUploadTests : BaseTest
    {
        private FileUploadPage fileUploadPage = new();
        private static readonly string fileName = testdata.GetValue<string>("fileUpload.fileName");
        private static readonly string filePath = testdata.GetValue<string>("fileUpload.filePath") + fileName;

        [Test]
        public void FileUploadTest()
        {
            mainPage.ClickNavigationLink("File Upload");
            fileUploadPage.SendKeysChoosefileTextBox(FileUtils.GetAbsolutePath(filePath));
            fileUploadPage.ClickFileSubmitBtn();
            Assert.AreEqual(fileUploadPage.GetNameUploadedFile(), fileName,
                "File is not correct or the name is different");
        }
    }
}
