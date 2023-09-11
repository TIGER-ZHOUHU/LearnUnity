using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

[Hotfix]
public class HotfixTest{
    public HotfixTest(){
        Debug.Log("HotfixTest构造函数");
    }

    public void Speak(string str){
        Debug.Log(str);
    }
    ~HotfixTest(){

    }
}

[Hotfix]
public class HotfixTest2<T>{
    public void Test(T str){
        Debug.Log(str);
    }
}




[Hotfix]
public class HotfixMain : MonoBehaviour
{
    HotfixTest hotfixTest;
    public int[] array = new int[]{1,2,3};

    public int Age{
        get{return 0;}
        set{Debug.Log(value);}
    }

//索引器
    public int this[int index]{
        get{
            if(index >= array.Length || index < 0)
            {
                Debug.Log("索引不正确");
                return 0;
            }
            return array[index];
        }
        set{
            if(index >= array.Length || index < 0)
            {
                Debug.Log("索引不正确");
                return;
            }
            array[index] = value;
        }
    }
    // Start is called before the first frame update


    event UnityAction myEvent;
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().DoLuaFile("Main");
        Add(10,20);
        Speak("唐老师");
        hotfixTest = new HotfixTest();
        hotfixTest.Speak("Hahahaha");

        //StartCoroutine(TestCoroutine());
        this.Age = 100;
        Debug.Log(this.Age);

        this[99] = 199;
        Debug.Log(this[999]);

        myEvent += TestTest;
        myEvent -= TestTest;

        HotfixTest2<string> t1 = new HotfixTest2<string>();
        t1.Test("123");

        HotfixTest2<int> t2 = new HotfixTest2<int>();
        t2.Test(1000);
    }


    private void TestTest(){

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TestCoroutine(){
        while(true){
            yield return new WaitForSeconds(1f);
            Debug.Log("C#协程打印一次");
        }
    }
    public int Add(int a ,int b) 
    {
        Debug.Log("0");
        return 0;
    }

    public static void Speak(string str){
        Debug.Log("hahahah");
    }
}
