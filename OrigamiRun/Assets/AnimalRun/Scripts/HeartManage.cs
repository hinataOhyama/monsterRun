using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManage : MonoBehaviour
{
    public static HeartManage instanced = null;

    [HeaderAttribute("デバッグ以外でいじらない")] public int HeartNum;


    private void Awake()
    {
        if (instanced == null)
        {
            instanced = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
