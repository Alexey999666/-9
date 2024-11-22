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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_14;

namespace практос_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создаем динамический массив List хранящий коллекцию обектов
        /// </summary>
        private readonly List<Package> packages = new List<Package>();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// флаг для проверки была ли отправлена хотя бы одна посылка
        /// </summary>
        bool FlagSend = false;
        
        /// <summary>
        /// Информация о задании
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Описать, используя структуру, почтовую сортировку (город, улица, дом, квартира,кому, ценность). Вывести результат на экран.Вывести информацию, сколько посылок отправлено в заданный город.", "Задание", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Информация о разработчике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Андрианов Алексей Вариант 14", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// закрывает программу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Очищает все TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClean_Click(object sender, RoutedEventArgs e)
        {
            tbCity.Clear();
            tbStreet.Clear();
            tbHouse.Clear();
            tbApartment.Clear();
            tbRecipient.Clear();
            tbValue.Clear();
            tbCityCount.Clear();
            tbRezPackage.Clear();
            tbRezCount.Clear();
        }
        /// <summary>
        /// Записываем данные о посылке в пустой список и очищает TextBox ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendPackage_Click(object sender, RoutedEventArgs e)
        {
            if (tbCity.Text != "" && tbStreet.Text != "" && int.TryParse(tbHouse.Text, out int house) && house > 0 && int.TryParse(tbApartment.Text, out int apartment) && apartment > 0 && tbRecipient.Text != "" && decimal.TryParse(tbValue.Text, out decimal value) && value > 0)
            {
                
                string city = tbHouse.Text;
                string street = tbStreet.Text;
                string recipient = tbRecipient.Text;
                Package package = new Package(city, street, house, apartment, recipient, value);/// создаем новый объект и сразу присваеваем ему значения, через конструктор
                packages.Add(package);///Добавляем посылку в коллекцию
                tbCity.Clear();
                tbStreet.Clear();
                tbHouse.Clear();
                tbApartment.Clear();
                tbRecipient.Clear();
                tbValue.Clear();
                FlagSend = true;
                MessageBox.Show("Посылка отправленна");
            }
            else MessageBox.Show("Посылка не отправленна, ведите правильные значения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Подсчет количества посылок отправленных в выбранный город
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (FlagSend == true && tbCityCount.Text!= "" )
            {
                string city = tbCityCount.Text;
                int count = packages.Count(p => p.City.Equals(city, StringComparison.OrdinalIgnoreCase));///сравниваем свойство объекта списка с определенным значение свойства и подсчет количества совпадения
                tbRezCount.Text= $"Количество посылок в городе {city}: {count}";
            }
            else MessageBox.Show("Отправьте посылку и введите искомый город", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        /// <summary>
        /// Показывает все отправленные посылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPackage_Click(object sender, RoutedEventArgs e)
        {
            if(FlagSend == true)
            {
                tbRezPackage.Clear();
                foreach (var package in packages)/// цикл переберает все элементы динамического массива
                {
                    tbRezPackage.Text += $"Город: {package.City}, Улица: {package.Street}, " +
                                        $"Дом: {package.House}, Квартира: {package.Apartment}, " +
                                        $"Кому: {package.Recipient}, Ценность: {package.Value}\n";
                }
            }
            else MessageBox.Show("Отправьте посылку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
