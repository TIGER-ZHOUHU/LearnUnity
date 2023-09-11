using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// Lua管理器
/// 提供 lua解析器
/// 保证解析器的唯一性
/// </summary>
public class LuaManager : BaseManager<LuaManager>
{
    // 执行Lua语言的函数
    // 释放垃圾
    // 销毁
    // 重定向
    private LuaEnv _luaEnv;

    /// <summary>
    /// 得到Lua中的_G
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return _luaEnv.Global;
        }
    }
    
    /// <summary>
    /// 初始化解析器
    /// </summary>
    public void Init()
    {
        if(_luaEnv != null)
            return;
        //初始化
        _luaEnv = new LuaEnv();
        //加载lua脚本 重定向
        _luaEnv.AddLoader(MyCustomLoader);
        _luaEnv.AddLoader(MyCustomABLoader);
        
    }
    
    // 自动执行
    private byte[] MyCustomLoader(ref string filePath)
    {
        // 传入的参数 是 require执行的lua脚本文件名
        // 拼接一个Lua文件所在路径
        string path = Application.dataPath + "/Lua/" + filePath + ".Lua";
        //Debug.Log(path);
        
        // 有路径 就去加载文件
        // File知识点 C#提供的文件读写的类
        // 判断文件是否存在
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重定向失败，文件名为：" + filePath);
        }
        // 通过函数中的逻辑 去加载 Lua文件
        return null;
    }

    // Lua脚本会放在AB包
    // 最终我们会通过加载AB包 再加载其中的Lua脚本资源 来执行它
    // AB包中如果要加载文本 后缀还是有一定的限制 .lua不能被识别
    // 打包时 要把lua的后缀改为 .txt
    private byte[] MyCustomABLoader(ref string filePath)
    {
        /*// 从AB包中加载lua文件
        // 加载AB包
        string path = Application.streamingAssetsPath + "/lua";
        AssetBundle ab = AssetBundle.LoadFromFile(path);
        
        //加载lua文件 返回
        TextAsset tx = ab.LoadAsset<TextAsset>(filePath + ".lua");
        //加载Lua文件 byte数组
        return tx.bytes;*/

        // 通过我们的AB包管理器 加载的lua脚本资源
        TextAsset lua = ABManager.GetInstance().LoadRes<TextAsset>("lua", filePath + ".lua");
        if (lua != null)
            return lua.bytes;
        else
        {
            Debug.Log("MyCustomABLoader重定向失败，文件名为：" + filePath);
        }

        return null;
    }

    /// <summary>
    /// 传入lua文件名 执行lua脚本
    /// </summary>
    /// <param name="fileName"></param>
    public void DoLuaFile(string fileName)
    {
        string str = string.Format("require('{0}')", fileName);
        DoString(str);
    }
    
    /// <summary>
    /// 执行lua语言
    /// </summary>
    /// <param name="str"></param>
    public void DoString(string str)
    {
        if (_luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        _luaEnv.DoString(str);
    }

    /// <summary>
    /// 释放lua 垃圾
    /// </summary>
    public void Tick()
    {
        if (_luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        _luaEnv.Tick();
    }

    /// <summary>
    /// 销毁解析器
    /// </summary>
    public void Dispose()
    {
        if (_luaEnv == null)
        {
            Debug.Log("解析器未初始化");
            return;
        }
        _luaEnv.Dispose();
        _luaEnv = null;
    }
}
