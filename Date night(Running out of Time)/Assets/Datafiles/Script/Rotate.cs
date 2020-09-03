using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    Transform clock;
    public float force = 10f;
    public Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        clock = gameObject.transform;
        //EventManager.AddSlowMotionListener(SlowMotionListener);
        EventManager.AddGameOverListener(StopRotating);
    }

    // Update is called once per frame
    void Update()
    {
        clock.Rotate(rotate * force * Time.deltaTime);
    }
    /*
    void SlowMotionListener(float timescle)
    {
        Time.timeScale = timescle;
    }
    */
    void StopRotating()
    {
        force = 0f;
    }
}
