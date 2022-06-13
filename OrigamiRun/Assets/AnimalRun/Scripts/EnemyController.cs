using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// �v���C���[�����m���Ēǔ�����G�l�~�[�E�G�ꂽ��R���e�B�j���[�n�_�ɕԂ��B
public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask; // ���C���[�}�X�N
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    [HeaderAttribute("�R���e�B�j���[�n�_")] public GameObject StartStage;
    public ObjManage ObjManage;

    // �v���C���[�����m���Ēǔ�����G�l�~�[
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // NavMeshAgent��ێ����Ă���
    }

    // CollisionDetector��onTriggerStay�ɃZ�b�g���A�Փ˔�����󂯎�郁�\�b�h
    public void OnDetectObject(Collider collider)
    {
        // ���m�����I�u�W�F�N�g�ɁuPlayer�v�̃^�O�����Ă���΁A���̃I�u�W�F�N�g��ǂ�������
        if (collider.CompareTag("Player"))
        {
            _agent.destination = collider.transform.position;
        }
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
            }
        }
    }
}
