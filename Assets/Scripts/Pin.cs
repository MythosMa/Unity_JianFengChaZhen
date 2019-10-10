using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float speed = 20f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.up * speed ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Rotator") {
			rb.velocity = Vector2.zero ;
			transform.SetParent(other.transform);
			Score.scoreValue++ ;
			if (Random.Range(0f, 1f) > 0.5f) {
				other.GetComponent<Rotation>().speed *= -1 ;
			}
		}else if(other.tag == "Pin") {
			GameObject.FindObjectOfType<GameManager>().GameOver();
			Debug.Log("GameOver : " + other.name);
		}
	}
}
