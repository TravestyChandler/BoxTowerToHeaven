using UnityEngine;
using System.Collections;

public class PlayBoxBulder : MonoBehaviour {
	public Animator anim;
	public GameObject box;
	public float animTimer = 0.0f;
	public float animEnd = 4.0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animTimer += Time.deltaTime;
		if(animTimer >= animEnd){
			Instantiate(box, transform.position, Quaternion.identity);
			this.transform.position = new Vector2(transform.position.x, transform.position.y + 1.6f);
			animTimer = 0.0f;
		}

	}
}
