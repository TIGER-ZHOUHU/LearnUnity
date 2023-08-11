using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sorting
{
    /// <summary>
    /// 冒泡排序  升序
    /// swapped用来验证是否排序完
    /// </summary>
    /// <param name="intArray"></param>
    static void BubbleSort(int[] intArray)
    {
        int temp = 0;
        bool swapped;
        for (int i = 0; i < intArray.Length; i++)
        {
            swapped = false;
            for (int j = 0; j < intArray.Length - 1 - i; j++)
            {
                if (intArray[j]>intArray[j+1])
                {
                    temp = intArray[j];
                    intArray[j] = intArray[j + 1];
                    intArray[j + 1] = temp;
                    if (!swapped)
                    {
                        swapped = true;
                    }
                }
            }
            if (!swapped)
            {
                return;
            }
        }
    }

    /// <summary>
    /// 选择排序  升序
    /// </summary>
    /// <param name="arr"></param>
    /// <typeparam name="T"></typeparam>
    static void selection_sort<T>(T[] arr) where T : System.IComparable<T>
    {
        int min;
        T temp;
        for (int i = 0; i < arr.Length-1; i++)
        {
            min = i;
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[min].CompareTo(arr[j]) > 0)
                {
                    min = j;
                }
            }
            temp = arr[min];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }

    /// <summary>
    /// 插入排序  升序
    /// </summary>
    /// <param name="array"></param>
    public static void InsertSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int temp = array[i];
            for (int j = i-1; j >=0; j--)
            {
                if (array[j]>temp)
                {
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
                else
                {
                    break;
                }
            }
        }
    }

    /// <summary>
    /// 希尔排序 
    /// </summary>
    /// <param name="array"></param>
    static void ShellSort(int[] array)
    {
        int gap = 1;
        while (gap < array.Length)
        {
            gap = gap * 3 + 1;
        }

        while (gap > 0)
        {
            for (int i = gap; i < array.Length; i++)
            {
                int temp = array[i];
                int j = i - gap;
                while (j>=0 && array[j] > temp)
                {
                    array[j + gap] = array[j];
                    j = j - gap;
                }
                array[j + gap] = temp;
            }
            gap /= 3;
        }
    }

    /// <summary>
    /// 归并排序 升序
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public static List<int> sort(List<int> list)
    {
        if (list.Count <= 1)
        {
            return list;
        }

        int mid = list.Count / 2;
        List<int> left = new List<int>();//定义左侧链表
        List<int> right = new List<int>();//定义右侧链表
        //以下两个循环把list分为左右两个List
        for (int i = 0; i < mid; i++)
        {
            left.Add(list[i]);
        }

        for (int i = mid; i < list.Count; i++)
        {
            right.Add(list[i]);
        }

        left = sort(left);
        right = sort(right);
        return merge(left, right);
    }
    /// <summary>
    /// 合并两个已经拍好的序的List
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    static List<int> merge(List<int> left, List<int> right)
    {
        List<int> temp = new List<int>();
        while (left.Count > 0 && right.Count > 0)
        {
            if (left[0] < right[0])
            {
                temp.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                temp.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        if (left.Count>0)
        {
            for (int i = 0; i < left.Count; i++)
            {
                temp.Add(left[i]);
            }
        }
        if (right.Count > 0)
        {
            for (int i = 0; i < right.Count; i++)
            {
                temp.Add(right[i]);
            }
        }
        return temp;
    }

    /// <summary>
    /// 快速排序 升序
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    static void QuickSort(int[] array, int left = 0, int right = -1)
    {
        if (right.Equals(-1))
        {
            right = array.Length - 1;
        }

        try
        {
            //记录关键值的下标
            int keyValuePosition;
            //当传递的目标数组含有两个以上的元素时，进行递归调用。（即：当传递的目标数组只含有一个元素时，此趟排序结束）
            if (left < right)
            {
                keyValuePosition = Partion(array, left, right);//获取关键值的下标（快排的核心）
                QuickSort(array,left,keyValuePosition - 1);//递归调用，快排划分出来的左区间
                QuickSort(array,keyValuePosition + 1,right);//递归调用，快排划分出来的右区间
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    /// <summary>
    /// 快速排序的核心部分：确定关键值在数组中的位置，以此将数组划分成左右两区间，关键值游离在外。（返回关键字应在数组中的下标）
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static int Partion(int[] array, int left, int right)
    {
        int leftIndex = left;       //记录目标数组的起始位置（后续动态的左侧下标）
        int rightIndex = right;     //记录目标数组的结束位置（后续动态的右侧下标）
        int keyValue = array[left]; //数组的第一个元素作为关键值
        int temp;

        // 当（左侧动态下标 == 右侧动态下标）时跳出循环
        while (leftIndex < rightIndex)
        {
            //左侧动态下标逐渐增加，直至找到大于keyValue的下标
            while (leftIndex < rightIndex && array[leftIndex] <= keyValue)
            {
                leftIndex++;
            }
            //右侧动态下标逐渐减小，直至找到小于或等于keyValue的下标
            while (leftIndex < rightIndex && array[rightIndex] > keyValue)
            {
                rightIndex--;
            }
            //如果leftIndex < rightIndex，则交换左右动态下标所指定的值；当leftIndex==rightIndex时，跳出整个循环
            if (leftIndex < rightIndex)
            {
                temp = array[leftIndex];
                array[leftIndex] = array[rightIndex];
                array[rightIndex] = temp;
            }
        }
        //当左右两个动态下标相等时（即：左右下标指向同一个位置），此时便可以确定keyValue的准确位置
        temp = keyValue;
        //当keyValue < 左右下标同时指向的值，将keyValue与rightIndex - 1指向的值交换，并返回rightIndex - 1
        if (temp < array[rightIndex])
        {
            array[left] = array[rightIndex - 1];
            array[rightIndex - 1] = temp;
            return rightIndex - 1;
        }
        //当keyValue >= 左右下标同时指向的值，将keyValue与rightIndex指向的值交换，并返回rightIndex
        else
        {
            array[left] = array[rightIndex];
            array[rightIndex] = temp;
            return rightIndex;
        }
    }
}
