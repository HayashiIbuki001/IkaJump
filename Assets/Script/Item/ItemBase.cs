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
    /// アイテムを取った時に必ず動かす
    /// </summary>
    public void GetItem()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// アイテムごとに個別に動かす
    /// </summary>
    public virtual void GICustom()
    {
        
    }
}
