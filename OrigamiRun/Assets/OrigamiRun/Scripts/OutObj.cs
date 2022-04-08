using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutObj : MonoBehaviour
{
    [HeaderAttribute("コンティニュー地点")] public GameObject StartStage;
    public ObjManage ObjManage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 触れたらハートを減らす
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            management.instance.HeartNum--;
            // リスタート処理
            if (management.instance.HeartNum >= 1)
            {
                ObjManage.playerobj[0].transform.position = StartStage.transform.position;
                ObjManage.playerobj[1].transform.position = StartStage.transform.position;
                ObjManage.playerobj[2].transform.position = StartStage.transform.position;
            }
        }
    }
}
