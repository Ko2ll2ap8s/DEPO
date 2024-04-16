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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        private DEPOEntities db = new DEPOEntities();

        public WorkerWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void ExportEmployeesToExcel_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel(db.Worker.ToList(), "Workers.xlsx");
        }

        private void ExportToExcel(List<Worker> employees, string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Workers");
                worksheet.Cells.LoadFromCollection(employees, true);
                package.Save();
            }
        }

        private void LoadData()
        {
            var realties = db.Worker.ToList();
            lvEvents.ItemsSource = realties;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToString();

            var filteredRealties = db.Worker
                .Where(r =>
                    (r.Name.ToString().Contains(searchText) || r.Surname.ToString().Contains(searchText))
                    || r.Patronymic.ToString().Contains(searchText) || r.BirthDate.ToString().Contains(searchText)
                    || r.PassportSeries.ToString().Contains(searchText) || r.PassportNumber.ToString().Contains(searchText)
                )
                .ToList();

            lvEvents.ItemsSource = filteredRealties;
        }

        private void BtnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            addWorkerWindow.Show();
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
