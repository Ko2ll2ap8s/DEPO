using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DEPO
{
    /// <summary>
    /// Логика взаимодействия для AddOrganisationWindow.xaml
    /// </summary>
    public partial class AddOrganisationWindow : Window
    {
        private DEPOEntities db = new DEPOEntities();

        public AddOrganisationWindow()
        {
            InitializeComponent();
        }

        private void SaveOrganization_Click(object sender, RoutedEventArgs e)
        {
            Organisaton organizaton = new Organisaton
            {
                Name = txtName.Text,
                INN = int.Parse(txtINN.Text),
                LegalAddress = txtLegalAddress.Text,
                ActualAddress = txtActualAddress.Text
            };

            db.Organisaton.Add(organizaton);
            db.SaveChanges();
            
        }

        private void ImportFromExcel_Click(object sender, RoutedEventArgs e)
        {
            ImportFromExcel("Organizations.xlsx");
        }

        private void ImportFromExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    Organisaton organization = new Organisaton
                    {
                        Name = worksheet.Cells[row, 2].Text,
                        INN = int.Parse(worksheet.Cells[row, 3].Text),
                        LegalAddress = worksheet.Cells[row, 4].Text,
                        ActualAddress = worksheet.Cells[row, 5].Text
                    };

                    db.Organisaton.Add(organization);
                }

                db.SaveChanges();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OrganisationWindow organisationWindow = new OrganisationWindow();
            organisationWindow.Show();
            this.Close();
        }
    }
}
