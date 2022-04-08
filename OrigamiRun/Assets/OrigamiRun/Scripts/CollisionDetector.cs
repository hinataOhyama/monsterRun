using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }

    /// <summary>
    /// Is Trigger��ON�ő���Collider�Əd�Ȃ��Ă���Ƃ��́A���̃��\�b�h����ɃR�[�������
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        // onTriggerStay�Ŏw�肳�ꂽ���������s����
        onTriggerStay.Invoke(other);
    }

    // UnityEvent���p�������N���X��[Serializable]������t�^���邱�ƂŁAInspector�E�C���h�E��ɕ\���ł���悤�ɂȂ�B
    [Serializable]
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
}
