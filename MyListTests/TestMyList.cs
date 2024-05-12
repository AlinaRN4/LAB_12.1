using ClassLibrary10lab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лабораторная_работа_12;
namespace MyListTests
{
    [TestClass]
    public class TestMyList
    {
        [TestMethod]
        public void MakePoint()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            var point = list.MakePoint();
            Assert.IsNotNull(point);
        }

        [TestMethod]
        public void Add()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            int initialCount = list.count;
            list.Add();
            Assert.AreEqual(initialCount + 1, list.count);
        }
        [TestMethod]
        public void Add_EmptyList_()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            list.Add();

            Assert.IsNotNull(list.head);
            Assert.IsNotNull(list.tail);
        }

        [TestMethod]
        public void MakeList_NonPositiveLength()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            // Подготовим поток для перехвата вывода
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Вызываем метод MakeList с отрицательным значением длины
            list.MakeList(-5, list);

            // Получаем строку из потока вывода
            string output = stringWriter.ToString().Trim();

            // Очищаем поток вывода
            stringWriter.Close();

            // Проверяем, что выводится сообщение о некорректной длине
            Assert.AreEqual("Длина должна быть натуральным числом!", output);
        }

        [TestMethod]
        public void MakeList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(5, list);
            Assert.AreEqual(5, list.count);
        }

        [TestMethod]
        public void Clear_EmptyList_HeadAndTailShouldBeNull()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            list.Clear(list);

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }
        [TestMethod]
        public void Clear()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(5, list);

            list.Clear(list);

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod]
        public void RemoveLastItemWithSpecifiedData()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(x => x.Name, 5));
        }
        [TestMethod]
        public void RemoveLastItemWithSpecifiedData_EmptyList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(x => x.Name, "Piano"));
        }

        [TestMethod]
        public void AddAfter_EmptyList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.AddAfter(x => x, 5));
        }

        [TestMethod]
        public void Equals_True()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            MyList<MusicalInstrument> list1 = new MyList<MusicalInstrument>();

            Assert.IsTrue(list.Equals(list1));
        }

        [TestMethod]
        public void Equals_False()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(3, list);

            MyList<MusicalInstrument> list1 = new MyList<MusicalInstrument>();
            list1.MakeList(4, list);

            Assert.IsFalse(list.Equals(list1));
        }

        [TestMethod]
        public void TestCloneList()
        {
            // Создаем список и добавляем элементы
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(3, list);


            // Клонируем список
            MyList<MusicalInstrument> clonedList = new MyList<MusicalInstrument>();
            clonedList.CloneList(list);

            Assert.IsTrue(list.Equals(clonedList));
        }

        [TestMethod]
        public void TestAddAfter()
        {
            // Создаем список и добавляем элементы
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(3, list);

            list.AddAfter(x => x, 2);
            Assert.AreEqual(4, 3);
        }

        [TestMethod]
        public void TestRemoveLastItemWithSpecifiedData()
        {
            // Arrange
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(30, list);

            string element = "Guitar";
            // Act
            bool result = list.RemoveLastItemWithSpecifiedData(x => x.Name, element);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(29, list.tail);
        }

        [TestMethod]
        public void TestAddAfter_ItemNotFound()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(10, list);

            string dataToFind = "Gui"; // Ввод информационного поля элемента

            Assert.ThrowsException<Exception>(() => list.AddAfter(item => item, dataToFind));
        }
        [TestMethod]
        public void RemoveLastItemEmptyListThrowsException()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(item => item.Name, "violin"));
        }
        [TestMethod]
        public void RemoveLastItem_ItemNotFound()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();


            bool result = list.RemoveLastItemWithSpecifiedData(item => item.Name, "violin");

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void CloneListEmptyListReturnsNull()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.IsNull(list.CloneList(list));
        }
        [TestMethod]
        public void Add_EmptyList_CreatesHeadAndTail()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.Add();
            Assert.IsNotNull(list.head);
            Assert.IsNotNull(list.tail);
        }

        [TestMethod]
        public void RemoveLastItemWithSpecifiedData_EmptyList_ThrowsException()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(item => item.Name, "SomeData"));
        }
        [TestMethod]
        public void MakePoint_WhenCalled_ReturnsNonNullPoint()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            var point = list.MakePoint();
            Assert.IsNotNull(point);
        }



    }
}
