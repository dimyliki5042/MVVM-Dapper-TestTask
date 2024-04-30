using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TestTask.Model.Core;
using TestTask.View;

namespace TestTask.Model
{
    public static class DataFinder
    {
        public static BigInteger SearchNumber { get; set; }

        public static List<MainDataModel> FindForNumber()
        {
            List<MainDataModel> values = SQLCommands.Data.Where(x => x.HomeNumber == SearchNumber ||
                                                                x.WorkNumber == SearchNumber ||
                                                                x.PhoneNumber == SearchNumber).ToList();
            if(values.Count != 0)
                return values;
            else
            {
                ErrorWindow errorWindow = new ErrorWindow(Errors.ErrorsList[1]);
                errorWindow.ShowDialog();
                return null;
            }
        }
    }
}
