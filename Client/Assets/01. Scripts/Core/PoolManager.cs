using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance = null;

    [SerializeField] List<PoolableMono> poolingList = new List<PoolableMono>();
    private Dictionary<string, Pool<PoolableMono>> pools = new Dictionary<string, Pool<PoolableMono>>();
    private Transform parent = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Multiple " + this.GetType() + " is Running, Destroy This");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }

        parent = transform.GetChild(0);

        foreach(PoolableMono p in poolingList)
            CreatePool(p);    
    }

    private void CreatePool(PoolableMono _prefab)
    {
        Pool<PoolableMono> pool = new Pool<PoolableMono>(parent, _prefab);
        if(pools.ContainsKey(_prefab.name)) 
        {
            Debug.LogWarning("Current Pool Which Name of " + _prefab.name + " Already Exsit on Pools, Return");
            return;
        }

        pools.Add(_prefab.name, pool);
    }

    /// <summary>
    /// 타겟 _obj를 삭제
    /// </summary>
    /// <param name="_obj">타겟 오브젝트</param>
    public void Push(PoolableMono _obj)
    {
        if(!pools.ContainsKey(_obj.name))
        {
            Debug.LogWarning("Pool Which Name is " + _obj.name + " Doesnt Exsit on Pools, Return");
            return;
        } 

        pools[_obj.name].Push(_obj);
    }

    /// <summary>
    /// _prefabName으로 된 이름의 프리팹 소환
    /// </summary>
    /// <param name="_prefabName">소환할 프리팹 이름</param>
    /// <returns>소환된 PoolableMono</returns>
    public PoolableMono Pop(string _prefabName)
    {
        if(!pools.ContainsKey(_prefabName))
        {
            Debug.LogWarning("Pool Which Name is " + _prefabName + " Doesnt Exist on Pools, Returning Null");
            return null;
        }

        return pools[_prefabName].Pop();
    }
}
