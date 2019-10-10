using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool isGameOver = false ;

	public Spawner spawner ;
	public Rotation rotator ;

	float devHeight = 19.2f;
	float devWidth = 10.8f;

	// Use this for initialization
	void Start () {
		float screenHeight = Screen.height ;
		float orthographicSize = this.GetComponent<Camera>().orthographicSize;

		float aspectRatio = Screen.width * 1.0f / Screen.height ;

		float cameraWidth = orthographicSize * 2 * aspectRatio ;

		if(cameraWidth < devWidth) {
			orthographicSize = devWidth / (2 * aspectRatio) ;
			this.GetComponent<Camera>().orthographicSize = orthographicSize ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void GameOver() {

		if(!isGameOver) {
			isGameOver = true ;
			spawner.enabled = false ;
			rotator.enabled = false ;

			GetComponent<Animator>().SetTrigger("GameOver");
		}
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
