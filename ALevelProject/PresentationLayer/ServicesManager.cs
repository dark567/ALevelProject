using BuissnesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    public class ServicesManager
    {
        DataManager _dataManager;


        public ServicesManager(
            DataManager dataManager
            )
        {
            _dataManager = dataManager;
        }
    }
}
