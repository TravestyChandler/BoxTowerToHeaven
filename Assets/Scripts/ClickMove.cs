using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {
	public GameObject selectedBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit hit;
		if(Input.GetKeyDown (KeyCode.Mouse0)){
			if(Physics.Raycast(ray, out hit, 20f)){
				print("hit");
				if(hit.collider.tag == "Box"){
					selectedBox = hit.collider.gameObject;
				//	selectedBox.AddComponent<Rigidbody>();
				//	selectedBox.rigidbody.useGravity = false;
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.Mouse0)){
			if(Physics.Raycast(ray, out hit, 20f)){
				print ("let go");
				if(hit.collider.tag == "Box"){
					//Destroy(selectedBox.gameObject.GetComponent<Rigidbody>());
					selectedBox = null;
				}
			}
		}
		if(selectedBox != null){

			selectedBox.transform.position = mousePos;
		}
	}

}
