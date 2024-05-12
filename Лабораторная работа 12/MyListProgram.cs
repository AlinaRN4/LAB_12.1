using ClassLibrary10lab;
namespace Лабораторная_работа_12
{
    internal class MyListProgram
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Часть 1");
            Console.WriteLine("Выберете действие со списком");
            Console.WriteLine("1. Создать список");
            Console.WriteLine("2. Печать списка");
            Console.WriteLine("3. Удалить из списка последний элемент с заданным информационным полем");
            Console.WriteLine("4. Добавить в список элемент после элемента с заданным информационным полем");
            Console.WriteLine("5. Глубокое клонирование");
            Console.WriteLine("6. Удалить список");
        }

        static void Main(string[] args)
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            int answer = 1;
            while (answer != 6)
            {
                try
                {
                    PrintMenu();
                    answer = int.Parse(Console.ReadLine());

                    switch (answer)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите размер списка");
                                int size = int.Parse(Console.ReadLine());
                                list.MakeList(size, list);


                                Console.WriteLine("Список создан!");
                                break;
                            }
                        case 2:
                            {
                                list.PrintList(list);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Введите имя элемента для удаления:");
                                string nameToRemove = Console.ReadLine();

                                bool removed = list.RemoveLastItemWithSpecifiedData(item => item.Name, nameToRemove);

                                if (removed)
                                { Console.WriteLine($"Последний элемент с именем '{nameToRemove}' удален."); }
                                else
                                { Console.WriteLine($"Элемент с именем '{nameToRemove}' не найден в списке."); }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Введите информационное поле элемента, после которого нужно добавить новый элемент:");
                                string dataToFind = Console.ReadLine(); // Ввод информационного поля элемента
                                list.AddAfter(item => item.Name, dataToFind);

                                break;
                            }
                        case 5:
                            {
                                MyList<MusicalInstrument> clonedList = new MyList<MusicalInstrument>();
                                clonedList.CloneList(list);
                                Console.WriteLine("Глубокое клонирование выполнено.");

                                break;
                            }
                        case 6:
                            {
                                list.Clear(list);
                                Console.WriteLine("Список удален из памяти.");
                                list.PrintList(list);

                                break;
                            }
                    }
                }
                catch (Exception e) { Console.WriteLine(e); }
            }
        }

    }
}
