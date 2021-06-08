using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileParser;
using System.IO;

namespace FileParserTests
{
    [TestClass]
    public class FileParserTests
    {
        [TestClass]
        public class FileParserTest
        {
            [TestMethod]
            public void QuantityStr_WithTheExistingWordAndCorrectFile_GivesOutQuantity()
            {
                string filePath = "C:\\Users\\origami\\TEXT_source.txt";
                string searchStr = "рыба";

                int expectedResult = 1;

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                int actualResult = fileParser.QuantityStr();

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void QuantityStr_WithWrongFile_ShouldThrowFileNotFound()
            {
                string filePath = "C:\\Users\\origami\\asdsadd.txt";
                string searchStr = "рыба";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                Assert.ThrowsException<FileNotFoundException>(() => fileParser.QuantityStr());
            }

            [TestMethod]
            public void QuantityStr_WithTheWrongDirectory_ShouldThrowDirectoryNotFound()
            {
                string filePath = "D:\\Users\\origami\\TEXT.txt";
                string searchStr = "рыба";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                Assert.ThrowsException<DirectoryNotFoundException>(() => fileParser.QuantityStr());
            }

            [TestMethod]
            public void IsReplacedStr_WithTheExistingWord_GivesOutBoolean()
            {
                string filePath = "C:\\Users\\origami\\TEXT_source.txt";
                string searchStr = "рыба";
                string replacementStr = "123456789";

                bool expectedResult = true;

                FileParserClass fileParser = new FileParserClass(filePath, searchStr, replacementStr);

                bool actualResult = fileParser.IsReplacedStr();

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            public void IsReplacedStr_WithWrongFile_ShouldThrowFileNotFound()
            {
                string filePath = "C:\\Users\\origami\\asdasd.txt";
                string searchStr = "рыба";
                string replacementStr = "123456789";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr, replacementStr);

                Assert.ThrowsException<FileNotFoundException>(() => fileParser.IsReplacedStr());
            }

            [TestMethod]
            public void IsReplacedStr_WithTheWrongDirectory_ShouldThrowDirectoryNotFound()
            {
                string filePath = "C:\\origami\\TEXT.txt";
                string searchStr = "рыба";
                string replacementStr = "123456789";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr, replacementStr);

                Assert.ThrowsException<DirectoryNotFoundException>(() => fileParser.IsReplacedStr());
            }
        }
    }
}
