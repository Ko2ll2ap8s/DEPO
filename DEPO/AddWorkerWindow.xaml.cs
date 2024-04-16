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
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        private DEPOEntities db = new DEPOEntities();

        public AddWorkerWindow()
        {
            InitializeComponent();
        }

        private void SaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            int orgId = int.Parse(txtOrgId.Text);
            Worker worker = new Worker
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Patronymic = txtPatronymic.Text,
                BirthDate = dpBirthDate.SelectedDate ?? DateTime.Now,
                PassportSeries = int.Parse(txtPassportSeries.Text),
                PassportNumber = int.Parse(txtPassportNumber.Text),
                Id = orgId
            };

            db.Worker.Add(worker);
            db.SaveChanges();
            
        }

        private void ImportFromExcel_Click(object sender, RoutedEventArgs e)
        {
            ImportFromExcel("Worker.xlsx");
        }

        private void ImportFromExcel(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    Worker worker = new Worker
                    {
                        Name = worksheet.Cells[row, 2].Text,
                        Surname = worksheet.Cells[row, 3].Text,
                        Patronymic = worksheet.Cells[row, 4].Text,
                        BirthDate = DateTime.Parse(worksheet.Cells[row, 5].Text),
                        PassportSeries = int.Parse(worksheet.Cells[row, 6].Text),
                        PassportNumber = int.Parse(worksheet.Cells[row, 7].Text),
                        Id = int.Parse(worksheet.Cells[row, 8].Text)
                    };

                    db.Worker.Add(worker);
                }

                db.SaveChanges();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow();
            workerWindow.Show();
            this.Close();
        }
    }
}
