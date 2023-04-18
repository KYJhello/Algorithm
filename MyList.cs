using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // ############################
    // 2023-04-18
    // 김용준
    // List(Linear)
    // ############################
    internal class MyList<T>
    {
        // 디폴트 케퍼시티 값
        private const int DefaultCapacity = 10;
        // 사용할 배열
        private T[] arr;
        // 배열의 크기
        private int size;
        // 프로퍼티를 이용한 케퍼시티 정의
        public int Capacity { get { return arr.Length; } }
        // 프로퍼티를 이용한 카운트 정의
        public int Count { get { return size; } }

        // default MyList의 생성자
        public MyList() {
            this.arr = new T[DefaultCapacity];
            this.size = 0;
        }
        // 외부에서 리스트 케퍼시티를 따로 지정하기 위한
        // 새로운 생성자
        /// <summary>
        /// Capacity를 설정할 수 있는 MyList생성자
        /// </summary>
        /// <param name="capacityNum">매개변수를 리스트의 Capacity로 설정</param>
        public MyList(int capacityNum)
        {
            this.arr = new T[capacityNum];
            this.size = 0;
        }

        // indexer[]
        public T this[int index] // this키워드를 사용해 인덱서를 정의
        {
            // get 접근자는 값을 반환하고
            get => arr[index];
            // set 접근자는 값을 할당함
            set => arr[index] = value;
        }

        // Add(T)
        public void Add(T val)
        {
            // 만약 arr의 길이가 size와 같거나 크다면
            // 크기를 두배 늘려 재설정하는 Grow() 함수 실행
            if(size >=  arr.Length)
            {
                Grow();
            }
            // arr의 다음 원소에 값을 넣는다.
            arr[size++] = val;
        }
        // Grow()
        // 배열의 capacity를 넘어선 경우 
        // 현재 arr의 Length를 두배를해준 뒤
        // 기존 값을 복사하여 붙여넣고
        // 기존 arr에 newArr을 집어 넣는다
        public void Grow()
        {
            int newCapacity = arr.Length * 2;
            T[] newArr = new T[newCapacity];
            Array.Copy(arr, 0, newArr, 0, newCapacity);
            arr = newArr;
        }
        // Remove(T val)
        public bool Remove(T val)
        {
            int index = IndexOf(val);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }
        // RemoveAt(int idx)
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            size--;
            Array.Copy(arr, index + 1, arr, index, size - index);
        }
        // indexOf(T)
        public int IndexOf(T val)
        {
            return Array.IndexOf(arr, val, 0, size);
        }
        // T? Find(Predicate<T> match)
        public T? Find(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            for (int i = 0; i < size; i++)
            {
                if (match(arr[i]))
                {
                    return arr[i];
                }
            }
            return default(T);
        }

        // FindIndex(int startIndex, int count, Predicate<T> match)
        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < size; i++)
            {
                if (match(arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        
        // --------------------------------------

        // 배열, 선형리스트 기술면접 정리

        // ---------------------------------

        // FindLast
        public T? FindLast(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            for (int i = size; i >0 ; i--)
            {
                if (match(arr[i]))
                {
                    return arr[i];
                }
            }
            return default(T);
        }

        // CopyTo
        // public void CopyTo (T[] array);
        public void CopyTo(T[] array)
        {
            if(array.Length >= size)
            {
                Array.Copy(arr, 0, array, 0, size);
            }
            else
            {
                array = new T[size];
                Array.Copy(arr, 0, array, 0, size);
            }
        }
        // ToArray
        // public T[] ToArray ();
        public T[] ToArray()
        {

        }
        // public void Clear ();
        public void Clear()
        {

        }
        

    }
}
