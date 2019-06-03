using System;
using System.IO;
using Xunit;

namespace Weather.UnitTest
{
    public class FileTest
    {
        string path = "";
        public FileTest()
        {
             path = @"C:\Pooja\Training\Files\Weather.txt";
        }
        [Fact]
        public void isInputFilePresent()
        {
           bool present = File.Exists(path);
            Assert.True(present);
        }
        [Fact]
        public void isInputFileContentPresent()
        {
            bool istextcontain = true;
            string text = File.ReadAllText(path);

            if (text == null) istextcontain = false;
            Assert.True(istextcontain);
        }


        //[Fact]
        //public void isOutputFileCreated()
        //{
        //    bool istextcontain = true;
        //    FileStream file = File.Create(path);

        //    if (file. == null) istextcontain = false;
        //    Assert.True(istextcontain);
        //}
    }
}
