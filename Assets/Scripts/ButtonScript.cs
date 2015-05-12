using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	private bool isPause = false;
	
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPause = !isPause;
			if(isPause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
		}
	}

	void OnGUI(){
		if (GameManager.currentLevel == 0) {
			if (GUI.Button (new Rect ((Screen.width / 2 - 150), (Screen.height / 3 - 50), 300, 75), "START GAME")) {
				GameManager.CompleteLevel ();
			}
			if (GUI.Button (new Rect ((Screen.width / 2 - 150), (Screen.height / 3 + 150), 300, 75), "QUIT")) {
				Application.Quit ();
			}
		} else if (isPause){
			if (GUI.Button (new Rect ((Screen.width / 2 - 150), (Screen.height / 2 - 40), 300, 75), "EXIT TO TITLE")) {
				Application.LoadLevel("Level 0 Title");
				GameManager.currentLevel = 0;
				isPause = false;
				Time.timeScale = 1;
			}
		}
	}
}