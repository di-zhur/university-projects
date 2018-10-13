using Aspose.Cells;
using Delta.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.UI.Helpers
{
    public static class ConverterHelper
    {
        public static List<T> ExcelToList<T>(AreaExcel area, string pathFile) where T : class, new()
        {
            var workbook = new Workbook(pathFile);
            var worksheet = workbook.Worksheets["data"];
            var patternProperties = typeof(T).GetProperties();
            var patternList = new ConcurrentBag<T>();
            var startColumn = area.StartColumn;
            var endColumn = area.EndColumn;

            Parallel.For(area.StartRow, area.EndRow, row =>
            {
                var value = new T();
                var index = 0;
                for (int column = startColumn; column < endColumn; column++)
                {
                    var propertie = patternProperties[index];
                    var valueCell = worksheet.Cells[row, column].Value;

                    if (valueCell == null || propertie.PropertyType != valueCell.GetType())
                        continue;

                    propertie.SetValue(value, valueCell);
                    index++;
                }
                patternList.Add(value);
            });
            
            return patternList.ToList();
        }
    }
}
