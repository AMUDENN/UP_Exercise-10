using NetOffice.ExcelApi.Enums;
using NetOffice.Extensions.Invoker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Excel = NetOffice.ExcelApi;

namespace UP_Exercise_10.ApplicationLogic
{
    internal class ExcelFunctions
    {
        private static Excel.Application XL = new();
        public static Excel.Application Application => XL;
        public static double GetResult(string function, object[] numbers) => XL.WorksheetFunction.MethodGet<double>(function, numbers, false);
    }
}
