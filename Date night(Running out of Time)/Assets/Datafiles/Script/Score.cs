using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText,gametimertext,requiredscoretext;
    public GameObject lose, win;
    int score,reqscore,giventime;
    bool state;
    
    Timer gametimer;
    GameOverEvent gameOver = new GameOverEvent();
    private void Start()
    {
        gametimer = gameObject.AddComponent<Timer>();
        giventime = TimeGiven();
        reqscore = 2*giventime;
        state = false;

        gametimer.Addtime(giventime);
        gametimer.Run();
        EventManager.AddGameOverInvoker(this);
        EventManager.AddListener(ScoreListener);
        scoreText.text = "0";
        requiredscoretext.text = "REQIURED SCORE : " + reqscore.ToString();
        gametimertext.text = gametimer.SecondsLeft.ToString("0.");
    }
    public void Update()
    {
       
        if (!gametimer.Running)
        {
            gametimertext.text = " ";
        }
        else
        {
            gametimertext.text = gametimer.SecondsLeft.ToString("0.");
        }
        //Player won or lose
      
        if (reqscore <= score && gametimer.Running)
        {
            win.SetActive(true);
            gameOver.Invoke();
            Time.timeScale = 1;
            gametimer.Stop();
            state = true;
        }
        else if (!gametimer.Running && !state)
        {
            lose.SetActive(true);
            gameOver.Invoke();
            Time.timeScale = 1;
            gametimer.Stop();
        }
      
    }
    public void ScoreListener(int s)
    {
        if (s == 0)
        {
            //end the game
            gameOver.Invoke();
            //lose.enabled = true;
            lose.SetActive(true);
            gametimer.Stop();
            //gametimertext.text = " ";
        }
        else
        {
            //increment the score
            score += s;
            scoreText.text = score.ToString();
        }
       
    }
    public void AddGameOverListener(UnityAction listener)
    {
        gameOver.AddListener(listener);
    }
    public void Restartthegame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public int TimeGiven()
    {
        int ch = Random.Range(1, 6);
        switch (ch)
        {
            case 1: return 10;
                
            case 2: return 20;

            case 3: return 30;

            case 4: return 40;

            case 5: return 50;

            case 6: return 60;

            default: return 0;
        }
    }
}
