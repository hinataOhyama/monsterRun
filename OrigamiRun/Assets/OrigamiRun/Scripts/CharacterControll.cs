using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �e�L�����N�^�[�̔ėp�I�ȑ���
public class CharacterControll : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // �ړ����x
    [SerializeField] private int jumppower;
    [SerializeField] Joystick joystick = null;  // �o�[�`�����p�b�h�̏����ݒ�
    private Rigidbody _Rigidbody; // Rigidbody�̃L���b�V��
    private Transform _transform; // Transform�̃L���b�V��
    private Vector3 moveDirection = Vector3.zero;
    private Ray ray;
    private bool isGrounded = false;
    private bool buttonFlag = false;    // �{�^�����������Ƃ�true�A�������Ƃ�false�ɂȂ�t���O
    private int JumpCount = 0;  //�W�����v�񐔃J�E���g



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

        //�������牺�֌����ċ����Ray�𔭎˂��C���n���������
        //ray�Œ��S�ƕ������w��CSphereCast�ŋ��̔��a�ƁC�����΂��������w��
        ray = new Ray(gameObject.transform.position + 0.18f * gameObject.transform.up, -gameObject.transform.up);
        isGrounded = Physics.SphereCast(ray, 0.13f, 0.08f);
        //���n����͈̔͂��V�[���Ɏ���
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
        if (buttonFlag)     //�{�^���O�������Ă����̃��\�b�h���\�����Ȃ��悤�ɂ���
        {
            moveSpeed = moveSpeed / 2;
            buttonFlag = false;
        }
    }

    public void RabbitActionButtonClick()
    {
        if (JumpCount < 2)
        {
            // �W�����v����
            _Rigidbody.velocity = new Vector3(_Rigidbody.velocity.x, jumppower, _Rigidbody.velocity.z);
            JumpCount++;
        }
    }

    public void CraneActionButtonClick()
    {
        if (JumpCount < 1)
        {
            // �W�����v����
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
