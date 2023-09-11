using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;
using XLua.Cast;
using Object = UnityEngine.Object;

#region 第一次课
//自定义类
public class Test
{
    public void Speak(string str)
    {
        Debug.Log("Test1:"+str);
    }
}

namespace Mrzhou
{
    public class Test2
    {
        public void Speak(string str)
        {
            Debug.Log("Test2:"+str);
        }
    }
}
#endregion

#region 枚举
/// <summary>
/// 自定义枚举
/// </summary>
public enum  myEnum
{
    Idle,
    move,
    attack
}
#endregion

#region 数组、List、字典

public class Lesson3
{
    public int[] array = new int[5] { 1, 2, 3, 4, 5 };
    public List<int> list = new List<int>();
    public Dictionary<int, string> dictionary = new Dictionary<int, string>();
}

#endregion

#region 拓展方法

// 想要在LUa中使用拓展方法 一定要在工具类前面加上特性
// 建议 Lua中要使用的类 都加上该特性 可以提升性能
// 如果不加该特性 除了拓展方法对应的类 其他类的使用 都不会报错
// 但是lua是通过反射的机制去调用的C#类 效率较低
[LuaCallCSharp]
public static class Tools
{
    // Lesson4的拓展方法
    public static void Move(this Lesson4 obj)
    {
        Debug.Log(obj.name + "移动");
    }
}
public class Lesson4
{
    public string name = "tiger";

    public void Speak(string str)
    {
        Debug.Log(str);
    }

    public static void Eat()
    {
        Debug.Log("吃东西");
    }
}

#endregion

#region ref和out

[CSharpCallLua]
public class Lesson5
{
    public int RefFun(int a, ref int b, ref int c, int d)
    {
        b = a + d;
        c = a - d;
        return 100;
    }

    public int OutFun(int a, out int b, out int c, int d)
    {
        b = a;
        c = d;
        return 200;
    }

    public int RefOutFun(int a, out int b, ref int c)
    {
        b = a * 100;
        c = a * 220;
        return 300;
    }
}

#endregion

#region 函数重载

public class Lesson6
{
    public int Calc()
    {
        return 100;
    }

    public int Calc(int a, int b)
    {
        return a + b;
    }

    public int Calc(int a)
    {
        return a;
    }

    public float Calc(float a)
    {
        return a;
    }
}

#endregion

#region 委托和事件

public class Lesson7
{
    //声明委托和事件
    public UnityAction del;
    public event UnityAction eventAction;

    public void DoEvent()
    {
        if (eventAction != null)
        {
            eventAction();
        }
    }

    public void ClearEvent()
    {
        eventAction = null;
    }
}

#endregion

#region 二维数组遍历

public class Lesson8
{
    public int[,] array = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
    
}

#endregion

#region 判空

//为Object 拓展一个方法
[CSharpCallLua]
public static class Lesson9
{
    //拓展一个维Object判空的方法 主要是给lua用 lua没法用null和nil比较
    public static bool IsNull(this Object obj)
    {
        return obj == null;
    }
}

#endregion

#region 系统类型加特性

public static class Lesson10
{
    [CSharpCallLua] 
    public static List<Type> csharpCallLuaList = new List<Type>()
    {
        typeof(UnityAction<float>)
    };
    
    [LuaCallCSharp]
    public static List<Type> luaCallCsharpList = new List<Type>()
    {
        typeof(GameObject),
        typeof(Rigidbody)
    };
}

#endregion

#region 调用泛型方法

public class Lesson12
{
    public interface ITest
    {
        
    }
    public class TestFather
    {
        
    }
    public class TestChild:TestFather,ITest
    {
        
    }
    public void TestFun1<T>(T a, T b) where T:TestFather
    {
        Debug.Log("有参数有约束的泛型方法");
    }

    public void TestFun2<T>(T a)
    {
        Debug.Log("有参数 没有约束");
    }

    public void TestFun3<T>() where T : TestFather
    {
        Debug.Log("有约束，但是没有参数的泛型函数");
    }

    public void TestFun4<T>(T a) where T : ITest
    {
        Debug.Log("有约束有参数，但是约束不是类");
    }
}

#endregion
public class LuaCallCSharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
