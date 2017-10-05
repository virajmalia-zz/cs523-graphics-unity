using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public Texture texture;
    public Texture initialTex;
    public GameObject gObj;
    private int flag = 0;
    RaycastHit hitInfo = new RaycastHit();
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
  
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "Obstacle")
			{
                if (flag == 0)
                {
                    print("It's working");
                    hitInfo.rigidbody.GetComponent<Renderer>().material.SetTexture("_MainTex", texture);
                    flag = 1;
                }
                else
                {
                    print("Else block");
                    hitInfo.rigidbody.GetComponent<Renderer>().material.SetTexture("_MainTex", initialTex);
                    flag = 0;
                }
            }
		}
	}

    private void FixedUpdate()
    {
        if (flag == 1)
        {
            if (hitInfo.transform.tag == "Obstacle")
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Vector3 position = hitInfo.transform.position;
                    position.x++;
                    hitInfo.transform.position = position;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Vector3 position = hitInfo.transform.position;
                    position.x--;
                    hitInfo.transform.position = position;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Vector3 position = hitInfo.transform.position;
                    position.z--;
                    hitInfo.transform.position = position;
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Vector3 position = hitInfo.transform.position;
                    position.z++;
                    hitInfo.transform.position = position;
                }
            }
        }
    }
}
