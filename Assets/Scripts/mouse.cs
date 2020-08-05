using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if( GameManager.Instance.nowMode == GameManager.GameMode.BuildVirtue )
		{
			Build_Virtue();
		} else if( GameManager.Instance.nowMode == GameManager.GameMode.Throw )
		{
			Virtue_Throw();
		}
    }

	//Buildvirtue mode process
	void Build_Virtue()
	{

	}

	//virtuethrow mode process
	void Virtue_Throw()
	{

	}
}
