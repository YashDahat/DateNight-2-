using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    public float force,timescale = 0.5f,orgforce;
    Vector2 move;
    Rigidbody2D rb;
    SlowMotionEvent slowMotion = new SlowMotionEvent();
    Timer slowmotiontimer, Activateslowmotiontimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
       
        slowmotiontimer = gameObject.AddComponent<Timer>();
        Activateslowmotiontimer = gameObject.AddComponent<Timer>();
        EventManager.AddGameOverListener(GameOverListener);
        EventManager.AddSlowMotionInvoker(this);
        slowmotiontimer.AddTimerFinishedListener(SlowMotionFinishedListener);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical")!=0f)
        {
            move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move = move.normalized;
            rb.velocity = move*force*Time.deltaTime;
        }
   
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        //rb.velocity = new Vector2(0, 0);

        // invoke slow motion
        if(Input.GetKeyDown("space"))
        {
            if(!Activateslowmotiontimer.Running)
            {
                slowMotion.Invoke(timescale);
                orgforce = force;
                force = 5*orgforce;
                slowmotiontimer.Addtime(2f);
                slowmotiontimer.Run();
                
            }
          
        }
    }
    void GameOverListener()
    {
        gameObject.SetActive(false);
    }
    public void slowmotionListener(UnityAction<float> listener)
    {
        slowMotion.AddListener(listener);
    }
    void SlowMotionFinishedListener()
    {
        slowMotion.Invoke(1);
        force = orgforce;
        Activateslowmotiontimer.Addtime(10f);
        Activateslowmotiontimer.Run();
    }
}
