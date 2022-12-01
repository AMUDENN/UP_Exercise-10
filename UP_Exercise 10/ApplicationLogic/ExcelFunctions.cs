using NetOffice.Extensions.Invoker;
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
