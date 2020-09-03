using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    float xmax = 7f, xmin=-4, ymax=2, ymin=-3;
    Timer spawntimer;
    public float spawntime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGameOverListener(StopSpawning);
        spawntimer = gameObject.AddComponent<Timer>();
        spawntimer.AddTimerFinishedListener(ActionOnTimeOver);
        spawntimer.Addtime(spawntime);
        spawntimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    void ActionOnTimeOver()
    {
        transform.position = new Vector2(Random.Range(xmin, xmax), Random.Range(ymin, ymax));
        GameObject temp = SelectItem();
        temp.transform.position = transform.position;
        temp.SetActive(true);
        spawntimer.Addtime(spawntime);
        spawntimer.Run();
    }
    GameObject SelectItem()
    {
        int i = Random.Range(1, 10);
        switch (i)
        {
            case 1:
                return PoolManager.GetTshirt();

            case 2:
                return PoolManager.GetSnake();
               
            case 3:
                return PoolManager.GetFlower();
               
            case 4:
                return PoolManager.GetChoco();

            case 5:
                return PoolManager.GetSnake();

            case 6:
                return PoolManager.GetFlower();

            case 7:
                return PoolManager.GetFlower();

            case 8:
                return PoolManager.GetTshirt();

            case 9:
                return PoolManager.GetTshirt();

            case 10:
                return PoolManager.GetChoco();
                
            default: return null;

        }
    }
    void StopSpawning()
    {
        gameObject.SetActive(false);
    }
}
