using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ahanp : MonoBehaviour
{
	[SerializeField] GameObject ah;
    // Update is called once per frame
    void Update()
    {
		ah.transform.position = transform.forward;
    }
}
