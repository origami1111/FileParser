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
            // с существующим словом и правильным названием файла
            public void QuantityStr_WithTheExistingWordAndCorrectFile_GivesOutQuantity() 
            {
                string filePath = "C:\\Users\\origami\\TEXT_source.txt";
                string searchStr = "рыба";

                int expectedResult = 1;

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                int actualResult = fileParser.QuantityStr();

                Assert.AreEqual(expectedResult, actualResult);
            }

            // с не существующим словом и правильным названием файла
            [TestMethod]
            public void QuantityStr_WithTheNonExistingWordAndCorrectFile_GivesOutQuantity()
            {
                string filePath = "C:\\Users\\origami\\TEXT_source.txt";
                string searchStr = "гвоздь";

                int expectedResult = 0;

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                int actualResult = fileParser.QuantityStr();

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            // с существующим словом и не правильным названием файла
            public void QuantityStr_WithWrongFile_ShouldThrowFileNotFound()
            {
                string filePath = "C:\\Users\\origami\\asdsadd.txt";
                string searchStr = "рыба";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                Assert.ThrowsException<FileNotFoundException>(() => fileParser.QuantityStr());
            }

            [TestMethod]
            // с существующим словом и файлом, но не корректным путем
            public void QuantityStr_WithTheWrongDirectory_ShouldThrowDirectoryNotFound()
            {
                string filePath = "D:\\Users\\origami\\TEXT.txt";
                string searchStr = "рыба";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr);

                Assert.ThrowsException<DirectoryNotFoundException>(() => fileParser.QuantityStr());
            }

            [TestMethod]
            // с существующим словом и правильным названием файла
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
            // с не существующим словом и правильным названием файла
            public void IsReplacedStr_WithTheNonExistingWord_GivesOutBoolean()
            {
                string filePath = "C:\\Users\\origami\\TEXT_source.txt";
                string searchStr = "гвоздь";
                string replacementStr = "123456789";

                bool expectedResult = false;

                FileParserClass fileParser = new FileParserClass(filePath, searchStr, replacementStr);

                bool actualResult = fileParser.IsReplacedStr();

                Assert.AreEqual(expectedResult, actualResult);
            }

            [TestMethod]
            // с существующим словом и не правильным названием файла
            public void IsReplacedStr_WithWrongFile_ShouldThrowFileNotFound()
            {
                string filePath = "C:\\Users\\origami\\asdasd.txt";
                string searchStr = "рыба";
                string replacementStr = "123456789";

                FileParserClass fileParser = new FileParserClass(filePath, searchStr, replacementStr);

                Assert.ThrowsException<FileNotFoundException>(() => fileParser.IsReplacedStr());
            }

            [TestMethod]
            // с существующим словом и файлом, но не корректным путем
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
