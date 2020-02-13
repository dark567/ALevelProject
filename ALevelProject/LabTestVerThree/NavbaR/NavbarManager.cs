using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTestVerThree.NavbaR
{
    public class NavbarManager
    {
        public IEnumerable<NavbarItem> NavbarTop()
        {
            var topNav = new List<NavbarItem>();
            //topNav.Add(new NavbarItem() { Id = 1, action = "About", nameOption = "About", controller = "Home", isParent = false, parentId = -1 });
            //topNav.Add(new NavbarItem() { Id = 2, action = "Contact", nameOption = "Contact", controller = "Home", isParent = false, parentId = -1 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 1, action = "Reports", nameOption = "Журналы", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 2, action = "Index", nameOption = "Заказы", controller = "JorOrders", isParent = false, parentId = 1 });
            topNav.Add(new NavbarItem() { Id = 3, action = "Index", nameOption = "Результаты", controller = "JorResult", isParent = false, parentId = 1 });
            // drop down Menu 
            topNav.Add(new NavbarItem() { Id = 4, action = "Reports", nameOption = "Справочники", controller = "ReportGen", isParent = true, parentId = -1 });
            topNav.Add(new NavbarItem() { Id = 5, action = "Index", nameOption = "Клиенты", controller = "DicClients", isParent = false, parentId = 4 });
            topNav.Add(new NavbarItem() { Id = 6, action = "Index", nameOption = "Услуги", controller = "DicGoods", isParent = false, parentId = 4 });
            //topNav.Add(new NavbarItem() { Id = 7, action = "MonthlyReport", nameOption = "Month Report", controller = "ReportGen", isParent = false, parentId = 4 });

            // End drop down Menu
            topNav.Add(new NavbarItem() { Id = 7, action = "OtherAction", nameOption = "Данные пользователя", controller = "Admin", isParent = false, parentId = -1 });

            topNav.Add(new NavbarItem() { Id = 8, action = "Logout", nameOption = "Выйти", controller = "Account", isParent = false, parentId = -1 });

            return topNav;
        }
    }
}