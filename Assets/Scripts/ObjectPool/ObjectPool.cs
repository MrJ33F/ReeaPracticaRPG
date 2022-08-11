using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject Parent;
    private PoolableObject Prefab;
    private int Size;

    private List<PoolableObject> AvailableObjectsPool;

    private ObjectPool(PoolableObject Prefab, int Size)
    {
        this.Prefab = Prefab;
        this.Size = Size;
        AvailableObjectsPool = new List<PoolableObject>(Size);
    }

    public static ObjectPool CreateInstance(PoolableObject Prefab, int Size)
    {
        ObjectPool pool = new ObjectPool(Prefab, Size);

        pool.Parent = new GameObject(Prefab + " Pool");
        pool.CreateObjects();

        return pool;
    }

    private void CreateObjects()
    {
        for (int index = 0; index < Size; index++) CreateObjects();
    }

    private void CreateObject()
    {
        PoolableObject poolableObject = GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity, Parent.transform);
        poolableObject.Parent = this;
        poolableObject.gameObject.SetActive(false); //PoolableObjects se ocupa cu re-adaugarea obiectelor la AvailableObjects
    }

    public PoolableObject GetObject()
    {
        if (AvailableObjectsPool.Count == 0) CreateObject();

        PoolableObject instance = AvailableObjectsPool[0];

        AvailableObjectsPool.RemoveAt(0);
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void ReturnObjectToPool(PoolableObject Object)
    {
        AvailableObjectsPool.Add(Object);
    }
}
