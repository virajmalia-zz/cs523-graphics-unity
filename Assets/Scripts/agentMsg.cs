using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentMsg : MonoBehaviour {

	private List<GameObject> selectedUnit = new List<GameObject>();
	private List<Renderer> rend = new List<Renderer>();

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if(Physics.Raycast(ray, out hit)){
			if (hit.transform.tag == "Player" && Input.GetMouseButtonDown(0)){
				selectedUnit.Add(hit.transform.gameObject);		// Add selected players to list
				// Change color of each selected player
				foreach( GameObject obj in selectedUnit ){
					rend.Add(obj.GetComponent<Renderer> ());
					foreach (Renderer r in rend) {
						r.material.color = Color.cyan;
					}
					obj.SendMessage("Select", 1);
				}
			}

			if (hit.transform.tag == "Ground" && Input.GetMouseButtonDown(2)){
				// Destination for every selected object
				foreach( GameObject obj in selectedUnit){
					obj.SendMessage("Destination", hit.point);
				}
			}

			if (hit.transform.tag == "Ground" && Input.GetMouseButtonDown(0)){
				// Deselect and change back color
				foreach( GameObject obj in selectedUnit ){
					foreach (Renderer r in rend) {
						r.material.color = Color.white;
					}
					obj.SendMessage("Deselect", 1);
				}
				selectedUnit.Clear();
				rend.Clear();
			}
		}
	}
}