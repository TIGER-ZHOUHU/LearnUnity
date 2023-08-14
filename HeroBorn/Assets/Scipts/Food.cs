using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    //销毁事件
    public UnityEvent destroyEvent = new UnityEvent();
    // 使用一个bool值来防止对象进行重复销毁
    // 这是因为OnCollisionEnter有多次触发的风险
    public bool isDestroy;
    public void OnEnable()
    {
        isDestroy = false;
    }
    private void OnCollisionEnter(Collision colliscionInfo)
    {
        if (colliscionInfo.gameObject.CompareTag("Ground") && !isDestroy)
        {
            isDestroy = true;
            destroyEvent?.Invoke();
        }
    }
}