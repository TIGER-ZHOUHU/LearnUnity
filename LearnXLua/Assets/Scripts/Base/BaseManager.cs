using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// C#中 泛型的知识
/// 设计模式中 单例模式的知识
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseManager<T> where T:new()
{
    private static T instance;

    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }

}
