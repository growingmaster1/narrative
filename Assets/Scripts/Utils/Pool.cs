using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string category;
    public Queue<GameObject> pool;
    public int head;
    public int length;
    public GameObject folder;
    public GameObject sample;

    public Pool(GameObject content, string name)
    {
        category = name;
        head = 0;
        pool = new Queue<GameObject>();
        length = 30;

        folder = new GameObject();
        folder.name = name;
        sample = content;

        GameObject newBorn;

        for (int i = 0; i < 30; ++i)
        {
            newBorn = MonoBehaviour.Instantiate<GameObject>(sample, folder.transform);
            newBorn.SetActive(false);
            pool.Enqueue(newBorn);
        }
    }

    public Pool(GameObject content, string name, int len)
    {
        category = name;
        head = 0;
        pool = new Queue<GameObject>();
        length = len;

        folder = new GameObject();
        folder.name = name;
        sample = content;

        GameObject newBorn;

        for (int i = 0; i < len; ++i)
        {
            newBorn = MonoBehaviour.Instantiate<GameObject>(sample, folder.transform);
            newBorn.SetActive(false);
            pool.Enqueue(newBorn);
        }
    }

    public Pool(GameObject content, string name, int len, GameObject inFolder)
    {
        category = name;
        head = 0;
        pool = new Queue<GameObject>();
        length = len;

        folder = inFolder;
        folder.name = name;
        sample = content;

        GameObject newBorn;

        for (int i = 0; i < len; ++i)
        {
            newBorn = MonoBehaviour.Instantiate<GameObject>(sample, folder.transform);
            newBorn.SetActive(false);
            pool.Enqueue(newBorn);
        }
    }

    public GameObject CreateFromPool()
    {
        GameObject toReturn = null;
        if (pool.Count > 0)
        {
            toReturn = pool.Dequeue();
        }
        else
        {
            toReturn = MonoBehaviour.Instantiate<GameObject>(sample, folder.transform);
        }

        toReturn.SetActive(true);

        return toReturn;
    }

    public void ReturnPool(GameObject unit)
    {
        pool.Enqueue(unit);
    }

    //public void PerishAll()
    //{
    //    foreach (IKill unit in folder.GetComponentsInChildren<IKill>())
    //    {
    //        unit.Kill();
    //    }
    //}
}
