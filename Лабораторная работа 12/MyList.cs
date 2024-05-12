using ClassLibrary10lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_12
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T> head;
        public Point<T> tail;
        public int count; // кол-во элементов в списке

        public Point<T> MakePoint() // создаем элемент
        {
            T instrument = Activator.CreateInstance<T>();
            instrument.RandomInit();
            return new Point<T>(instrument);
        }

        public void Add() // добавляем элемент в список
        {
            Point<T> node = MakePoint();
            if (head is null) { head = node; } // Если список пуст, устанавливаем новый элемент как первый
            else
            {
                tail.Next = node; // У текущего последнего элемента списка (Tail) устанавливается ссылка на новую точку
                node.Pred = tail; // У новой точки устанавливается ссылка на предыдущий элемент списка
            }
            tail = node; // Новая точка становится последним элементом списка
            count++;
        }

        public void MakeList(int length, MyList<T> list) // Создаём список
        {
            if (length <= 0) { Console.WriteLine("Длина должна быть натуральным числом!"); }
            for (int i = 0; i < length; i++)
            {
                list.Add();
            }
        }

        public void PrintList(MyList<T> list) // печатаем список
        {
            if (list.head is null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            Point<T>? body = list.head; // инициализируется значением первого элемента списка
            while (body is not null)
            {
                Console.WriteLine(body);
                body = body.Next; // переход к следующему элементу 
            }
        }
        public void Clear(MyList<T> list) // удаляем весь список
        {
            list.head = null;
            list.tail = null;
            count = 0;
        }

        public bool RemoveLastItemWithSpecifiedData(Func<T, object> dataSelector, object data)
        {
            if (count == 0)
            {
                throw new Exception("the list is empty");
            }

            Point<T>? current = tail;

            while (current != null)
            {
                if (current.Data != null)
                {
                    var currentData = dataSelector(current.Data);

                    if (currentData != null && currentData.Equals(data))
                    {
                        // Удаляем последний элемент с заданными данными
                        Point<T>? prev = current.Pred;
                        Point<T>? next = current.Next;

                        if (prev != null)
                        {
                            prev.Next = next;
                        }
                        else
                        {
                            // Удаляемый элемент - первый в списке
                            head = next;
                        }

                        if (next != null)
                        {
                            next.Pred = prev;
                        }
                        else
                        {
                            // Удаляемый элемент - последний в списке
                            tail = prev;
                        }
                        count--;
                        return true;
                    }
                }
                current = current.Pred;
            }
            return false; // Не найден элемент с заданными данными
        }

        public void AddAfter(Func<T, object> dataSelector, object data)
        {
            if (count == 0)
            {
                throw new Exception("the list is empty"); // выбрасываем исключение, если список пуст
            }

            Point<T> newNode = MakePoint(); // Создаем новую точку

            Point<T>? current = head; // Указатель на текущий элемент

            while (current != null)
            {
                var currentData = dataSelector(current.Data); // Выбираем данные текущего элемента

                if (currentData != null && currentData.Equals(data))
                {
                    Point<T>? next = current.Next; // Указатель на следующий элемент

                    if (next != null)
                    {
                        // Вставляем новый элемент между текущим и следующим элементом
                        current.Next = newNode;
                        newNode.Pred = current;
                        newNode.Next = next;
                        next.Pred = newNode;

                        if (current == tail)
                        {
                            tail = newNode; // Обновляем Tail, если новый элемент добавлен в конец списка
                        }
                        count++; // Увеличиваем счетчик элементов
                        return;
                    }
                }
                current = current.Next; // Переходим к следующему элементу
            }
            Console.WriteLine("Элемент с заданным информационным полем не найден."); // Выводим сообщение об ошибке, если элемент не найден
        }
        public Point<T> CloneList(MyList<T> list)
        {
            if (list.head == null)
            {
                return null; // Возвращаем null, если список пуст
            }

            Point<T> head2 = new Point<T>();
            head2.Data = (T)list.head.Data.Clone();
            Point<T> b = head2;
            Point<T> p = list.head.Next;

            while (p != null)
            {
                Point<T> newp = new Point<T>();
                newp.Data = (T)(p.Data).Clone();
                newp.Pred = b;
                b.Next = newp;
                b = b.Next;
                p = p.Next;
            }
            return head2;
        }

        public override bool Equals(object? obj)
        {
            if (obj is MyList<T> p)
            {
                return this.head == p.head && this.tail == p.tail && this.count == p.count;
            }
            else { return false; }
        }
    }

}
