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



namespace Lib_14
{
    
    
    /// <summary>
    /// Структура посылки
    /// </summary>
    public struct Package
    {
        /// <summary>
        /// City, Street и Recipient мы не проверяем так как они string
        /// </summary>
        public string City;
        public string Street;
        private int _house;
        public int House
        {
          get { return _house; }
          set { if (value > 0) _house = value; }
        }
        private int _apartment;
        public int Apartment
        {
            get { return _apartment; }
            set { if (value > 0) _apartment = value; }
        }
        public string Recipient;
        private decimal _value;
        public decimal Value
        {
            get { return _value; }
            set { if (value > 0) _value = value; }
        }
        /// <summary>
        /// Конструктор структуры Package, присваюващий ей значения
        /// </summary>
        /// <param name="city">город в который отправленна посылка</param>
        /// <param name="street">улица на которую отправлена посылка</param>
        /// <param name="house"> номер дома</param>
        /// <param name="apartment">номер квартиры</param>
        /// <param name="recipient">кому отправлена</param>
        /// <param name="value">ценность посылки</param>
        public Package(string city, string street, int house, int apartment, string recipient, decimal value)
        {
            City = city;
            Street = street;
            _house = house;
            _apartment = apartment;
            Recipient = recipient;
            _value = value;
        }

    }
}
