using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.NavbaR
{
    public class NavbarAdmin
    {
        public IEnumerable<NavbarItem> NavbarTop()
        {
            var topNav = new List<NavbarItem>();
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 1, action = "Reports", nameOption = "Журналы", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 2, action = "Index", nameOption = "Заказы", controller = "JorOrders", isParent = false, parentId = 1 });
            topNav.Add(new NavbarItem() { Id = 3, action = "Index", nameOption = "Заполнение результатов", controller = "JorAddResult", isParent = false, parentId = 1 });
            topNav.Add(new NavbarItem() { Id = 4, action = "Index", nameOption = "Результаты", controller = "JorResult", isParent = false, parentId = 1 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 5, action = "Reports", nameOption = "Справочники", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 6, action = "Index", nameOption = "Клиенты", controller = "DicClients", isParent = false, parentId = 5 });
            topNav.Add(new NavbarItem() { Id = 7, action = "Index", nameOption = "Услуги", controller = "DicGoods", isParent = false, parentId = 5 });
            //topNav.Add(new NavbarItem() { Id = 8, action = "MonthlyReport", nameOption = "Month Report", controller = "ReportGen", isParent = false, parentId = 5 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 8, action = "Reports", nameOption = "Отчеты", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 9, action = "SummaryReport", nameOption = "БухОтчет", controller = "ReportGen", isParent = false, parentId = 8 });
            topNav.Add(new NavbarItem() { Id = 10, action = "DailyReport", nameOption = "АналитикаОтчет", controller = "ReportGen", isParent = false, parentId = 8 });
            topNav.Add(new NavbarItem() { Id = 11, action = "MonthlyReport", nameOption = "MенеджерыОтчет", controller = "ReportGen", isParent = false, parentId = 8 });
            // End drop down Menu
            topNav.Add(new NavbarItem() { Id = 12, action = "OtherAction", nameOption = "Данные пользователя", controller = "Admin", isParent = false, parentId = -1 });

            topNav.Add(new NavbarItem() { Id = 13, action = "Index", nameOption = "Админка", controller = "Admin", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 14, action = "Index", nameOption = "Пользователи", controller = "Admin", isParent = false, parentId = 13 });
            topNav.Add(new NavbarItem() { Id = 15, action = "Index", nameOption = "Роли", controller = "RoleAdmin", isParent = false, parentId = 13 });
            topNav.Add(new NavbarItem() { Id = 16, action = "Index", nameOption = "Журнал событий", controller = "Jor", isParent = false, parentId = 13 });

            topNav.Add(new NavbarItem() { Id = 17, action = "Logout", nameOption = "Выйти", controller = "Account", isParent = false, parentId = -1 });

            return topNav;
        }
    }
}