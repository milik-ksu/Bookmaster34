using Bookmaster34.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Bookmaster34
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BookMaster34daContext _context;

        public static BookMaster34daContext GetContext()
        {
            if (_context == null)
            { 
            _context = new BookMaster34daContext();
            }
            return _context;
        }
    }

}
