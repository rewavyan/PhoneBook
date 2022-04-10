using PhoneBook.Models;
using System;
using System.Linq;

namespace PhoneBook.Data
{
    public class DbInitializer
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureCreated();
            if (context.PhoneBookRecords.Any())
            {
                return;
            }
            var areas = new Area[]
            {
                new Area{ Name = "Железнодорожный" },
                new Area{ Name = "Центральный" },
                new Area{ Name = "Киевский" },
            };
            foreach (var area in areas)
            {
                context.Areas.Add(area);
            }
            context.SaveChanges();
            var phoneBookRecords = new PhoneBookRecord[]
            {
                new PhoneBookRecord { FullName = "Кононова Милолика Егоровна", AreaID = areas[0].ID, Address = "TEST ADDRESS", Phone = "+79789220255" },
                new PhoneBookRecord { FullName = "Петрова Анфиса Артемовна", AreaID = areas[1].ID, Address = "TEST ADDRESS1", Phone = "+79786389879" },
                new PhoneBookRecord { FullName = "Мясникова Гертруда Эльдаровна", AreaID = areas[2].ID, Address = "TEST ADDRESS2", Phone = "+79786608433" },
                new PhoneBookRecord { FullName = "Князева Габриэлла Степановна", AreaID = areas[0].ID, Address = "TEST ADDRESS3", Phone = "+79782450600" },
                new PhoneBookRecord { FullName = "Маслова Дарья Геннадиевна", AreaID = areas[1].ID, Address = "TEST ADDRESS4", Phone = "+79789819917" },
                new PhoneBookRecord { FullName = "Капустина Инесса Платоновна", AreaID = areas[2].ID, Address = "TEST ADDRESS5", Phone = "+79785852056" },
                new PhoneBookRecord { FullName = "Ефимов Семен Миронович", AreaID = areas[0].ID, Address = "TEST ADDRESS6", Phone = "+79786576155" },
                new PhoneBookRecord { FullName = "Павлов Прохор Ярославович", AreaID = areas[1].ID, Address = "TEST ADDRESS7", Phone = "+79788304665" },
                new PhoneBookRecord { FullName = "Крюков Игнатий Артемович", AreaID = areas[2].ID, Address = "TEST ADDRESS8", Phone = "+79789384514" },
                new PhoneBookRecord { FullName = "Денисов Флор Проклович", AreaID = areas[0].ID, Address = "TEST ADDRESS9", Phone = "+79788332247" },
                new PhoneBookRecord { FullName = "Крюков Дональд Филиппович", AreaID = areas[1].ID, Address = "TEST ADDRESS10", Phone = "+79788933819" },
                new PhoneBookRecord { FullName = "Козлова Малика Эльдаровна", AreaID = areas[2].ID, Address = "TEST ADDRESS11", Phone = "+79784774600" },
                new PhoneBookRecord { FullName = "Ефремова Дэнна Протасьевна", AreaID = areas[0].ID, Address = "TEST ADDRESS12", Phone = "+79782766050" },
                new PhoneBookRecord { FullName = "Владимирова Капитолина Федотовна", AreaID = areas[1].ID, Address = "TEST ADDRESS13", Phone = "+79781812145" },
                new PhoneBookRecord { FullName = "Рыбакова Юна Аркадьевна", AreaID = areas[2].ID, Address = "TEST ADDRESS14", Phone = "+79786779098" },
                new PhoneBookRecord { FullName = "Козлова Хильда Даниловна", AreaID = areas[0].ID, Address = "TEST ADDRESS15", Phone = "+79788233346" },
                new PhoneBookRecord { FullName = "Фомичёв Иннокентий Пантелеймонович", AreaID = areas[1].ID, Address = "TEST ADDRESS16", Phone = "+79784120010" },
                new PhoneBookRecord { FullName = "Соколов Аввакуум Давидович", AreaID = areas[2].ID, Address = "TEST ADDRESS17", Phone = "+79783331715" },
                new PhoneBookRecord { FullName = "Афанасьев Азарий Богданович", AreaID = areas[0].ID, Address = "TEST ADDRESS18", Phone = "+79781545364" },
                new PhoneBookRecord { FullName = "Уваров Леонард Петрович", AreaID = areas[1].ID, Address = "TEST ADDRESS19", Phone = "+79788097506" },
                new PhoneBookRecord { FullName = "Гурьев Юстин Ильяович", AreaID = areas[2].ID, Address = "TEST ADDRESS20", Phone = "+79789711397" },
                new PhoneBookRecord { FullName = "Наумова Грета Михаиловна", AreaID = areas[0].ID, Address = "TEST ADDRESS21", Phone = "+79783577089" },
                new PhoneBookRecord { FullName = "Никонова Аурелия Антоновна", AreaID = areas[1].ID, Address = "TEST ADDRESS22", Phone = "+79783148446" },
                new PhoneBookRecord { FullName = "Никонова Александра Лукьевна", AreaID = areas[2].ID, Address = "TEST ADDRESS23", Phone = "+79787620877" },
                new PhoneBookRecord { FullName = "Исаева Милослава Агафоновна", AreaID = areas[0].ID, Address = "TEST ADDRESS24", Phone = "+79782448739" },
                new PhoneBookRecord { FullName = "Богданова Неолина Семёновна", AreaID = areas[1].ID, Address = "TEST ADDRESS25", Phone = "+79788223157" },
                new PhoneBookRecord { FullName = "Иванков Матвей Сергеевич", AreaID = areas[2].ID, Address = "TEST ADDRESS26", Phone = "+79788775332" },
                new PhoneBookRecord { FullName = "Евдокимов Вилен Сергеевич", AreaID = areas[0].ID, Address = "TEST ADDRESS27", Phone = "+79785082696" },
                new PhoneBookRecord { FullName = "Емельянов Панкратий Аркадьевич", AreaID = areas[1].ID, Address = "TEST ADDRESS28", Phone = "+79782780011" },
                new PhoneBookRecord { FullName = "Панфилов Тарас Мэлсович", AreaID = areas[2].ID, Address = "TEST ADDRESS29", Phone = "+79787964874" },
            };
            foreach (var phoneBookRecord in phoneBookRecords)
            {
                context.PhoneBookRecords.Add(phoneBookRecord);
            }
            context.SaveChanges();
        }
    }
}
