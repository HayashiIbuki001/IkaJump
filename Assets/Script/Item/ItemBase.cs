using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetItem();
        GICustom();
    }

    /// <summary>
    /// �A�C�e������������ɕK��������
    /// </summary>
    public void GetItem()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// �A�C�e�����ƂɌʂɓ�����
    /// </summary>
    public virtual void GICustom()
    {
        
    }
}
