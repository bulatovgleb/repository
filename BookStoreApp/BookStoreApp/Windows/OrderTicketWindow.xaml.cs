using BookStoreApp.Models;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace BookStoreApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderTicketWindow.xaml
    /// </summary>
    public partial class OrderTicketWindow : Window
    {

        Order _currentOrder; // текущий заказ
        Client _currentClient; // текущий пользователь
        public OrderTicketWindow(Order order)
        {
            InitializeComponent();
            LoadDataAndInit(order);
        }
        // загрузка и инициализация данных
        void LoadDataAndInit(Order order)
        {
            _currentOrder = order;
            DataGridOrderItems.ItemsSource = null;
            DataGridOrderItems.ItemsSource = Basket.GetBasket;
            _currentClient = Manager.CurrentUser;
            if (_currentClient != null)
            {
                TextBlockOrderNumber.Text = $"Заказ на имя " +
                    $"{ _currentClient.ClientSurname} {_currentClient.ClientName} {_currentClient.ClientPatronymic} оформлен";
            }
            else
            {
                TextBlockOrderNumber.Text = $"Заказ оформлен";
            }
            TextBlockTotalCost.Text = $"   Итого {Basket.GetTotalCost:C}";
            TextBlockOrderCreateDate.Text = DateTime.Today.ToLongDateString();
            TextBlockOrderDeliveryDate.Text = DateTime.Today.AddDays(3).ToLongDateString();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSavePDF_Click(object sender, RoutedEventArgs e)
        {
            PrintInPdf(_currentOrder);
        }

        void PrintInPdf(Order order)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (.pdf)|*.pdf"; // Filter files by extension
                                                            // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Заказ на имя " +
                    $"{ _currentClient.ClientSurname} {_currentClient.ClientName} {_currentClient.ClientPatronymic} оформлен";
                    range.InsertParagraphAfter();

                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;


                    Word.Table table = document.Tables.Add(tableRange, Basket.GetCount + 1, 6);
                    //table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "Наименование товара";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Количество";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Дата создания";
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = "Дата доставки";
                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = "Стоимость";
                    cellRange = table.Cell(1, 6).Range;
                    cellRange.Text = "ИТОГО";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 0;
                    foreach (var item in Basket.GetBasket)
                    {
                        cellRange = table.Cell(i + 2, 1).Range;
                        cellRange.Text = item.Key.BookName;
                        cellRange = table.Cell(i + 2, 2).Range;
                        cellRange.Text = item.Value.Count.ToString();
                        cellRange = table.Cell(i + 2, 3).Range;
                        cellRange.Text = DateTime.Today.ToLongDateString();
                        cellRange = table.Cell(i + 2, 4).Range;
                        cellRange.Text = DateTime.Today.AddDays(3).ToLongDateString();
                        cellRange = table.Cell(i + 2, 5).Range;
                        cellRange.Text = item.Key.BookPrice.ToString("f2");
                        cellRange = table.Cell(i + 2, 6).Range;
                        cellRange.Text = item.Value.Total.ToString("f2");
                        i++;
                    }
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    generalRange.Text = $"\nОбщая сумма заказа: {Basket.GetTotalCost:f2} руб.";
                    document.SaveAs2($@"{path}", Word.WdExportFormat.wdExportFormatPDF);
                    MessageBox.Show("Талон сохранен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
