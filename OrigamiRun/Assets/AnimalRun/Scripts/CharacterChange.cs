using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CharacterChange : MonoBehaviour
{
	private int index = 0;  // �L�����N�^�[�C���f�b�N�X
	private int o_max = 0;  // �L�������擾
	GameObject[] childObject;
	public GameObject DashButton;
	public GameObject JumpButton;
	public GameObject Arrow;

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
	}

	void Update()
	{
	}

	public void CharacterChangeButtonClick()
	{
		Arrow.SetActive(false);
		//���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g���A�N�e�B�u
		childObject[index].SetActive(false);
		//���݂̃A�N�e�B�u�Ȏq�I�u�W�F�N�g�̍��W���擾
		var position = childObject[index].transform.position;
		index++;

		//�q�I�u�W�F�N�g�����ׂĐ؂�ւ�����܂��ŏ��̃I�u�W�F�N�g�ɖ߂�
		if (index == o_max) { index = 0; }

		// �L�������ς��ƃ{�^�����ς��
		if (index == 0)					// Dash
		{
			DashButton.SetActive(true);
			JumpButton.SetActive(false);
		}
		else if (index == 1)			// Jump
        {
			DashButton.SetActive(false);
			JumpButton.SetActive(true);
		}

		//���̃I�u�W�F�N�g���A�N�e�B�u��
		childObject[index].SetActive(true);
		childObject[index].transform.position = position;
		// �Ǐ]�Ώۂ��X�V
		var info = _targetList[index];
		_virtualCamera.Follow = info.follow;
		_virtualCamera.LookAt = info.lookAt;

		Debug.Log("�L�����`�F���W�{�^�����N���b�N����܂����B");
	}
}
