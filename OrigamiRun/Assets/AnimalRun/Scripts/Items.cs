using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �A�C�e������
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
        if (collider.gameObject.tag == "Player")   // �G�ꂽ�I�u�W�F�N�g�̃^�O��Player��������
        {
            this.gameObject.SetActive(false);  // Item���\���ɂ���
            management.instance.ItemNum++;                                // �擾�A�C�e�����{�P
        }
    }
}
