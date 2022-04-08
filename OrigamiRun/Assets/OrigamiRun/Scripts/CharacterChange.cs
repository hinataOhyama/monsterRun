using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using Cinemachine;

public class CharacterChange : MonoBehaviour
{
	private int index = 0;  // �L�����N�^�[�C���f�b�N�X
	private int o_max = 0;  // �L�������擾
	GameObject[] childObject;
	public TextMeshProUGUI ActionButtonText;

	// �Ǐ]�Ώۏ��
	[Serializable]
	private struct TargetInfo
	{
		public Transform follow;    // �Ǐ]�Ώ�
		public Transform lookAt;    // �Ə������킹��Ώ�
	}

	[SerializeField] private CinemachineVirtualCamera _virtualCamera;   // �o�[�`�����J����
	[SerializeField] private TargetInfo[] _targetList;  // �Ǐ]�Ώۃ��X�g

	void Start()
	{
		o_max = this.transform.childCount;//�q�I�u�W�F�N�g�̌��擾
		childObject = new GameObject[o_max];//�C���X�^���X�쐬

		for (int i = 0; i < o_max; i++)
		{
			childObject[i] = transform.GetChild(i).gameObject;//���ׂĂ̎q�I�u�W�F�N�g�擾
		}
		//���ׂĂ̎q�I�u�W�F�N�g���A�N�e�B�u
		foreach (GameObject gamObj in childObject)
		{
			gamObj.SetActive(false);
		}
		//�ŏ��͂ЂƂ����A�N�e�B�u�����Ă���
		childObject[index].SetActive(true);
		// Dog�̂Ƃ��̓A�N�V�����e�L�X�g���_�b�V����
        if (index == 0)
        {
			ActionButtonText.text = "�_�b�V��";
        }
	}

	void Update()
	{

	}

	public void CharacterChangeButtonClick()
	{
		//���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
		childObject[index].SetActive(false);
		//���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g�̍��W���擾
		var position = childObject[index].transform.position;
		index++;

		//�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
		if (index == o_max) { index = 0; }

		// Dog�̂Ƃ��̓A�N�V�����e�L�X�g���_�b�V����
		if (index == 0)
		{
			ActionButtonText.text = "Dash";
		}
		else if (index == 1)
        {
			ActionButtonText.text = "Double Jump";
        }
		else if (index == 2)
        {
			ActionButtonText.text = "Big Jump";
        }

		//���̃I�u�W�F�N�g���A�N�e�B�u��
		childObject[index].SetActive(true);
		childObject[index].transform.position = position;
		// �Ǐ]�Ώۂ��X�V
		var info = _targetList[index];
		_virtualCamera.Follow = info.follow;
		_virtualCamera.LookAt = info.lookAt;
	}
}
