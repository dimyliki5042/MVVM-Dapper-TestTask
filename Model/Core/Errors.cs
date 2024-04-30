using System.Collections.Generic;

namespace TestTask.Model.Core
{
    public static class Errors
    {
        public static Dictionary<int, string[]> ErrorsList = new Dictionary<int, string[]>()
        {
            {1, new string[2] { "Не найдено", "Абонентов с таким номером не существует"}},
            {2, new string[2] { "Некорректно", "Некорректный ввод номера"}},
        };
    }
}
