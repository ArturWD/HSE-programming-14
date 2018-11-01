using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsLib
{
    public class MyQueue<T> where T: Animal
    {
        protected List<T> list;

        // создаём делегат, определяющий метод генерации коллекции
        public delegate List<T> GenerateList(int count);
        public GenerateList genList;
        // создаём делегат, определяющий метод сортировки коллекции
        public delegate void SortList(List<T> list);
        public SortList sortList;


        public MyQueue()
        {
            list = new List<T>();
        }
        public MyQueue(MyQueue<T> origin)
        {
            List = new List<T>(origin.List);
        }


        public List<T> List
        {
            get { return this.list; }
            set { list = value; }
        }
        // Реализация интерфейсов
        //индексатор
        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                    throw new IndexOutOfRangeException();
                return list[index];
            }

            set
            {
                if (index < 0 || index >= list.Count)
                    throw new IndexOutOfRangeException();
                list[index] = value;
            }
        }
        //указывает на текущий элемент
        int position = -1;
        public void Reset()
        {
            position = -1;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in list) yield return item;
        }


        // ПРИМЕНЕНИЕ ДЕЛЕГАТОВ
        public virtual void Generate(int cap)
        {
            if (genList != null) list = genList(cap);
            else throw new NullReferenceException();
            
        }
        public virtual void Sort()
        {
            if (sortList != null) sortList(list);
            else throw new NullReferenceException();
        }


        // ОСТПЛЬНЫЕ МЕТОДЫ
        public virtual int Capacity()
        {
            return list.Capacity;
        }
        public virtual int Length()
        {
            return list.Count;
        }
        public virtual void Clear()
        {
            list.Clear();
        }
        public virtual bool Contains(T v)
        {
            return list.Contains(v);
        }
        public virtual T Dequeue()
        {
            T first = list[0];
            list.RemoveAt(0);
            return first;
        }
        public virtual void Enqueue(T v)
        {
            list.Add(v);
        }
        public virtual T Peek()
        {
            return list[0];
        }
        public virtual T[] ToArray()
        {
            return list.ToArray();
        }
        public virtual MyQueue<T> Clone()
        {
            MyQueue<T> clone = new MyQueue<T>(this);
            return clone;
        }
        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }
    }
}
