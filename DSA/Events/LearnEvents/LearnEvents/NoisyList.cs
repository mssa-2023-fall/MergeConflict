using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEvents {
    public class NoisyList<T> {
        private List<T> list;

        public NoisyList() { list = new List<T>(); }
        public NoisyList(T[] _array) { list = new List<T>(_array); }

        public void Add(T item) { 
            list.Add(item);
            if (OnItemAdded != null) {
                var arg = new OnItemAddedEventArgs<T> {
                    CountBeforeAddition = list.Count - 1,
                    CountAfterAddition = list.Count,
                    ItemAdded = item,
                    InsertionTimestamp = DateTime.Now,
                    ItemPositionInList = list.IndexOf(item)
                };
                OnItemAdded.Invoke(this, arg);
            }

        }
        public void Clear() {
            list.Clear();
            if (OnListCleared != null) {
                OnListCleared.Invoke(this);
            }
        }
        public bool Contains(T item) { return list.Contains(item); }
        public void Remove(T item) { 
            list.Remove(item);
            if (OnItemRemoved != null) {
                OnItemRemoved.Invoke(this, (list.Count-1, list.Count, item, DateTime.Now));
                int a = 1;
                int b = 2;

                int c = swag1(a, b);
                int d = swag2(a, b);
            }
        }
        
        public string Name { get; set; }

        public T this[int i] {
            get => list[i];
            set => list[i] = value;
        }

        test1del swag1 = (in1, in2) => in1 + in2;
        test1del swag2 = (in1, in2) => in1 * in2;


        public event ItemAddedEventDelegate<T> OnItemAdded;
        public event Action<NoisyList<T>>OnListCleared;
        public event Action<NoisyList<T>,(int CBA,int CAA,T? ItemRemoved,DateTime RemoveTimeStamp)> OnItemRemoved;
                
    }
    public delegate int test1del(int a, int b);
    public delegate int test2del(Func<int, int, int> ourFunc);


    public delegate void ItemAddedEventDelegate<T>(NoisyList<T> sender, OnItemAddedEventArgs<T> args);

    public class OnItemAddedEventArgs<T> : EventArgs {
        public int CountBeforeAddition { get; set; }
        public int CountAfterAddition { get; set;}
        public T? ItemAdded { get; set;}
        public DateTime InsertionTimestamp { get; set;}
        public int ItemPositionInList { get; set;}
    }
}
