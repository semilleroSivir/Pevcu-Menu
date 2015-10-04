using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class travel_Log : MonoBehaviour {

	// Use this for initialization
	public GameObject btn_travel;
	void Start () {
		Button button = btn_travel.GetComponent<Button>();
		button.interactable = true;
		button.onClick.AddListener(delegate {LoadStage();});
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LoadStage()  {
		Debug.Log ("test");
		//Application.LoadLevel ("YourLevel");
	}

}
