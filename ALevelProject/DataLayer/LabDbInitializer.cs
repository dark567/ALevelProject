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
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email= "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2012-08-15") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2010-01-20") });
            db.DicClient.Add(new DicClient { Name = "Петр", Surname = "Толстой", Secname = "Иванович", Gender = 1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 15, BirthDate = DateTime.Parse("2007-12-01") });

            db.DicGood.Add(new DicGood { Code = "0001", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0002", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0003", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0004", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0005", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0006", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0007", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0008", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0009", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });
            db.DicGood.Add(new DicGood { Code = "0010", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description ="какое то описание" });

            base.Seed(db);
        }
    }
}