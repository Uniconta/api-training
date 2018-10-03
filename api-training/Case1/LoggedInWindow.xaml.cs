using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Uniconta.API.Service;

namespace Case1
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private Session _session { get; set; }
        public LoggedInWindow(Session session)
        {
            _session = session;
            InitializeComponent();
        }

        protected async override void OnClosed(EventArgs e)
        {
            await _session.LogOut();
            base.OnClosed(e);
        }
    }
}
