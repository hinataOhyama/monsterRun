using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �e�L�����N�^�[�̔ėp�I�ȑ���
public class CharacterControll : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // �ړ����x
    [SerializeField] private int jumppower;
    [SerializeField] Animator m_Animator;
    [SerializeField] Joystick Joystick;  // �o�[�`�����p�b�h�̏����ݒ�
    private Rigidbody rb; // Rigidbody�̃L���b�V��
    private Transform _transform; // Transform�̃L���b�V��
    private Ray ray;
    private bool isGrounded = false;
    // private bool ScalebuttonFlag = false;
    private bool buttonFlag = false;    // �{�^�����������Ƃ�true�A�������Ƃ�false�ɂȂ�t���O
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

        //�������牺�֌����ċ����Ray�𔭎˂��C���n���������
        //ray�Œ��S�ƕ������w��CSphereCast�ŋ��̔��a�ƁC�����΂��������w��
        ray = new Ray(gameObject.transform.position + 0.18f * gameObject.transform.up, -gameObject.transform.up);
        isGrounded = Physics.SphereCast(ray, 0.13f, 0.5f);
        //���n����͈̔͂��V�[���Ɏ���
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
        if (buttonFlag)     //�{�^���O�������Ă����̃��\�b�h���\�����Ȃ��悤�ɂ���
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

        Debug.Log("�W�����v�{�^�����N���b�N����܂���");
    }

    void OnCollisionEnter(Collision col)
    {
        transform.parent = null;
        if (transform.parent == null && col.gameObject.name == "MoveObj")
        {
            var emptyObject = new GameObject();
            emptyObject.transform.parent = col.gameObject.transform;
            transform.parent = emptyObject.transform;
            Debug.Log("MoveObj�ƃL�����N�^�[�͈ꏏ�ɓ����܂�");
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
