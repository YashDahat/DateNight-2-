using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    public static void Initiallize()
    {
        TShirtPool.Initialize();
        SnakePool.Initialize();
        FlowersPool.Initialize();
        ChocoPool.Initialize();
    }
    public static GameObject GetTshirt()
    {
        return TShirtPool.GetTshirt();
    }
    public static void ReturnTshirt(GameObject tshirt)
    {
        TShirtPool.ReturnTshirt(tshirt);
    }
    public static GameObject GetSnake()
    {
        return SnakePool.GetSnake();
    }
    public static void ReturnSnake(GameObject snake)
    {
        SnakePool.ReturnSnake(snake);
    }
    public static GameObject GetFlower()
    {
        return FlowersPool.GetFlower();
    }
    public static void ReturnFlower(GameObject flower)
    {
        FlowersPool.ReturnFlower(flower);
    }
    public static GameObject GetChoco()
    {
        return ChocoPool.GetChoco();
    }
    public static void ReturnChoco(GameObject choco)
    {
        ChocoPool.ReturnChoco(choco);
    }
}
