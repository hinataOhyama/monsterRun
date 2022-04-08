using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ��O�����E�Q�[���I�[�o�[�����E���X�^�[�g�����E�X�e�[�W�N���A����
public class Stage : MonoBehaviour
{
    [HeaderAttribute("�R���e�B�j���[�n�_")]public GameObject StartStage;
    public ObjManage ObjManage;
    private IEnumerator countdown;
    private float count = 120f;
    private float OutLine = -10;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ��O����(�n�[�g�����炷)
        if (ObjManage.playerobj[0].transform.position.y < OutLine ||
           ObjManage.playerobj[1].transform.position.y < OutLine ||
           ObjManage.playerobj[2].transform.position.y < OutLine)
        {
            management.instance.HeartNum--;
            // ���X�^�[�g����
            if (management.instance.HeartNum >= 1)
            {
                ObjManage.playerobj[0].transform.position = StartStage.transform.position;
                ObjManage.playerobj[1].transform.position = StartStage.transform.position;
                ObjManage.playerobj[2].transform.position = StartStage.transform.position;
            }
        }

        // �Q�[���I�[�o�[����
        if (management.instance.HeartNum <= 0)
        {
            ObjManage.CloseGoal.SetActive(false);
            ObjManage.FinishUI.SetActive(false);
            ObjManage.GameOver.SetActive(true);

            countdown = Countdown();
            StartCoroutine(countdown);
            StopCoroutine(countdown);
        }

        // �X�e�[�W�N���A����
        if (GoalTrigger.goal == true)
        {
            ObjManage.LightOff.SetActive(false);
            ObjManage.FinishUI.SetActive(false);
            ObjManage.StageClear.SetActive(true);

            countdown = Countdown();
            StartCoroutine(countdown);
            StopCoroutine(countdown);
        }

    }
    private IEnumerator Countdown()
    {
        while (true)
        {
            if (count > 0)
            {
                count--;                           // ���b���炷
            }
            else if (management.instance.HeartNum <= 0)
            {
                SceneManager.LoadScene("TitleScene");
            }
            else if (management.instance.StageNum == 1) 
            {
                SceneManager.LoadScene("MainScene2");
            }
            else if (management.instance.StageNum == 2)
            {
                SceneManager.LoadScene("MainScene3");
            }
            else if (management.instance.StageNum == 3)
            {
                SceneManager.LoadScene("MainScene4");
            }
            else if (management.instance.StageNum == 4)
            {
                SceneManager.LoadScene("MainScene5");
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
