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
    /// Логика взаимодействия для OrganisationWindow.xaml
    /// </summary>
    public partial class OrganisationWindow : Window
    {
        private DEPOEntities db = new DEPOEntities();

        public OrganisationWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void ExportOrganizationsToExcel_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel(db.Organisaton.ToList(), "Organizations.xlsx");
        }

        private void ExportToExcel(List<Organisaton> organizatons, string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Organizatons");
                worksheet.Cells.LoadFromCollection(organizatons, true);
                package.Save();
            }
        }

        private void LoadData()
        {
            var realties = db.Organisaton.ToList();
            lvEvents.ItemsSource = realties;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToString();

            var filteredRealties = db.Organisaton
                .Where(r =>
                    (r.Name.ToString().Contains(searchText) || r.INN.ToString().Contains(searchText)) 
                    || r.LegalAddress.ToString().Contains(searchText) || r.ActualAddress.ToString().Contains(searchText)
                )
                .ToList();

            lvEvents.ItemsSource = filteredRealties;
        }

        private void BtnAddOrganisation_Click(object sender, RoutedEventArgs e)
        {
            AddOrganisationWindow addOrganisationWindow = new AddOrganisationWindow();
            addOrganisationWindow.Show();
            this.Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
