using ExcelToExcel.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace ExcelToExcel.Tests
{
    public class MainViewModelTests
    {

        string excelFilesPath;

        MainViewModel vm;

        public MainViewModelTests()
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
        [MemberData(nameof(ExistingFilesTestData))]
        public void LoadContentCanExecute_ShouldReturnTrue_FileExists(string fn)
        {
            vm.InputFilename = Path.Combine(excelFilesPath, fn);

            /// Act
            var actual = vm.LoadContentCommand.CanExecute("");
            
            /// Assert
            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(NonExistentFilesTestData))]
        public void LoadContentCommand_CanExecute_FileNotExists_ShouldReturn_false(string fn)
        {
            vm.InputFilename = fn;

            /// Act
            var actual = vm.LoadContentCommand.CanExecute("");

            /// Assert
            Assert.False(actual);
        }


        #region TEST DATA
        public static IEnumerable<object[]> ExistingFilesTestData = new List<object[]>
        {
            new object[] {"liste_especes.xlsx"},
            new object[] {"Contenu_nom de peuplement.xlsx"},
            new object[] {"faune_aquatique_v21.xlsx"},
            new object[] {"faune_aquatique_v21_segment.xlsx"},
            new object[] {"Tableau_Export_v1.xlsx"},
            new object[] {"invalide_fichier_type.txt"},
        };

        public static IEnumerable<object[]> ExcelFilesTestData = new List<object[]>
        {
            new object[] {"liste_especes.xlsx"},
            new object[] {"liste_especes_multifeuilles.xlsx"},
            new object[] {"Contenu_nom de peuplement.xlsx"},
            new object[] {"faune_aquatique_v21.xlsx"},
            new object[] {"faune_aquatique_v21_segment.xlsx"},
            new object[] {"Tableau_Export_v1.xlsx"},
        };

        public static IEnumerable<object[]> BadExcelFilesTestData = new List<object[]>
        {
            new object[] {"Contenu_nom de peuplement.xlsx"},
            new object[] {"faune_aquatique_v21.xlsx"},
            new object[] {"faune_aquatique_v21_segment.xlsx"},
            new object[] {"Tableau_Export_v1.xlsx"},
        };

        public static IEnumerable<object[]> NonExistentFilesTestData = new List<object[]>
        {
            new object[] {"a.xlsx"},
            new object[] {"test.txt"},
            new object[] {"fasfdsfa.xlsx"},
            new object[] {"loooolollol.xlsx"},
        };

        public static IEnumerable<object[]> BadFileTypesTestData = new List<object[]>
        {
            new object[] {"invalide_fichier_type.txt"},
        };

        public static IEnumerable<object[]> GoodExcelFileTestData = new List<object[]>
        {
            new object[] {"liste_especes.xlsx"},
            new object[] {"liste_especes_multifeuilles.xlsx"},
        };


        #endregion
    }
}
