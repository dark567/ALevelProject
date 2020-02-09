using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.NavbaR
{
    public class Navbar
    {
        public IEnumerable<NavbarItem> NavbarTop()
        {
            var topNav = new List<NavbarItem>();
            //topNav.Add(new NavbarItem() { Id = 1, action = "About", nameOption = "About", controller = "Home", isParent = false, parentId = -1 });
            //topNav.Add(new NavbarItem() { Id = 2, action = "Contact", nameOption = "Contact", controller = "Home", isParent = false, parentId = -1 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 1, action = "Reports", nameOption = "Журналы", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 2, action = "SummaryReport", nameOption = "Заказы", controller = "ReportGen", isParent = false, parentId = 1 });
            topNav.Add(new NavbarItem() { Id = 3, action = "DailyReport", nameOption = "Заполнение результатов", controller = "ReportGen", isParent = false, parentId = 1 });
            topNav.Add(new NavbarItem() { Id = 4, action = "MonthlyReport", nameOption = "Результаты", controller = "ReportGen", isParent = false, parentId = 1 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 5, action = "Reports", nameOption = "Справочники", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 6, action = "SummaryReport", nameOption = "Клиенты", controller = "ReportGen", isParent = false, parentId = 5 });
            topNav.Add(new NavbarItem() { Id = 7, action = "DailyReport", nameOption = "Услуги", controller = "ReportGen", isParent = false, parentId = 5 });
            topNav.Add(new NavbarItem() { Id = 8, action = "MonthlyReport", nameOption = "Month Report", controller = "ReportGen", isParent = false, parentId = 5 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 9, action = "Reports", nameOption = "Reports", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 10, action = "SummaryReport", nameOption = "Overall Summary", controller = "ReportGen", isParent = false, parentId = 9 });
            topNav.Add(new NavbarItem() { Id = 11, action = "DailyReport", nameOption = "Today Report", controller = "ReportGen", isParent = false, parentId = 9 });
            topNav.Add(new NavbarItem() { Id = 12, action = "MonthlyReport", nameOption = "Month Report", controller = "ReportGen", isParent = false, parentId = 9 });
            // End drop down Menu
            topNav.Add(new NavbarItem() { Id = 13, action = "OtherAction", nameOption = "Данные пользователя", controller = "Admin", isParent = false, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 14, action = "Index", nameOption = "Админка", controller = "Admin", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 15, action = "Index", nameOption = "Пользователи", controller = "Admin", isParent = false, parentId = 14 });
            topNav.Add(new NavbarItem() { Id = 16, action = "Index", nameOption = "Роли", controller = "RoleAdmin", isParent = false, parentId = 14 });

            topNav.Add(new NavbarItem() { Id = 17, action = "Logout", nameOption = "Выйти", controller = "Account", isParent = false, parentId = -1 });

            return topNav;
        }
    }
}