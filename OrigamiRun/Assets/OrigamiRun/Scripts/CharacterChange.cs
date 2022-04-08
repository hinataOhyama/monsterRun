using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using Cinemachine;

public class CharacterChange : MonoBehaviour
{
	private int index = 0;  // キャラクターインデックス
	private int o_max = 0;  // キャラ数取得
	GameObject[] childObject;
	public TextMeshProUGUI ActionButtonText;

	// 追従対象情報
	[Serializable]
	private struct TargetInfo
	{
		public Transform follow;    // 追従対象
		public Transform lookAt;    // 照準を合わせる対象
	}

	[SerializeField] private CinemachineVirtualCamera _virtualCamera;   // バーチャルカメラ
	[SerializeField] private TargetInfo[] _targetList;  // 追従対象リスト

	void Start()
	{
		o_max = this.transform.childCount;//子オブジェクトの個数取得
		childObject = new GameObject[o_max];//インスタンス作成

		for (int i = 0; i < o_max; i++)
		{
			childObject[i] = transform.GetChild(i).gameObject;//すべての子オブジェクト取得
		}
		//すべての子オブジェクトを非アクティブ
		foreach (GameObject gamObj in childObject)
		{
			gamObj.SetActive(false);
		}
		//最初はひとつだけアクティブ化しておく
		childObject[index].SetActive(true);
		// Dogのときはアクションテキストをダッシュに
        if (index == 0)
        {
			ActionButtonText.text = "ダッシュ";
        }
	}

	void Update()
	{

	}

	public void CharacterChangeButtonClick()
	{
		//現在のアクティブな子オブジェクトを非アクティブ
		childObject[index].SetActive(false);
		//現在のアクティブな子オブジェクトの座標を取得
		var position = childObject[index].transform.position;
		index++;

		//子オブジェクトをすべて切り替えたらまた最初のオブジェクトに戻る
		if (index == o_max) { index = 0; }

		// Dogのときはアクションテキストをダッシュに
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

		//次のオブジェクトをアクティブ化
		childObject[index].SetActive(true);
		childObject[index].transform.position = position;
		// 追従対象を更新
		var info = _targetList[index];
		_virtualCamera.Follow = info.follow;
		_virtualCamera.LookAt = info.lookAt;
	}
}
