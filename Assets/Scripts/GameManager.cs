using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	public enum GameMode
	{
		BuildVirtue = 0,
		Bomber,
		Throw
	}

	//bring Gamemode String
	string[] gameModeStr = new string[ 3 ];

	//get gameModeStr each GameMode if other script want
	[SerializeField] Text viewText = null;

	//Gamemode Value
	public GameMode nowMode { set; get; } = GameMode.BuildVirtue;

	//Bomber
	public bool bomMode { set; get; } = false;
	//Bom occurrence position
	public Vector3 bomPos {	set; get; } = Vector3.zero;

	[SerializeField] GameObject[] virtueObject = new GameObject[ 3 ];

	private void Start()
	{
		gameModeStr[ 0 ] = "徳積み";
		gameModeStr[ 1 ] = "徳爆破";
		gameModeStr[ 2 ] = "徳投げ";
		viewText.text = gameModeStr[ ( int )nowMode ];
	}

	// Update is called once per frame
	void Update()
    {
		//Mode Change Process
		ChangeMode();

		//Execute function while each mode
		ModeSelect();
	}

	//Change Gamemode if push space
	void ChangeMode()
	{
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			nowMode++;
			if( System.Enum.GetValues( typeof( GameMode ) ).Length - 1 < ( int )nowMode )
			{
				nowMode = GameMode.BuildVirtue;
			}
			viewText.text = gameModeStr[ ( int )nowMode ];
		}
	}

	//Mode Selector( Execute each Process )
	void ModeSelect()
	{
		if( GameManager.Instance.nowMode == GameManager.GameMode.BuildVirtue )
		{
			Virtue_Build();
			print( "build" );
		}
		else if( GameManager.Instance.nowMode == GameManager.GameMode.Bomber )
		{
			Virtue_Bomber();
			print( "bomb" );
		}
		else if( GameManager.Instance.nowMode == GameManager.GameMode.Throw )
		{
			Virtue_Throw();
			print( "throw" );
		}
	}

	//Accumlate virtues mode Process
	void Virtue_Build()
	{
		if( ( Input.GetKey( KeyCode.A ) && Input.GetMouseButton( 0 ) ) || Input.GetMouseButtonDown( 0 ) )
		{
			int random = Random.Range( 0, 3 );
			Vector3 mousePos = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 25f );
			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint( mousePos );
			GameObject ahan = Instantiate( virtueObject[ random ], worldMousePos, Quaternion.Euler( 0f, 180f, 0f ) );
		}
	}

	//Appearance Virtue object position
	void Virtue_Position()
	{

	}

	//Add force while virtue object of near click position
	void Virtue_Bomber()
	{
		if( Input.GetMouseButtonDown( 0 ) )
		{
			bomMode = true;
			Vector3 mousePos = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 25f );
			bomPos = Camera.main.ScreenToWorldPoint( mousePos );
			StartCoroutine( "BombProcess" );
		}
	}

	//Throw Virtue mode process
	void Virtue_Throw()
	{

	}

	//
	IEnumerator BombProcess()
	{
		yield return new WaitForEndOfFrame();
		bomMode = false;
		print( "ahan" );
	}
}
