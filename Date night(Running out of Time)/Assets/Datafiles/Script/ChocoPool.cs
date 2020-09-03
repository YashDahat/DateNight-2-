using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChocoPool
{
    static GameObject Choco;
    static List<GameObject> poolofChoco;
    public static void Initialize()
    {
        Choco = Resources.Load<GameObject>("choco");
        poolofChoco = new List<GameObject>(3);
        for (int i = 0; i < 3; i++)
        {
            poolofChoco.Add(GetnewChoco());
        }
    }
    public static GameObject GetChoco()
    {
        if (poolofChoco.Count > 0)
        {
            GameObject temp = poolofChoco[poolofChoco.Count - 1];
            poolofChoco.RemoveAt(poolofChoco.Count - 1);
            return temp;
        }
        else
        {
            poolofChoco.Capacity++;
            return GetnewChoco();
        }
    }
    public static void ReturnChoco(GameObject item)
    {
        item.SetActive(false);
        poolofChoco.Add(item);
    }

    public static GameObject GetnewChoco()
    {
        GameObject temp = GameObject.Instantiate(Choco);
        temp.SetActive(false);
        GameObject.DontDestroyOnLoad(temp);
        return temp;
    }
}
