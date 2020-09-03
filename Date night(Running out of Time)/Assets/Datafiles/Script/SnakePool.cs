using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SnakePool 
{
    static GameObject Snake;
    static List<GameObject> poolofsnake;
    public static void Initialize()
    {
        Snake = Resources.Load<GameObject>("Snake");
        poolofsnake = new List<GameObject>(3);
        for (int i = 0; i < 3; i++)
        {
            poolofsnake.Add(GetnewSnake());
        }
    }
    public static GameObject GetSnake()
    {
        if (poolofsnake.Count > 0)
        {
            GameObject temp = poolofsnake[poolofsnake.Count - 1];
            poolofsnake.RemoveAt(poolofsnake.Count - 1);
            return temp;
        }
        else
        {
            poolofsnake.Capacity++;
            return GetnewSnake();
        }
    }
    public static void ReturnSnake(GameObject item)
    {
        item.SetActive(false);
        poolofsnake.Add(item);
    }

    public static GameObject GetnewSnake()
    {
        GameObject temp = GameObject.Instantiate(Snake);
        temp.SetActive(false);
        GameObject.DontDestroyOnLoad(temp);
        return temp;
    }
}
