using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// プレイヤーを検知して追尾するエネミー・触れたらコンティニュー地点に返す。
public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask; // レイヤーマスク
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];

    [HeaderAttribute("コンティニュー地点")] public GameObject StartStage;
    public ObjManage ObjManage;

    // プレイヤーを検知して追尾するエネミー
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); // NavMeshAgentを保持しておく
    }

    // CollisionDetectorのonTriggerStayにセットし、衝突判定を受け取るメソッド
    public void OnDetectObject(Collider collider)
    {
        // 検知したオブジェクトに「Player」のタグがついていれば、そのオブジェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            _agent.destination = collider.transform.position;
        }
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
            }
        }
    }
}
