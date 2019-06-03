using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    Mechanics mechanics;
    Transform projectileSpawn;
    int poolAmount;

    private void Start()
    {
        mechanics = GetComponent<Mechanics>();
        poolAmount = mechanics.mechanic1poolAmount;
        projectileSpawn = mechanics.projectileSpawn;

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(mechanics.mechanic1prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public void ActivateObj(Vector2 direction)
    {
        GameObject obj = GetObj();
        if (obj != null)
        {
            if (direction.x < 0)
            {
                obj.transform.position = new Vector2(projectileSpawn.transform.position.x - 1f, projectileSpawn.transform.position.y);
            }
            else if (direction.x > 0)
            {
                obj.transform.position = new Vector2(projectileSpawn.transform.position.x + 1f, projectileSpawn.transform.position.y);
            }
            
            obj.GetComponent<Projectile>().MoveProjectile(direction);
        }
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
        return null;
    }

}
