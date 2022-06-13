using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 各キャラクターの汎用的な操作
public class CharacterControll : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // 移動速度
    [SerializeField] private int jumppower;
    [SerializeField] Animator m_Animator;
    [SerializeField] Joystick Joystick;  // バーチャルパッドの初期設定
    private Rigidbody rb; // Rigidbodyのキャッシュ
    private Transform _transform; // Transformのキャッシュ
    private Ray ray;
    private bool isGrounded = false;
    // private bool ScalebuttonFlag = false;
    private bool buttonFlag = false;    // ボタンを押したときtrue、離したときfalseになるフラグ
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != new Vector3(0, 0, 0))
        {
            _transform.LookAt(_transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z));
        }
        m_Animator.SetFloat("isMoving", Mathf.Max(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.z)));

        //足元から下へ向けて球状のRayを発射し，着地判定をする
        //rayで中心と方向を指定，SphereCastで球の半径と，球を飛ばす距離を指定
        ray = new Ray(gameObject.transform.position + 0.18f * gameObject.transform.up, -gameObject.transform.up);
        isGrounded = Physics.SphereCast(ray, 0.13f, 0.5f);
        //着地判定の範囲をシーンに示す
        Debug.DrawRay(gameObject.transform.position + 0.2f * gameObject.transform.up, -0.22f * gameObject.transform.up, Color.red);

        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        rb.AddForce(direction * moveSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    public void FixedUpdate()
    {
    }

    public void DashButtonDown()
    {
        Arrow.SetActive(false);
        moveSpeed = moveSpeed * 2;
        buttonFlag = true;
    }
    public void DashButtonUp()
    {
        if (buttonFlag)     //ボタン外を押してもこのメソッドが暴発しないようにする
        {
            moveSpeed = moveSpeed / 2;
            buttonFlag = false;
        }
    }

    public void JumpButtonClick()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumppower, rb.velocity.z);
        }

        Debug.Log("ジャンプボタンがクリックされました");
    }

    void OnCollisionEnter(Collision col)
    {
        transform.parent = null;
        if (transform.parent == null && col.gameObject.name == "MoveObj")
        {
            var emptyObject = new GameObject();
            emptyObject.transform.parent = col.gameObject.transform;
            transform.parent = emptyObject.transform;
            Debug.Log("MoveObjとキャラクターは一緒に動きます");
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (transform.parent != null && col.gameObject.name == "MoveObj")
        {
            transform.parent = null;
        }
    }
}
