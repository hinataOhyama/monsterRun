using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 各キャラクターの汎用的な操作
public class CharacterControll : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // 移動速度
    [SerializeField] private int jumppower;
    [SerializeField] Joystick joystick = null;  // バーチャルパッドの初期設定
    private Rigidbody _Rigidbody; // Rigidbodyのキャッシュ
    private Transform _transform; // Transformのキャッシュ
    private Vector3 moveDirection = Vector3.zero;
    private Ray ray;
    private bool isGrounded = false;
    private bool buttonFlag = false;    // ボタンを押したときtrue、離したときfalseになるフラグ
    private int JumpCount = 0;  //ジャンプ回数カウント



    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = joystick.Direction;
        moveDirection.x = joystick.Horizontal;
        moveDirection.z = joystick.Vertical;

        if (Input.touchCount > 0)
        {
            moveDirection.x = joystick.Horizontal;
            moveDirection.z = joystick.Vertical;
        }

        //足元から下へ向けて球状のRayを発射し，着地判定をする
        //rayで中心と方向を指定，SphereCastで球の半径と，球を飛ばす距離を指定
        ray = new Ray(gameObject.transform.position + 0.18f * gameObject.transform.up, -gameObject.transform.up);
        isGrounded = Physics.SphereCast(ray, 0.13f, 0.08f);
        //着地判定の範囲をシーンに示す
        Debug.DrawRay(gameObject.transform.position + 0.2f * gameObject.transform.up, -0.22f * gameObject.transform.up);

        if (isGrounded)
        {
            if (moveDirection.x != 0 || moveDirection.z != 0)
            {
                moveDirection = moveSpeed * new Vector3(moveDirection.x, 0, moveDirection.z);
                moveDirection = transform.TransformDirection(moveDirection);
                _Rigidbody.velocity = moveDirection;
            }
        }
    }

    public void DogActionButtonDown()
    {
        moveSpeed = moveSpeed * 2;
        buttonFlag = true;
    }
    public void DogActionButtonUp()
    {
        if (buttonFlag)     //ボタン外を押してもこのメソッドが暴発しないようにする
        {
            moveSpeed = moveSpeed / 2;
            buttonFlag = false;
        }
    }

    public void RabbitActionButtonClick()
    {
        if (JumpCount < 2)
        {
            // ジャンプ処理
            _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, jumppower, _Rigidbody.velocity.z);
            JumpCount++;
        }
    }

    public void CraneActionButtonClick()
    {
        if (JumpCount < 1)
        {
            // ジャンプ処理
            _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, jumppower, _Rigidbody.velocity.z);
            JumpCount++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            JumpCount = 0;
        }
    }

}
