using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Lesson9_CallLuaTable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");

        // 不建议使用LuaTable和LuaFunction 效率低
        // 引用对象
        LuaTable table = LuaManager.GetInstance().Global.Get<LuaTable>("testClas2");
        Debug.Log(table.Get<int>("testInt"));
        Debug.Log(table.Get<bool>("testBool"));
        Debug.Log(table.Get<float>("testFloat"));
        Debug.Log(table.Get<string>("testString"));
        
        table.Get<LuaFunction>("testFun").Call();
        // 改、引用拷贝
        table.Set("testInt",20000);
        Debug.Log(table.Get<int>("testInt"));
        LuaTable table2 = LuaManager.GetInstance().Global.Get<LuaTable>("testClas2");
        Debug.Log(table2.Get<int>("testInt"));

        table.Dispose();
        table2.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
