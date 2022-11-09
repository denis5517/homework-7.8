using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace homework_7._8
{
    struct Employee
    {
        public string employeeId { get; set; }
        public string addingTime { get; set; }
        public string fullName { get; set; }
        public string age { get; set; }
        public string height { get; set; }
        public string dateOfBirth { get; set; }
        public string placeOfBirth { get; set; }

        public Employee(
            string employeeId,
            string addingTime,
            string fullName,
            string age,
            string height,
            string dateOfBirth,
            string placeOfBirth)
        {
            this.employeeId = employeeId;
            this.addingTime = addingTime;
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
        }

        #region Вывести работника в консоль
        /// <summary>
        /// Выводит работника в консоль
        /// </summary>
        /// <param name-"employee"></param>
        
        public void Print()
        {
            Console.WriteLine($"ID: {this.employeeId}");
            Console.WriteLine($"Дата добавления: {this.addingTime}");
            Console.WriteLine($"ФИО: {this.fullName}");
            Console.WriteLine($"Возраст: {this.age}");
            Console.WriteLine($"Рост: {this.height}");
            Console.WriteLine($"Дата рождения: {this.dateOfBirth}");
            Console.WriteLine($"Место рождения: {this.placeOfBirth}");
        }
        #endregion

   
    }

       
}




