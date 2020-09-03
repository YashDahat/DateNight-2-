using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
   static List<Item> items = new List<Item>();
    static List<UnityAction<int>> listeners = new List<UnityAction<int>>();
    static List<Score> Scores = new List<Score>();
    static List<UnityAction> GameOverListeners = new List<UnityAction>();
    static List<player> players = new List<player>();
    static List<UnityAction<float>> SlowMotionlisteners = new List<UnityAction<float>>();
    //SCORE
    public static void AddInvoker(Item i)
    {
        items.Add(i);
        foreach(UnityAction<int> listener in listeners)
        {
            i.AddScoreListener(listener);
        }
    }
    public static void AddListener(UnityAction<int> l)
    {
        listeners.Add(l);
        foreach (Item item in items)
        {
            item.AddScoreListener(l);
        }

    }
    //GAMEOVER
    public static void AddGameOverInvoker(Score i)
    {
        //items.Add(i);
        Scores.Add(i);
        foreach (UnityAction listener in GameOverListeners)
        {
            i.AddGameOverListener(listener);
        }
    }
    public static void AddGameOverListener(UnityAction l)
    {
        GameOverListeners.Add(l);
        foreach (Score score in Scores )
        {
            score.AddGameOverListener(l);
        }

    }

    //SLOWMOTION
    public static void AddSlowMotionInvoker(player p)
    {
        players.Add(p);
        foreach(UnityAction<float> listener in SlowMotionlisteners)
        {
            p.slowmotionListener(listener);
        }
    }
    public static void AddSlowMotionListener(UnityAction<float> listener)
    {
        SlowMotionlisteners.Add(listener);
        foreach (player player in players)
        {
            player.slowmotionListener(listener);
        }
    }
}
