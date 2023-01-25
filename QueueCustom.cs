using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_lab_1
{
    public class QueueCustom<T>
    {
        private Object[] elements;
        private int size;

        public QueueCustom(int capacity)
        {
            elements = new Object[capacity];
        }

        public QueueCustom()
        {
            elements = new Object[1];
        }

        public T get(int index)
        {
            return (T)elements[index];
        }

        public void add(T e)
        {
            if (e == null)
            {
                throw new Exception();
            }
            if (size >= 1)
            {
                resizeGrow();
            }
            elements[size] = e;
            size++;
        }

        private void resizeGrow()
        {
            Object[] arr = new Object[elements.Length + 1];
            for (int i = 0; i < elements.Length; i++)
            {
                arr[i] = elements[i];
            }
            elements = arr;
        }

        private void resizeCut()
        {
            Object[] arr = new Object[elements.Length - 1];
            for (int i = 0; i < elements.Length - 1; i++)
            {
                arr[i] = elements[i + 1];
            }
            elements = arr;
        }

        public T poll()
        {
            T el = (T)elements[0];
            resizeCut();
            if(size == 1)
            {
                elements = new Object[1];
            }
            size--;
            return el;
        }

        public int Size()
        {
            return size;
        }
    }
}

