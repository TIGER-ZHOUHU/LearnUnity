using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ABTest : MonoBehaviour
{
    public Image _Image;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj1 = ABManager.GetInstance().LoadRes("model", "Cube") as GameObject;
        //obj1.transform.position = Vector3.up;
        //GameObject obj = ABManager.GetInstance().LoadRes<GameObject>("model", "Cube");
        //obj.transform.position = Vector3.back;
        
        ABManager.GetInstance().LoadResAsync<GameObject>("model","Cube", (obj) =>
        {
            obj.transform.position = -Vector3.up;
        });
        ABManager.GetInstance().LoadResAsync<GameObject>("model","Cube", (obj) =>
        {
            obj.transform.position = Vector3.up;
        });
        // 关于AB包的依赖——一个资源身上用到了别的AB包中的资源 这个时候 如果只加载自己的AB包
        // 通过它创建对象 会出现资源丢失的情况
        // 这种时候 需要把依赖包 一起加载了 才能正常

        /*// 第一步 加载 AB包
        AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "model");
        // 加载依赖包
        //AssetBundle ab2 = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "tree");
        // 依赖包的关键知识点——利用主包 得到依赖信息
        // 加载主包
        AssetBundle abMain = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + "PC");
        // 加载主包中的固定文件
        AssetBundleManifest abManifest = abMain.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        // 从固定文件中 得到依赖信息
        string[] strs = abManifest.GetAllDependencies( "model");
        // 得到了 依赖包的名字
        for (int i = 0; i < strs.Length; i++)
        {
            AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + strs[i]);
        }
        
        // 第二步 加载 AB包资源
        // 只使用名字加载 会出现 同名不同类型资源 分不清
        // 建议 泛型加载 或者 是 Type指定类型
        // GameObject obj = ab.LoadAsset<GameObject>("Cube");
        GameObject obj = ab.LoadAsset("Cube", typeof(GameObject)) as GameObject;
        Instantiate(obj);

        //ab.Unload(false);
        // 卸载所有加载的AB包 参数为true 会把通过AB包加载的资源也卸载了
        //AssetBundle.UnloadAllAssetBundles(false);
        // AB包不能够重复加载 否则报错
        
        // 加载一个圆
        //GameObject obj2 = ab.LoadAsset("Sphere",typeof(GameObject)) as GameObject;
        //Instantiate(obj2,Vector3.up * 5, Quaternion.identity);
        
        //异步加载——>协程
        //StartCoroutine(LoadABRes("tree", "Image"));*/
    }

    IEnumerator LoadABRes(string ABName, string resName)
    {
        // 第一步 加载AB包
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(Application.streamingAssetsPath + "/" + ABName);
        yield return abcr;
        //第二步 加载资源
        AssetBundleRequest abq = abcr.assetBundle.LoadAssetAsync(resName, typeof(Sprite));
        yield return abq;
        //abq.asset as Sprite;
        _Image.sprite = abq.asset as Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
