using System;

namespace Algo
{
    public static class Sort<T> where T : IComparable
    {
        #region Quick Sort

        public static void QuickSort(T[] items)
        {
            Shuffle(items);
            QuickSort(items, 0, items.Length - 1);
        }
        static void QuickSort(T[] items, int lo, int hi)
        {
            if (lo >= hi)
                return;
            var p = Partition(items, lo, hi);
            QuickSort(items, lo, p - 1);
            QuickSort(items, p + 1, hi);
        }
        static int Partition(T[] items, int lo, int hi)
        {
            var i = lo;
            var j = hi;
            var p = lo;
            var pValue = items[p];
            while (true)
            {
                if (i < j && !GreaterThan(items[i], pValue))
                    i++;
                if (j >= i && GreaterThan(items[j], pValue))
                    j--;
                if (j <= i)
                    break;
                Exch(items, i, j);
            }
            Exch(items, p, j);
            return j;
        }

        #endregion

        #region Quick Sort v2

        public static void QuickSortV2(T[] items)
        {
            Shuffle(items);
            QuickSortV2(items, 0, items.Length - 1);
        }

        private static void QuickSortV2(T[] items, int lo, int hi)
        {
            if (lo >= hi) return;
            var p = PartitionV2(items, lo, hi);
            QuickSortV2(items, lo, p - 1);
            QuickSortV2(items, p + 1, hi);
        }

        private static int PartitionV2(T[] items, int lo, int hi)
        {
            var p = lo;
            var i = lo;
            var j = hi;
            while (true)
            {
                while (i < j && !GreaterThan(items[i], items[p])) i++;
                while (j >= i && GreaterThan(items[j], items[p])) j--;
                if (j <= i) break;
                Exch(items, i, j);
            }

            Exch(items, p, j);

            return j;
        }

        #endregion

        #region Merge Sort

        public static void MergeSort(int[] items)
        {
            var aux = new int[items.Length];
            MergeSort(items, aux, 0, items.Length - 1);
        }
        static void MergeSort(int[] a, int[] aux, int lo, int hi)
        {
            if (lo >= hi)
                return;
            var mid = (lo + hi) / 2;
            MergeSort(a, aux, lo, mid);
            MergeSort(a, aux, mid + 1, hi);
            if (a[mid] <= a[mid + 1])
                return;
            Merge(a, aux, lo, mid, hi);
        }
        static void Merge(int[] a, int[] aux, int lo, int mid, int hi)
        {
            for (var k = lo; k <= hi; k++)
                aux[k] = a[k];

            var i = lo;
            var j = mid + 1;
            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (aux[i] <= aux[j])
                    a[k] = aux[i++];
                else
                    a[k] = aux[j++];
            }
        }

        #endregion

        #region Merge Sort v2
        public static void MergeSortV2(T[] items)
        {
            var aux = new T[items.Length];
            MergeSortV2(items, aux, 0, items.Length - 1);
        }

        private static void MergeSortV2(T[] items, T[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            var mid = (lo + hi) / 2;
            MergeSortV2(items, aux, lo, mid);
            MergeSortV2(items, aux, mid + 1, hi);
            MergeV2(items, aux, lo, mid, hi);
        }

        private static void MergeV2(T[] a, T[] aux, int lo, int mid, int hi)
        {
            // verify if merge is necessary
            if (!GreaterThan(a[mid], a[mid + 1])) return;

            // copy to aux
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];

            // compare and exch
            var i = lo;
            var j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (!GreaterThan(aux[i], aux[j]))
                    a[k] = aux[i++];
                else
                    a[k] = aux[j++];
            }
        }
        #endregion

        #region Shuffle: liner

        static void Shuffle(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                var rd = new Random();
                var r = rd.Next(i + 1);
                Exch(items, r, i);
            }
        }

        #endregion

        #region Util tools

        static void Exch(T[] items, int i, int j)
        {
            if (i == j)
                return;
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        static bool GreaterThan(T objectA, T objectB)
        {
            return objectA.CompareTo(objectB) == 1;
        }

        public static bool IsSorted(T[] items)
        {
            var l = items.Length;
            for (int i = 1; i < l / 2 + 1; i++)
            {
                if (GreaterThan(items[i - 1], items[i]) || GreaterThan(items[l - i - 1], items[l - i]))
                    return false;
            }
            return true;
        }

        //public static bool IsSorted<T>(IEnumerable<T> list) where T : IComparable<T>
        //{
        //    var y = list.First();
        //    return list.Skip(1).All(x =>
        //    {
        //        bool b = y.CompareTo(x) < 0;
        //        y = x;
        //        return b;
        //    });
        //}

        #endregion
    }
}

