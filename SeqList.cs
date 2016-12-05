using UnityEngine;
using System.Collections;

/// <summary>


/// 顺序表实现方式


/// </summary>


/// <typeparam name="T"></typeparam>


public class SeqList<T> : IListDS<T>
{
    /// <summary>


    /// 用来存储数据


    /// </summary>


    private T[] data;

    /// <summary>


    /// 表示存了多少个数据


    /// </summary>


    private int count;

    public SeqList(int size)
    {
        data = new T[size];
        count = 0;
    }

    /// <summary>


    /// 默认构造函数 容量是10


    /// </summary>


    public SeqList()
        : this(10)
    {

    }

    public int GetLength()
    {
        return count;
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public void Add(T item)
    {
        if (count >= data.Length)
        {
            Debug.Log("当前顺序表已经存满，不允许再存入");
        }
        else
        {
            data[count] = item;
            count++;
        }
    }

    public void Insert(T item, int index)
    {
        //让集合中的元素向后移动一位


        for (int i = count - 1; i >= index; i--)
        {
            data[i + 1] = data[i];
        }
    }

    public T Delete(int index)
    {
        throw new System.NotImplementedException();
    }

    public T this[int index]
    {
        get { throw new System.NotImplementedException(); }
    }

    public T GetEle(int index)
    {
        if (index >= 0 && index <= count - 1)
        {
            return data[index];
        }

        Debug.Log("索引不存在");
        return default(T);
    }

    public int Locate(T value)
    {
        throw new System.NotImplementedException();
    }
}