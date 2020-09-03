using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TShirtPool 
{
    static GameObject Tshirt;
    static List<GameObject> pooloftshirt;
    public static void Initialize()
    {
        Tshirt = Resources.Load<GameObject>("T-shirt");
        pooloftshirt = new List<GameObject>(3);
        for (int i=0;i<3;i++)
        {
            pooloftshirt.Add(GetnewTshirt());
        }
    }
    public static GameObject GetTshirt()
    {
        if (pooloftshirt.Count > 0)
        {
            GameObject temp = pooloftshirt[pooloftshirt.Count - 1];
            pooloftshirt.RemoveAt(pooloftshirt.Count - 1);
            return temp;
        }
        else
        {
            pooloftshirt.Capacity++;
            return GetnewTshirt();
        }
    }
    public static void ReturnTshirt(GameObject item)
    {
        item.SetActive(false);
        pooloftshirt.Add(item);
    }

    static GameObject GetnewTshirt()
    {
            GameObject temp = GameObject.Instantiate(Tshirt);
            temp.SetActive(false);
            GameObject.DontDestroyOnLoad(temp);
            return temp;
  
    }
}
