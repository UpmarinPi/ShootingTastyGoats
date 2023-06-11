using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class StartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(ConstClass.startkey))
        {
            this.gameObject.SetActive(false);
        }
    }
}
