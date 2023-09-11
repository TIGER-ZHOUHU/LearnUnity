using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
        
        // 同一类型List
        List<int> list = LuaManager.GetInstance().Global.Get<List<int>>("testList");
        Debug.Log("**********************List**********************");
        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
        // 值拷贝 浅拷贝 不会改变lua中的内容
        list[0] = 100;
        List<int> list2 = LuaManager.GetInstance().Global.Get<List<int>>("testList");
        Debug.Log(list2[0]);
        
        // 不指定类型 object
        List<object> list3 = LuaManager.GetInstance().Global.Get<List<object>>("testList2");
        Debug.Log("**********************List object**********************");
        for (int i = 0; i < list3.Count; i++)
        {
            Debug.Log(list3[i]);
        }
        
        Debug.Log("**********************Dictionary**********************");
        Dictionary<string, int> Dic = LuaManager.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
        foreach (KeyValuePair<string,int> dic in Dic)
        {
            Debug.Log("Key:"+dic.Key + "Value:"+dic.Value);
        }
        //值拷贝 不会改变lua中的内容
        Dic["1"] = 23;
        Dictionary<string, int> Dic2 = LuaManager.GetInstance().Global.Get<Dictionary<string, int>>("testDic");
        Debug.Log(Dic2["1"]);
        
        Debug.Log("**********************Dictionary object**********************");
        Dictionary<object, object> Dic3 = LuaManager.GetInstance().Global.Get<Dictionary<object, object>>("testDic2");
        foreach (KeyValuePair<object,object> dic in Dic3)
        {
            Debug.Log("Key:"+dic.Key + "Value:"+dic.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
