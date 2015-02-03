using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float moveTimer = 4.0f;
	public float distance = 1.6f;
	public float timer = 0.0f;
	public float startY;
	public float endY;
	public float currentY;
	public float distanceCovered = 0f;
	public float delay = 12f;
	public float delayTimer = 0.0f;
	public bool delayDone = false;

	// Use this for initialization
	void Start () {
		startY = this.transform.position.y;
		endY = startY + distance;
		currentY = startY;
	}
	
	// Update is called once per frame
	void Update () {
		if(delayDone){
			timer += Time.deltaTime;
			distanceCovered = timer/moveTimer;
			currentY = Hermite(startY, endY, distanceCovered);
			transform.position = new Vector3(0f, currentY, transform.position.z);
			if(timer >= moveTimer){
				startY = endY;
				endY += distance;
				timer = 0.0f;
			}
		}
		else{
			delayTimer+= Time.deltaTime;
			if(delayTimer >= delay){
				delayDone = true;
			}
		}
	}

	public static float Hermite(float start, float end, float value)
	{
		return Mathf.Lerp(start, end, value * value * (3.0f - 2.0f * value));
	}
}
