using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace mysorttest
{
    class Program
    {
        static void Main()
        {
            int Length = 1000000; int Range = 10000;

            List<int> OriginalList = new List<int>();
            int[] OriginalArray;
            Stopwatch SW = new Stopwatch();

            //OriginalList = SetListA(Length, Range);
            //OriginalList = SetListB(Length, Range);
            OriginalList = SetListC(Length, Range);

            /*OriginalArray = OriginalList.ToArray();
            SW.Start();
            BubbleSort(OriginalArray, Length);
            SW.Stop();
            Console.WriteLine("BubbleSort " + SW.ElapsedMilliseconds + " ms");
            SW.Reset();*/

            OriginalArray = OriginalList.ToArray();
            SW.Start();
            YoyoSort(OriginalArray, Length);
            SW.Stop();
            Console.WriteLine("Y " + SW.ElapsedMilliseconds + " ms");
            SW.Reset();

            
            OriginalArray = OriginalList.ToArray();
            SW.Start();
            //QuickSort(OriginalArray, 0, Length - 1);
            SW.Stop();
            Console.WriteLine("Q " + SW.ElapsedMilliseconds + " ms");
            SW.Reset();


            OriginalArray = OriginalList.ToArray();
            SW.Start();
            CountingSort(OriginalArray);
            SW.Stop();
            Console.WriteLine("C " + SW.ElapsedMilliseconds + " ms");
            SW.Reset();

            OriginalArray = OriginalList.ToArray();
            SW.Start();
            //DedupingSticker(OriginalArray, Length);
            SW.Stop();
            Console.WriteLine("D " + SW.ElapsedMilliseconds + " ms");
            SW.Reset();
            /*for(int i = 0; i < 100; i++)
            {
                Console.Write(OriginalArray[i * Length / 100] + " ");
            }*/
        }

        static List<int> SetListA(int Length, int Range)
        {
            List<int> OriginalList = new List<int>();
            Random ran = new Random();
            for (int i = 0; i < Length; i++)
            {
                OriginalList.Add(ran.Next(Range));
            }
            return OriginalList;
        }

        static List<int> SetListB(int Length, int Offset)
        {
            List<int> OriginalList = new List<int>();
            for (int i = 0; i < Length; i++)
            {
                OriginalList.Add(i + Offset);
            }
            return OriginalList;
        }

        static List<int> SetListC(int Length, int Offset)
        {
            List<int> OriginalList = new List<int>();
            for (int i = 0; i < Length; i++)
            {
                OriginalList.Add(Length - i - 1 + Offset);
            }
            return OriginalList;
        }

        private static void CountingSort(int[] array)
        {
            var size = array.Length;
            int maxElement = 0;
            for (int i = 0; i < size; i++)
            {
                if (array[i] > maxElement)
                {
                    maxElement = array[i];
                }
            }
            var occurrences = new int[maxElement + 1];
            for (int i = 0; i < maxElement + 1; i++)
            {
                occurrences[i] = 0;
            }
            for (int i = 0; i < size; i++)
            {
                occurrences[array[i]]++;
            }
            for (int i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    array[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }
        }

        private static void DedupingSticker(int[] OriginalArray, int Length)
        {

            Dictionary<int, int> CountDict = new Dictionary<int, int>();

            for (int i = 0; i < Length; i++)
            {
                if (CountDict.ContainsKey(OriginalArray[i]) == false)
                {
                    CountDict.Add(OriginalArray[i], 1);
                }
                else
                {
                    CountDict[OriginalArray[i]]++;
                }
            }

            int[] SortedValue = new int[CountDict.Count];
            int SortedValueLen = CountDict.Count;

            int z = 0;
            foreach(var Entry in CountDict)
            {
                SortedValue[z] = Entry.Key;
                z++;
            }
            QuickSort(SortedValue, 0, SortedValueLen - 1);
			//원하는 정렬 아무거나, 단 SortedValue 가 변경되어야 함.


            for(int i = 0; i < SortedValueLen; i++)
            {
                OriginalArray[Length - SortedValueLen + i] = SortedValue[i];
            }
            int Index = 0;
            for(int i = 0; i < SortedValueLen; i++)
            {
                for(int x = 0; x < CountDict[OriginalArray[Length - SortedValueLen + i]]; x++)
                {
                    OriginalArray[Index] = OriginalArray[Length - SortedValueLen + i];
                    Index++;
                }
            }
        }

        private static void YoyoSort(int[] OriginalArray, int Length)
        {
            int Min = int.MaxValue;
            for (int i = 0; i < Length; i++)
            {
                if (OriginalArray[i] < Min)
                {
                    Min = OriginalArray[i];
                }
            }

            int Max = 0;
            for (int i = 0; i < Length; i++)
            {
                if (OriginalArray[i] > Max)
                {
                    Max = OriginalArray[i];
                }
            }

            Dictionary<int, int> CountDict = new Dictionary<int, int>();

            for (int i = 0; i < Length; i++)
            {
                if (CountDict.ContainsKey(OriginalArray[i]) == false)
                {
                    CountDict.Add(OriginalArray[i], 1);
                }
                else
                {
                    CountDict[OriginalArray[i]]++;
                }
            }

            int Index = 0;
            for(int i = Min; i < Max + 1; i++)
            {
                if (CountDict.ContainsKey(i) == true)
                {
                    for(int x = 0; x < CountDict[i]; x++)
                    {
                        OriginalArray[Index] = i;
                        Index++;
                    }
                }
            }
        }

        private static void BubbleSort(int[] OriginalArray, int Length)
        {
            for (int x = 0; x < Length; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    if (OriginalArray[x] > OriginalArray[y])
                    {
                        int temp = OriginalArray[x];
                        OriginalArray[x] = OriginalArray[y];
                        OriginalArray[y] = temp;
                    }
                }
            }
        }

        static int ArryDivide(int[] Arry, int left, int right)
        {
            int PivotValue, temp;
            int index_L, index_R;

            index_L = left;
            index_R = right;

            //Pivot 값은 0번 인덱스의 값을 가짐
            PivotValue = Arry[left];

            while (index_L < index_R)
            {
                //Pivot 값 보다 작은경우 index_L 증가(이동)
                while ((index_L <= right) && (Arry[index_L] < PivotValue))
                    index_L++;

                //Pivot 값 보다 큰경우 index_R 감소(이동)
                while ((index_R >= left) && (Arry[index_R] > PivotValue))
                    index_R--;

                //index_L 과 index_R 이 교차되지 않음
                if (index_L < index_R)
                {
                    temp = Arry[index_L];
                    Arry[index_L] = Arry[index_R];
                    Arry[index_R] = temp;

                    //같은 값이 존재 할 경우 
                    if (Arry[index_L] == Arry[index_R])
                        index_R--;
                }
            }

            //index_L 과 index_R 이 교차된 경우 반복문을 나와 해당 인덱스값을 리턴
            return index_R;
        }
        private static void QuickSort(int[] arry, int left, int right)
        {
            if (left < right)
            {
                int PivotIndex = ArryDivide(arry, left, right);

                QuickSort(arry, left, PivotIndex - 1);
                QuickSort(arry, PivotIndex + 1, right);
            }
        }
    }
}
