using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// �X�e�[�W���Ƃɕς��v�f��F��ȏ�����A�N�Z�X����I�u�W�F�N�g���Ǘ�
public class management : MonoBehaviour
{
    public static management instance = null;

    [System.NonSerialized] public int StageNum;
    [HeaderAttribute("�f�o�b�O���I�������NonSerialized��")] public int HeartNum;
    [System.NonSerialized] public float timer;
    [System.NonSerialized] public int ItemNum;
    [HeaderAttribute("�f�o�b�O���I�������NonSerialized��")] public int ScoreSum = 0;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
