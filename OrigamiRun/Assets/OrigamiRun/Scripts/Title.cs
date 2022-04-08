using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// タイトル画面のスクリプト
public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        management.instance.HeartNum = 3;
        management.instance.ScoreSum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonDown()
    {
        SceneManager.LoadScene("MainScene1");
    }
}
