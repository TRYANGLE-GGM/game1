using System.Collections.Generic;
using UnityEngine;

public class Pool <T> where T : PoolableMono 
{
    private Stack<T> pool = new Stack<T>();
    private Transform parent = null;
    private T prefab = null;

    public Pool(Transform _parent, T _prefab)
    {
        this.parent = _parent;
        this.prefab = _prefab;
    }

    public void Push(T _obj)
    {
        _obj.gameObject.SetActive(false);
        _obj.transform.SetParent(parent);
        pool.Push(_obj);
    }

    public T Pop()
    {
        T temp = null;

        if(pool.Count > 0)
        {
            temp = pool.Pop();
            temp.gameObject.SetActive(true);
        }
        else
        {
            temp = GameObject.Instantiate(prefab, parent);
            temp.name = temp.name.Replace("(Clone)", "");
        }

        temp.transform.SetParent(null);
        temp.Reset();

        return temp;
    }
}
