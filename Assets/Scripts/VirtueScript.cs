using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtueScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if( GameManager.Instance.bomMode == true )
		{
			Vector3 bomp = GameManager.Instance.bomPos;
			GetComponent<Rigidbody>().AddForce( ( ( bomp - transform.position ).normalized ) * ( -100 ), ForceMode.Impulse );
		}
    }
}
