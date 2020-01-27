using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {

        }

        public class LabDbInitializer : DropCreateDatabaseAlways<EFDBContext>
        {
            protected override void Seed(EFDBContext db)
            {
                db.DicClient.Add(new DicClient { Name = "Война и мир", Surname = "Л. Толстой", Secname = "Л. Толстой", Gender = 0, Phone  = "0000", Email = "dark@list.ru", Age = 47});
                db.DicClient.Add(new DicClient { Name = "Война и мир", Surname = "Л. Толстой", Secname = "Л. Толстой", Gender = 0, Phone  = "0000", Email = "dark@list.ru", Age = 47});
                db.DicClient.Add(new DicClient { Name = "Война и мир", Surname = "Л. Толстой", Secname = "Л. Толстой", Gender = 0, Phone  = "0000", Email = "dark@list.ru", Age = 47});
                db.DicClient.Add(new DicClient { Name = "Война и мир", Surname = "Л. Толстой", Secname = "Л. Толстой", Gender = 0, Phone  = "0000", Email = "dark@list.ru", Age = 47});


                //db.DicGood.Add(new DicGood { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
                //db.DicGood.Add(new DicGood { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
                //db.DicGood.Add(new DicGood { Name = "Чайка", Author = "А. Чехов", Price = 150 });

                //db.JorOrder.Add(new JorOrder { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
                //db.JorOrder.Add(new JorOrder { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180 });
                //db.JorOrder.Add(new JorOrder { Name = "Чайка", Author = "А. Чехов", Price = 150 });

                base.Seed(db);
            }
        }
    }
}
