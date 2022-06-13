using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public static bool goal;

    void Start()
    {
        goal = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            int score = (/*Itimer * 3 + */management.instance.HeartNum * 100 + management.instance.ItemNum * 100);
            management.instance.ScoreSum += score;
            goal = true;
            Debug.Log("ƒS[ƒ‹ƒgƒŠƒK[‚ªtrue‚É‚È‚è‚Ü‚µ‚½");
        }
    }
}
