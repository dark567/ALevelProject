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

            db.Genders.Add(g1);
            db.Genders.Add(g2);
            db.Genders.Add(g3);

            DicClient dс1 = new DicClient { Name = "Иван", Surname = "Дорн", Secname = "Антонович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 18, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс2 = new DicClient { Name = "Петр", Surname = "Скворцов", Secname = "Сергеевич", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 20, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс3 = new DicClient { Name = "Светлана", Surname = "Неизвестная", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 30, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс4 = new DicClient { Name = "Сергей", Surname = "Михайлов", Secname = "Иванович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 40, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс5 = new DicClient { Name = "Михаил", Surname = "Боярский", Secname = "Владимирович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 17, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс6 = new DicClient { Name = "Мария", Surname = "Высокая", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 55, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс7 = new DicClient { Name = "Денис", Surname = "Воронов", Secname = "Андреевич", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 47, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс8 = new DicClient { Name = "Стас", Surname = "Иванов", Secname = "Михайлович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 70, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс9 = new DicClient { Name = "Владимир", Surname = "Высоцкий", Secname = "Петрович", GenderId = g1, Phone = "777-55-12", Email = "adasd@list.ru", Age = 12, BirthDate = DateTime.Parse("2012-08-15") };
            DicClient dс10 = new DicClient { Name = "Катерина", Surname = "Донская", Secname = "Петрович", GenderId = g3, Phone = "777-55-12", Email = "adasd@list.ru", Age = 37, BirthDate = DateTime.Parse("2012-08-15") };

            db.DicClients.Add(dс1);
            db.DicClients.Add(dс2);
            db.DicClients.Add(dс3);
            db.DicClients.Add(dс4);
            db.DicClients.Add(dс5);
            db.DicClients.Add(dс6);
            db.DicClients.Add(dс7);
            db.DicClients.Add(dс8);
            db.DicClients.Add(dс9);
            db.DicClients.Add(dс10);

            DicGood dg1 = new DicGood { Code = "0001", Name = "Клинический анализ крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg2 = new DicGood { Code = "0002", Name = "Тробмоциты", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg3 = new DicGood { Code = "0003", Name = "Коклюш", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg4 = new DicGood { Code = "0004", Name = "Герпес", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg5 = new DicGood { Code = "0005", Name = "Биохимия крови", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg6 = new DicGood { Code = "0006", Name = "общий анализ белка", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg7 = new DicGood { Code = "0007", Name = "Креатинин", MinValue = 50, MaxValue = 100, Description = "какое то описание" };
            DicGood dg8 = new DicGood { Code = "0008", Name = "Составная услуга 1", MinValue = 50, MaxValue = 100, Description = "какое то описание" };

            db.DicGoods.Add(dg1);
            db.DicGoods.Add(dg2);
            db.DicGoods.Add(dg3);
            db.DicGoods.Add(dg4);
            db.DicGoods.Add(dg5);
            db.DicGoods.Add(dg6);
            db.DicGoods.Add(dg7);
            db.DicGoods.Add(dg8);

            JorOrder jo1 = new JorOrder { DateAdd = DateTime.Parse("2012-01-11"), Num = "0001", Client = dс1, ClientId = dс1.ClientId, Good = dg1, GoodId = dg1.GoodId };
            JorOrder jo2 = new JorOrder { DateAdd = DateTime.Parse("2020-02-20"), Num = "0002", Client = dс2, ClientId = dс2.ClientId, Good = dg2, GoodId = dg2.GoodId };
            JorOrder jo3 = new JorOrder { DateAdd = DateTime.Parse("2019-04-18"), Num = "0003", Client = dс3, ClientId = dс3.ClientId, Good = dg3, GoodId = dg3.GoodId };
            JorOrder jo4 = new JorOrder { DateAdd = DateTime.Parse("2018-07-13"), Num = "0004", Client = dс4, ClientId = dс4.ClientId, Good = dg4, GoodId = dg4.GoodId };
            JorOrder jo5 = new JorOrder { DateAdd = DateTime.Parse("2019-01-01"), Num = "0005", Client = dс5, ClientId = dс5.ClientId, Good = dg5, GoodId = dg5.GoodId };
            JorOrder jo6 = new JorOrder { DateAdd = DateTime.Parse("2015-09-15"), Num = "0006", Client = dс6, ClientId = dс6.ClientId, Good = dg6, GoodId = dg6.GoodId };
            JorOrder jo7 = new JorOrder { DateAdd = DateTime.Parse("2012-01-11"), Num = "0001", Client = dс1, ClientId = dс1.ClientId, Good = dg7, GoodId = dg7.GoodId };
            JorOrder jo8 = new JorOrder { DateAdd = DateTime.Parse("2020-02-20"), Num = "0002", Client = dс2, ClientId = dс2.ClientId, Good = dg8, GoodId = dg8.GoodId };
            JorOrder jo9 = new JorOrder { DateAdd = DateTime.Parse("2019-04-18"), Num = "0003", Client = dс3, ClientId = dс3.ClientId, Good = dg1, GoodId = dg1.GoodId };
            JorOrder jo10 = new JorOrder { DateAdd = DateTime.Parse("2018-07-13"), Num = "0004", Client = dс4, ClientId = dс4.ClientId, Good = dg2, GoodId = dg2.GoodId };
            JorOrder jo11 = new JorOrder { DateAdd = DateTime.Parse("2019-01-01"), Num = "0005", Client = dс5, ClientId = dс5.ClientId, Good = dg3, GoodId = dg3.GoodId };
            JorOrder jo12 = new JorOrder { DateAdd = DateTime.Parse("2015-09-15"), Num = "0006", Client = dс6, ClientId = dс6.ClientId, Good = dg4, GoodId = dg4.GoodId };

            db.JorOrders.Add(jo1);
            db.JorOrders.Add(jo2);
            db.JorOrders.Add(jo3);
            db.JorOrders.Add(jo4);
            db.JorOrders.Add(jo5);
            db.JorOrders.Add(jo6);
            db.JorOrders.Add(jo7);
            db.JorOrders.Add(jo8);
            db.JorOrders.Add(jo9);
            db.JorOrders.Add(jo10);
            db.JorOrders.Add(jo11);
            db.JorOrders.Add(jo12);


            base.Seed(db);


            //var students = new List<Student>
            //{
            //new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            //new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            //new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            //};

            //students.ForEach(s => context.Students.Add(s));
            //context.SaveChanges();
            //var courses = new List<Course>
            //{
            //new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            //new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            //new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            //new Course{CourseID=1045,Title="Calculus",Credits=4,},
            //new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            //new Course{CourseID=2021,Title="Composition",Credits=3,},
            //new Course{CourseID=2042,Title="Literature",Credits=4,}
            //};
            //courses.ForEach(s => context.Courses.Add(s));
            //context.SaveChanges();
            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050,},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();

        }
    }
}