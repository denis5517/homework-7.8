using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_7._8
{
    class Repository
    {
        private string path;
        private int index;
        Employee[] employees;

        #region Конструктор
        public Repository(string path)
        {
            this.path = path;
            this.index = 0;
            this.employees = new Employee[2];
        }
        #endregion

        #region Увеличивает размер хранилища
        /// <summary>
        /// Увеличивает размер хранилища
        /// </summary>
        /// <param name="isFull">Проверка заполненности</param>
        private void Resize(bool isFull)
        {
            if (isFull)
            {
                Array.Resize(ref this.employees, this.employees.Length * 2);
            }
        }
        #endregion

        #region Добавление нового работника в репозиторий
        /// <summary>
        /// Добавляет работника в хранилище
        /// </summary>
        /// <param name="newEmployee">Работник</param>
        public void AddEmployee(Employee newEmployee)
        {
            Resize(index >= this.employees.Length);
            employees[index] = newEmployee;
            this.index++;
        }
        #endregion

        #region Вывести всех сотрудников в консоль
        /// <summary>
        /// Выводит репозиторий в консоль
        /// </summary>
        public void PrintAll()
        {
            for (int i = 0; i < index; i++)
            {
                employees[i].Print();
            }
        }
        #endregion

        #region Записать репозиторий в файл
        /// <summary>
        /// Записывает все данные в файл
        /// </summary>
        public void SaveToFile()
        {
            File.Delete(path);
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.UTF8))
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    string line = string.Empty;
                    line += employees[i].employeeId + '#';
                    line += employees[i].addingTime + '#';
                    line += employees[i].fullName + '#';
                    line += employees[i].age + '#';
                    line += employees[i].height + '#';
                    line += employees[i].dateOfBirth + '#';
                    line += employees[i].placeOfBirth;

                    sw.Write(line);
                    sw.WriteLine();
                }
                Console.WriteLine("Изменения сохранены!");
            }
        }
        #endregion

        #region Загрузка репозитория из файла
        /// <summary>
        /// Заполнить хранилищи данными из файла
        /// </summary>
        public void LoadFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split('#');

                        AddEmployee(new Employee(
                            args[0],
                            args[1],
                            args[2],
                            args[3],
                            args[4],
                            args[5],
                            args[6]));
                    }
                }
            }
            catch
            {
                Console.WriteLine("Файла базы данных не существует");
            }
        }

        #endregion

        #region Измененить сотрудника
        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        public void UpdateEmployee()
        {
            Console.WriteLine("Введите Id:");
            string searchId = Console.ReadLine();
            bool employeeFound = false;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].employeeId.Equals(searchId))
                {
                    Console.WriteLine("Введите ФИО сотрудника:");
                    employees[i].fullName = Console.ReadLine();

                    Console.WriteLine("Введите возраст сотрудника:");
                    employees[i].age = Console.ReadLine();

                    Console.WriteLine("Введите рост сотрудника:");
                    employees[i].height = Console.ReadLine();

                    Console.WriteLine("Введите дату рождения сотрудника:");
                    employees[i].dateOfBirth = Console.ReadLine();

                    Console.WriteLine("Введите место рождения сотрудника:");
                    employees[i].placeOfBirth = Console.ReadLine();
                    employeeFound = true;
                    break;
                }
            }
            if (employeeFound)
            {
                Console.WriteLine("Сотрудник удален");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Сотрудник не найден");
                Console.WriteLine();
            }
        }
        #endregion

        #region Удаляет сотрудника по ID
        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
        /// <param name="searchId">Id сотрудника</param>

        public void DeleteEmployee()
        {
            Console.WriteLine("Введите Id:");
            string searchId = Console.ReadLine();
            bool employeeFound = false;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].employeeId.Equals(searchId))
                {
                    for (int j = i; j < employees.Length - 1; j++)
                    {
                        employees[j] = employees[j + 1];
                    }
                    employeeFound = true;
                    break;
                }
            }
            if (employeeFound)
            {
                Console.WriteLine("Сотрудник удален");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Сотрудник не найден");
                Console.WriteLine();
            }
        }
        #endregion

        #region Сортировка по дате
        /// <summary>
        /// Сортирует сотрудников по дате рождения
        /// </summary>
        public void SortByBirthday()
        {
            Console.WriteLine(
                "\t1: по возрастанию\n" +
                "\t2: по убыванию\n");

            switch (Console.ReadLine())
            {
                case "1":
                    employees = employees.OrderBy(employee => DateTime.Parse(employee.dateOfBirth)).ToArray();
                    Console.WriteLine("Отсортировано по возрастанию\n");
                    break;
                case "2":
                    employees.OrderByDescending(employee => DateTime.Parse(employee.dateOfBirth)).ToArray();
                    Console.WriteLine("Отсортировано по убыванию\n");
                    break;
            }
        }
        #endregion

        #region Создает нового сотрудника
        /// <summary>
        /// Пошагово создает нового сотрудника с выводом подсказок в консоль
        /// </summary>
        /// <returns>Возвращает созданного сотрудника</returns>
        public Employee CreateEmployee()
        {
            Console.WriteLine("Введите ID:");
            string employeeId = Console.ReadLine();

            string currentTime = DateTime.Now.ToString();
            Console.WriteLine($"Время добавления: {currentTime}");

            Console.WriteLine("Введите ФИО сотрудника:");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите возраст сотрудника:");
            string age = Console.ReadLine();

            Console.WriteLine("Введите рост сотрудника:");
            string height = Console.ReadLine();

            Console.WriteLine("Введите дату рождения сотрудника:");
            string dateOfBirth = Console.ReadLine();

            Console.WriteLine("Введите место рождения сотрудника:");
            string placeOfBirth = Console.ReadLine();

            return new Employee(employeeId, currentTime, fullName, age, height, dateOfBirth, placeOfBirth);
        }
        #endregion
    }
}

