using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// 各ステージのタイマーとアイテムの初期設定・タイマー処理・タイムオーバー処理・各UIの表示・各リザルトUIの表示
public class UImanagement : MonoBehaviour
{
    // [SerializeField] private float ResetTimer;
    [SerializeField] private int ResetItemNum;
    [SerializeField] private int ResetStageNum;
    public TextMeshProUGUI StageNumText;
    public TextMeshProUGUI HeartNumText;
    // public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ItemNumText;
    public TextMeshProUGUI ReStageNumText;
    public TextMeshProUGUI ReScoreText;
    public TextMeshProUGUI ReBestScoreText;
    public TextMeshProUGUI ScoreSumText;
    public ObjManage ObjManage;
    private int bestScore1;
    private int bestScore2;
    private int bestScore3;
    private int bestScore4;
    private int bestScore5;
    private IEnumerator countdown;
    private float count = 120f;

    // Start is called before the first frame update
    void Start()
    {
        // 各ステージのタイマーとアイテムの初期設定
        management.instance.StageNum = ResetStageNum;
        // management.instance.timer = ResetTimer;
        management.instance.ItemNum = ResetItemNum;

        // ベストスコアの初期設定
        if (SceneManager.GetActiveScene().name == "MainScene1")
        {
            if (PlayerPrefs.HasKey("BestScore1"))
            {
                bestScore1 = PlayerPrefs.GetInt("BestScore1");
            }
            else
            {
                bestScore1 = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene2")
        {
            if (PlayerPrefs.HasKey("BestScore2"))
            {
                bestScore2 = PlayerPrefs.GetInt("BestScore2");
            }
            else
            {
                bestScore2 = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene3")
        {
            if (PlayerPrefs.HasKey("BestScore3"))
            {
                bestScore3 = PlayerPrefs.GetInt("BestScore3");
            }
            else
            {
                bestScore3 = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene4")
        {
            if (PlayerPrefs.HasKey("BestScore4"))
            {
                bestScore4 = PlayerPrefs.GetInt("BestScore4");
            }
            else
            {
                bestScore4 = 0;
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene5")
        {
            if (PlayerPrefs.HasKey("BestScore5"))
            {
                bestScore5 = PlayerPrefs.GetInt("BestScore5");
            }
            else
            {
                bestScore5 = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //// タイマー処理
        //if (GoalTrigger.goal == false)
        //{
        //    management.instance.timer -= Time.deltaTime;
        //}
        //int Itimer = Mathf.FloorToInt(management.instance.timer);
        //// タイムオーバー処理
        //if (management.instance.timer <= 0)
        //{
        //    ObjManage.CloseGoal.SetActive(false);
        //    ObjManage.FinishUI.SetActive(false);
        //    ObjManage.GameOver.SetActive(true);

        //    countdown = Countdown();
        //    StartCoroutine(countdown);
        //    StopCoroutine(countdown);
        //}

        // 各UIの表示
        StageNumText.text = "Stage " + ResetStageNum.ToString();
        HeartNumText.text = " × " + management.instance.HeartNum.ToString();
        // TimerText.text = Itimer.ToString();
        ItemNumText.text = management.instance.ItemNum.ToString() + " / 3";

        // 各リザルトUIの表示
        //   ステージクリア！
        ReStageNumText.text = "Stage " + ResetStageNum.ToString() + " Beating!";
        //   スコア：
        int score = (/*Itimer * 3*/ + management.instance.HeartNum * 100 + management.instance.ItemNum * 100);
        ReScoreText.text = "Score : " + score.ToString();
        //   通算スコア
        management.instance.ScoreSum += score;
        ScoreSumText.text = "Total Score：" + management.instance.ScoreSum.ToString();
        //   ベストスコア：
        if (SceneManager.GetActiveScene().name == "MainScene1")
        {
            ReBestScoreText.text = "Best Score : " + bestScore1;
            if (bestScore1 < score)
            {
                PlayerPrefs.SetInt("BestScore1", score);
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene2")
        {
            ReBestScoreText.text = "Best Score : " + bestScore2;
            if (bestScore2 < score)
            {
                PlayerPrefs.SetInt("BestScore2", score);
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene3")
        {
            ReBestScoreText.text = "Best Score : " + bestScore3;
            if (bestScore3 < score)
            {
                PlayerPrefs.SetInt("BestScore3", score);
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene4")
        {
            ReBestScoreText.text = "Best Score : " + bestScore4;
            if (bestScore4 < score)
            {
                PlayerPrefs.SetInt("BestScore4", score);
            }
        }
        if (SceneManager.GetActiveScene().name == "MainScene5")
        {
            ReBestScoreText.text = "Best Score : " + bestScore5;
            if (bestScore5 < score)
            {
                PlayerPrefs.SetInt("BestScore5", score);
            }
        }
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            if (count > 0)
            {
                count--;                           // 毎秒減らす
            }
            else
            {
                SceneManager.LoadScene("TitleScene");
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
