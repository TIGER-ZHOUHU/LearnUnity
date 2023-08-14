using UnityEngine;
using UnityEngine.Pool;
public class FoodManager : MonoBehaviour
{
    // 所有准备好的食物
    public GameObject[] foods;
    // 没帧创建多少个
    public int number = 50;
    
    private ObjectPool<GameObject> foodPool;
    public bool useObjectPool;
    void Start()
    {
        foodPool = new ObjectPool<GameObject>(
            () =>
            {
                // 第一个createFunc 它将会在创建新对象的时候调用，这里实例化一个随机食物
                // 随机实例化一个食物
                var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                // 挂载Food脚本，注册销毁事件
                food.AddComponent<Food>().destroyEvent.AddListener(() =>
                {
                    // 这里不要直接去销毁它，而是调用对象池的Release方法，将它放回池子
                    foodPool.Release(food);
                });
                // 最后，返回创建好的food
                return food;
            },
            (go) =>
            {
                // actionOnGet
                // 会在通过池子获取对象的时候调用
                go.SetActive(true);
                // 设置位置 在随机的球形范围内
                go.transform.localPosition = Random.insideUnitSphere;
            },
            (go) =>
            {
                // actionOnRelease
                // 也就是对象放回池子里的时候会调用的回调，这里我们把需要放回池中的对象失活
                go.SetActive(false);
            },
            //actionOnDestroy 会在彻底销毁对象的时候调用
            // 这里直接去destroy它就可以了
            // 对象池会在你手动释放对象或者内部空间无法存储你返回的对象的时候，调用这个函数来销毁它们
            (go) => { Destroy(go); }
        );
    }
    void Update()
    {
        if (useObjectPool)
        {
            for (int i = 0; i < number; i++)
            {
                foodPool.Get();
            }
        }
        else
        {
            for (int i = 0; i < number; i++)
            {
                // 随机实例化一个食物
                var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                // 设置位置 在随机的球形范围内
                food.transform.localPosition = Random.insideUnitSphere;
                // 添加写好的Food组件，同时注册销毁事件
                food.AddComponent<Food>().destroyEvent.AddListener(() =>
                {
                    // 销毁食物
                    Destroy(food);
                });
            }
        }
    }
}