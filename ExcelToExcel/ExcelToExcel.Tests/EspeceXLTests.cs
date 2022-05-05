﻿using ExcelToExcel.Models;
using ExcelToExcel.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace ExcelToExcel.Tests
{
    public class EspeceXLTests
    {
        MainViewModel vm;
        string excelFilesPath;

        public EspeceXLTests()
        {
            vm = new MainViewModel();

            Uri codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().Location);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);

            /// Va chercher le dossier Data à partir du dossier de compilation
            /// Adapter selon votre réalité
            excelFilesPath = Path.Combine(dirPath, @"..\..\..\..\..\data");
        }

        [Theory]
        [ClassData(typeof(BadExcelDataGenerator))]
        public void GetCSV_WrongFileContent_Should_Fail(string fn)
        {
            /// Arrange
            /// 
            var filename = Path.Combine(excelFilesPath, fn);
            var especeXL = new EspeceXL(filename);
            especeXL.LoadFile();

            /// Act
            /// 
            Action act = () => especeXL.GetCSV();

            /// Assert
            /// 
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [ClassData(typeof(GoodExcelDataGenerator))]
        public void GetCSV_GoodFileContent_Should_Pass(string fn)
        {
            /// Arrange
            /// 
            var filename = Path.Combine(excelFilesPath, fn);
            var especeXL = new EspeceXL(filename);
            especeXL.LoadFile();
            var notExpected = "";

            /// Act
            /// 
            var actual = especeXL.GetCSV();

            /// Assert
            /// 
            Assert.NotEqual(notExpected, actual);
        }

        [Fact]        
        public void LoadFile_ShouldFail_When_NoFile()
        {
            /// Arrange
            /// 
            var especeXL = new EspeceXL("");
            
            /// Act
            /// 
            Action act = () => especeXL.LoadFile();

            /// Assert
            /// 
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData("invalide_fichier_type.txt")]
        public void LoadFile_ShouldFail_When_BadFile(string fn)
        {
            /// Arrange
            /// 
            var filename = Path.Combine(excelFilesPath, fn);
            var especeXL = new EspeceXL(filename);

            /// Act
            /// 
            Action act = () => especeXL.LoadFile();

            /// Assert
            /// 
            Assert.Throws<ArgumentException>(act);
        }

    }
}
