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
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;
using Uniconta.DataModel;

namespace Case4
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        private static TableHeaderClient CurrentTableHeader { get; set; }

        public LoggedInWindow()
        {
            InitializeComponent();
        }

        /*
         *  This method creates a table and inserts it into Uniconta.
         */
        private async void CreateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            // Acquire CRUD API
            var crud = UnicontaManager.CrudAPI;

            // Initialize table header
            var tableHeader = new TableHeaderClient
            {
                _MenuPosition = 1,              // Customer Menu
                _Name = "APICourse091018",      // Name of the Table (for the backend)
                _Prompt = "API-Course 091018",  // Promp (Name in the menu)
                _UserDefinedId = 1928,          // Some arbitrary user defined ID I have assigned.

            };

            // Insert table header
            var result = await crud.Insert(tableHeader);
            if (result != ErrorCodes.Succes)
            {
                MessageBox.Show("Unable to insert table header. Error: " + result.ToString(), "Error");
                return;
            }

            MessageBox.Show("Succesfully inserted table header into Uniconta.\nName: " + tableHeader._Name + "\nPrompt: " + tableHeader._Prompt + "\nUserDefinedID: " + tableHeader._UserDefinedId, "Succes");
            CurrentTableHeader = tableHeader;
        }

        /*
         *  This method inserts fields into a table in Uniconta.
         */
        private async void PopulateTable_Click(object sender, RoutedEventArgs e)
        {
            // Acquire CRUD API
            var crud = UnicontaManager.CrudAPI;

            // Initialize new fields
            var newFields = new List<TableField>
            {
                // Foreign Key to Employee Table
                new TableField
                {
                _RefTable = "Employee",
                _Prompt = "Employee",
                _Name = "Employee",
                _FieldType = CustomTypeCode.String,

                },

                // String field naming school of employee
                new TableField
                {
                _Name = "School",
                _Prompt = "School",
                _FieldType = CustomTypeCode.String,
                },
            };
         
            // Loop over newFields and set their master
            foreach(var field in newFields)
                field.SetMaster(CurrentTableHeader);

            // Insert newFields in bulk
            var result = await crud.Insert(newFields);
            if (result != ErrorCodes.Succes)
            {
                MessageBox.Show("Unable to insert fields into table. Error: " + result.ToString(), "Error");
                return;
            }

            var msg = String.Format("Succesfully inserted {0} fields into table {1}", newFields.Count, CurrentTableHeader.Name);

            MessageBox.Show(msg, "Succes");



        }
    }
}
