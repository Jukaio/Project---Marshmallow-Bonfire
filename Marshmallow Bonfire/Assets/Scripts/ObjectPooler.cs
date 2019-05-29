using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject prefab;
    public int poolAmount;
    public Transform spawn;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public IEnumerator ActivateObj(Vector2 direction)
    {
        GameObject obj = GetObj();
        if (obj != null)
        {
            obj.transform.position = spawn.transform.position;
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);
    }

    public GameObject GetObj()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        GameObject obj = Instantiate(prefab);
        pooledObjects.Add(obj);
        return obj;
    }
}
