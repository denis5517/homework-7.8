using System;
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
        public Repository (string path)
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
        /// <param name="isFull">Проверка заполнености</param>
        private void Rezize(bool isFull)
        {
            if (isFull)
            {
                Array.Resize(ref this.employees, this.employees.Length * 2);
            }
            #endregion

            Добавление нового работника в репозиторий

            #region Вывести всех сотрудников в консоль
            /// <summary>
            /// Выводит репозиторий в консоль
            /// </summary>
            public void PrinTAll()
            {
                for (int i = 0; i < index; i++)
                {
                    employees[i].Print();
                }
            }
            #endregion

            /// <summary>
            /// Метод добавления массива записей в ежедневник
            /// </summary>
            /// <param name="isFull">Массив записей</param>
            public void AddNotes(Note[] isFull)
            {
                int i = 0
                while (i < isFull.Length)                              // Цикл добавления
                {
                    Resize(this.index >= this.note.Length);          // Изменение размера
                    this.note[this.index] = isFull[i];               // Добавление элемента
                    i += 1;
                    this.index++;                                    // величение индекса
                }
            }

            /// <summary>
            /// Метод, удаляющий запись под конкретным индексом из массива
            /// </summary>
            /// <param name="index">Индекс записи </param>
            public void DeleteNotes(int Index)
            {
                Array.Clear(this.note, index - 1, 1);           //Удаление одной записи из массива под конкретным индексом

                for (int i = Index - 1; i < this.index - 1; i++)//Сдвиг записей назад на еденицу
                    this.note[i] = this.note[i + 1];

                this.index--;                                   //Уменьшение индекса
            }
            /// <summary>
            /// Метод, проверяющий наличие файла
            /// </summary>
            /// <returns>Наличие фала</returns>
            private bool CheckFile()
            {
                FileInfo fi = new FileInfo(path);

                if (!fi.Exists) fi.Create().Close();    //Создание файла в случае его отсутствия

                return fi.Exists;
            }
            /// <summary>
            /// Метод, проверяющий попадание введеного индекса диапазону массива ежедневника
            /// </summary>
            /// <returns>Индекс</returns>
            public int CheckIndex()
            {
                bool flag = false;
                int Index = 0;

                while (!flag)                                            //Цикл ввода и проверки
                {
                    flag = true;
                    flag = int.TryParse(Console.ReadLine(), out Index); //Проверка введеного значения

                    if (Index > this.index) flag = false;               //Проверка попадания в диапазон

                    if (!flag)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите индекс из диапазона индекса записей!");
                    }
                }
                return index;
            }
        }    

    }
}
}

