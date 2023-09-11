using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4_CallVariable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        
        LuaManager.GetInstance().DoLuaFile("Main");
        
        // 使用lua解析器luaenv中的 Global属性
        int i1 = LuaManager.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i1);
        i1 = 10;
        // 改值
        LuaManager.GetInstance().Global.Set("testNumber",55);
        // 值拷贝 不会影响原来lua中的值
        int i5 = LuaManager.GetInstance().Global.Get<int>("testNumber");
        Debug.Log("testNumber:" + i5);
        bool i2 = LuaManager.GetInstance().Global.Get<bool>("testBool");
        Debug.Log("testBool:"+i2);
        float i3 = LuaManager.GetInstance().Global.Get<float>("testFloat");
        Debug.Log("testFloat:"+i3);
        string i4 = LuaManager.GetInstance().Global.Get<string>("testString");
        Debug.Log("testString:"+i4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
