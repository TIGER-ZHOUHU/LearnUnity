using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_LuaManager : MonoBehaviour
{
    private void Start()
    {
        // 初始化解析器
        LuaManager.GetInstance().Init();
        
        LuaManager.GetInstance().DoLuaFile("Main");
    }
}
