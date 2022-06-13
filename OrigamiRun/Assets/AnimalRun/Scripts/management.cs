using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// ステージごとに変わる要素や色んな所からアクセスするオブジェクトを管理
public class management : MonoBehaviour
{
    public static management instance = null;

    [System.NonSerialized] public int StageNum;
    [HeaderAttribute("デバッグが終わったらNonSerializedに")] public int HeartNum;
    [System.NonSerialized] public float timer;
    [System.NonSerialized] public int ItemNum;
    [HeaderAttribute("デバッグが終わったらNonSerializedに")] public int ScoreSum = 0;
    

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
