using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToExcel.Tests
{
    class GoodExcelDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "liste_especes.xlsx" };
            yield return new object[] { "liste_especes_multifeuilles.xlsx" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class BadExcelDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Contenu_nom de peuplement.xlsx" };
            yield return new object[] { "faune_aquatique_v21.xlsx" };
            yield return new object[] { "faune_aquatique_v21_segment.xlsx" };
            yield return new object[] { "Tableau_Export_v1.xlsx" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
