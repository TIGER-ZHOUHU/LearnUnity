using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T GetInstance()
    {
        // 继承了Mono的脚本 不能够直接new
        // 只能通过拖动到对象上 或者通过加脚本的api AddComponengt去加脚本
        // U3D内部帮助我们实例化它
        return instance;
    }

    protected void Awake()
    {
        instance = this as T;
    }
}
