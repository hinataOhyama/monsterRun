using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutObj : MonoBehaviour
{
    [HeaderAttribute("�R���e�B�j���[�n�_")] public GameObject StartStage;
    public ObjManage ObjManage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // �G�ꂽ��n�[�g�����炷
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
    }
}
