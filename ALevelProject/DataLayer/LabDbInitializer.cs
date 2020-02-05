using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LabDbInitializer : DropCreateDatabaseAlways<EFDBContext>
    {
        protected override void Seed(EFDBContext db)
        {

            Gender g1 = new Gender { Type = "n/a" };
            Gender g2 = new Gender { Type = "М" };
            Gender g3 = new Gender { Type = "Ж" };

            db.Gender.Add(g1);
            db.Gender.Add(g2);
            db.Gender.Add(g3);

            DicClient dg1 = new DicClient { Name = "Иван", Surname = "Дорн", Secname = "Антонович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 18, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg2 = new DicClient { Name = "Петр", Surname = "Скворцов", Secname = "Сергеевич", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 20, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg3 = new DicClient { Name = "Светлана", Surname = "Неизвестная", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 30, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg4 = new DicClient { Name = "Сергей", Surname = "Михайлов", Secname = "Иванович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 40, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg5 = new DicClient { Name = "Михаил", Surname = "Боярский", Secname = "Владимирович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 17, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg6 = new DicClient { Name = "Мария", Surname = "Высокая", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 55, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg7 = new DicClient { Name = "Денис", Surname = "Воронов", Secname = "Андреевич", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 47, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg8 = new DicClient { Name = "Стас", Surname = "Иванов", Secname = "Михайлович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 70, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg9 = new DicClient { Name = "Владимир", Surname = "Высоцкий", Secname = "Петрович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 12, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dg10 = new DicClient { Name = "Катерина", Surname = "Донская", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 37, BirthDate = DateTime.Parse("2012-08-15") };

            db.DicClient.Add(dg1);
            db.DicClient.Add(dg2);
            db.DicClient.Add(dg3);
            db.DicClient.Add(dg4);
            db.DicClient.Add(dg5);
            db.DicClient.Add(dg6);
            db.DicClient.Add(dg7);
            db.DicClient.Add(dg8);
            db.DicClient.Add(dg9);
            db.DicClient.Add(dg10);

            db.DicGood.Add(new DicGood { Code = "0001", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0002", Name = "Тробмоциты", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0003", Name = "Коклюш", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0004", Name = "Герпес", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0005", Name = "Биохимия крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0006", Name = "общий анализ белка", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0007", Name = "Креатинин", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0008", Name = "Составная услуга 1", MinValue = 50, MaxValue = 100, Description = "какое то описание" });

            base.Seed(db);

            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            //db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = "M", Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });

            //db.DicGood.Add(new DicGood { Code = "0001", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0002", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0003", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0004", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0005", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0006", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0007", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0008", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0009", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });
            //db.DicGood.Add(new DicGood { Code = "0010", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" });

            //db.Gender.Add(new Gender { Type = "n/a" });
            //db.Gender.Add(new Gender { Type = "М" });
            //db.Gender.Add(new Gender { Type = "Ж" });

            //base.Seed(db);
        }
    }
}