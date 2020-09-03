using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    Timer returntime;
    ScoreEvent score;
    public int itemscore = 0;
    private void Start()
    {
        score = new ScoreEvent();
        returntime = gameObject.AddComponent<Timer>();
        returntime.AddTimerFinishedListener(returngameobject);
        returntime.Addtime(2);
        returntime.Run();
        EventManager.AddInvoker(this);
        EventManager.AddGameOverListener(gameoverListener);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "SNAKE")
            {
                //add unity event system for scoring
                score.Invoke(0);
            }
            else
            {
                score.Invoke(itemscore);
            }
        }
        returngameobject();
    }
    void returngameobject()
    {

        string ch = gameObject.tag;
        if (ch == "SNAKE")
        {
            PoolManager.ReturnSnake(gameObject);
        }
        else if (ch == "TSHIRT")
        {
            PoolManager.ReturnTshirt(gameObject);
        }
        else if (ch == "CHOCO")
        {
            PoolManager.ReturnChoco(gameObject);
        }
        else if (ch == "FLOWERS")
        {
            PoolManager.ReturnFlower(gameObject);
        }
    }
    public void AddScoreListener(UnityAction<int> listener)
    {
        score.AddListener(listener);

    }
    void gameoverListener()
    {
        returngameobject();
    }
}
