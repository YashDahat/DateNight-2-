using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlowersPool 
{
    static GameObject Flower;
    static List<GameObject> poolofflowers;
    public static void Initialize()
    {
        Flower = Resources.Load<GameObject>("flowers");
        poolofflowers = new List<GameObject>(3);
        for (int i = 0; i < 3; i++)
        {
            poolofflowers.Add(GetnewFlower());
        }
    }
    public static GameObject GetFlower()
    {
        if (poolofflowers.Count > 0)
        {
            GameObject temp = poolofflowers[poolofflowers.Count - 1];
            poolofflowers.RemoveAt(poolofflowers.Count - 1);
            return temp;
        }
        else
        {
            poolofflowers.Capacity++;
            return GetnewFlower();
        }
    }
    public static void ReturnFlower(GameObject item)
    {
        item.SetActive(false);
        poolofflowers.Add(item);
    }

    public static GameObject GetnewFlower()
    {
        GameObject temp = GameObject.Instantiate(Flower);
        temp.SetActive(false);
        GameObject.DontDestroyOnLoad(temp);
        return temp;
    }
}
