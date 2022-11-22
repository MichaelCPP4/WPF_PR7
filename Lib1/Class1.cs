using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public class Car
    {
        string _marka;

        int _numOfCylinders;

        double _horsePower, _kW;

        public string Marka
        {
            get => _marka;
            set { if (value == "") _marka = null; else { _marka = value; } }
        }

        public double HorsePower
        {
            get => _horsePower;
            set { if (value >= 0) _horsePower = value; _kW = value / 1.36; }
        }
        public double KW
        {
            get => _kW;
            set { if (value >= 0) _kW = value; _horsePower = value * 1.36; }
        }

        public int NumOfCylinders
        {
            get => _numOfCylinders;
            set { _numOfCylinders = value; }
        }

        public Car()
        {
            _marka = string.Empty;
            _numOfCylinders = 0;
            _kW = 0;
        }

        public Car(string marka, int numOfCylinders, double kw)
        {
            _marka = marka;
            _numOfCylinders = numOfCylinders;
            _kW = kw;
        }

        public void PlusPower()
        {
            KW++;
        }

        /// <summary>
        /// Перегруженный метод ToString() для изменения строки представляющей объект в ListBox
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this._marka + " - Автомобиль";
        }

        /// <summary>
        /// Метод меняет параметры автомобиля
        /// </summary>
        /// <param name="marka">Марка автомобиля</param>
        /// <param name="numOfCylinders">Кол-во целиндров</param>
        /// <param name="kW"></param>
        public void SetParams(string marka, int numOfCylinders, double kW)
        {
            Marka = marka;
            NumOfCylinders = numOfCylinders;
            KW = kW;
        }

        /// <summary>
        /// Метод меняет параметры автомобиля
        /// </summary>
        /// <param name="marka">Марка автомобиля</param>
        /// <param name="numOfCylinders">Кол-во целиндров</param>
        public void SetParams(string marka, int numOfCylinders)
        {
            Marka = marka;
            NumOfCylinders = numOfCylinders;
        }

        /// <summary>
        /// Метод меняет параметры автомобиля
        /// </summary>
        /// <param name="marka">Марка автомобиля</param>
        /// <param name="kW"></param>
        public void SetParams(string marka, double kW)
        {
            Marka = marka;
            KW = kW;
        }

        /// <summary>
        /// Перегруженный оператор <
        /// </summary>
        /// <param name="car1">Автомобиль1</param>
        /// <param name="car2">Автомобиль2</param>
        /// <returns>Возвращает результат сравнения</returns>
        public static bool operator <(Car car1, Car car2)
        {
            return (car1.NumOfCylinders < car2.NumOfCylinders) || (car1.KW < car2.KW);
        }

        /// <summary>
        /// Перегруженный оператор >
        /// </summary>
        /// <param name="car1">Автомобиль1</param>
        /// <param name="car2">Автомобиль2</param>
        /// <returns>Возвращает результат сравнения</returns>
        public static bool operator >(Car car1, Car car2)
        {
            return (car1.NumOfCylinders > car2.KW) || (car1.NumOfCylinders > car2.KW);
        }


        /// <summary>
        /// Перегруженный оператор ==
        /// </summary>
        /// <param name="car1">Автомобиль1</param>
        /// <param name="car2">Автомобиль2</param>
        /// <returns>Возвращает результат сравнения</returns>
        public static bool operator ==(Car car1, Car car2)
        {
            return (car1.NumOfCylinders == car2.NumOfCylinders) && (car1.KW == car2.KW);
        }

        /// <summary>
        /// Перегруженный оператор !=
        /// </summary>
        /// <param name="car1">Автомобиль1</param>
        /// <param name="car2">Автомобиль2</param>
        /// <returns>Возвращает результат сравнения</returns>
        public static bool operator !=(Car car1, Car car2)
        {
            return (car1.NumOfCylinders != car2.NumOfCylinders) && (car1.NumOfCylinders != car2.NumOfCylinders);
        }
    }
    
    public class Lorry : Car
    {
        double _capacity;

        public double Capacity
        {
            get { return _capacity; }
            set { if(value >= 0)_capacity = value; }

        }
        public Lorry() : base()
        {
            Capacity = 0;
        }
        public Lorry(double capacity, string marka, int numOfCylinders, double kw) : base(marka, numOfCylinders, kw)
        {
            Capacity = capacity;
        }

        public override string ToString()
        {
            return this.Marka + " - Грузовик";
        }
    }
}