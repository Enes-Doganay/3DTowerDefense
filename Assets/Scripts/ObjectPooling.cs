using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    private GameObject prefab;
    public ObjectPool(GameObject prefab, int initialCapacity)
    {
        this.prefab = prefab;

        pool = new List<GameObject>(initialCapacity);
        for (int i = 0; i < initialCapacity; i++)
        {
            GameObject obj = CreateObject();
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    private GameObject CreateObject()
    {
        GameObject obj = GameObject.Instantiate(prefab);
        obj.gameObject.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = CreateObject();
        newObj.gameObject.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
}