using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アイテム処理
public class Items : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")   // 触れたオブジェクトのタグがPlayerだったら
        {
            this.gameObject.SetActive(false);  // Itemを非表示にする
            management.instance.ItemNum++;                                // 取得アイテム数＋１
        }
    }
}
