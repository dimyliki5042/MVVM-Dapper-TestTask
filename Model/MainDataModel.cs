using CsvHelper.Configuration;

namespace TestTask.Model
{
    public class MainDataModelMap : ClassMap<MainDataModel>
    {
        public MainDataModelMap()
        {
            Map(x => x.Surname).Name("Фамилия");
            Map(x => x.Name).Name("Имя");
            Map(x => x.Patronymic).Name("Отчество");
            Map(x => x.Street).Name("Улица");
            Map(x => x.House).Name("Дом");
            Map(x => x.HomeNumber).Name("Домашний телефон");
            Map(x => x.WorkNumber).Name("Рабочий телефон");
            Map(x => x.PhoneNumber).Name("Мобильный телефон");
        }
    }

    public class MainDataModel
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int HomeNumber { get; set; }
        public int WorkNumber { get; set; }
        public int PhoneNumber { get; set; }
    }
}
