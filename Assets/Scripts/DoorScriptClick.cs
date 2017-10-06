using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptClick : MonoBehaviour
{
    private int flag = 0;
    RaycastHit hitInfo = new RaycastHit();
    // Use this for initialization
    void Start()
    {
        flag = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "Door1")
            {
                if (flag == 0)
                {
                    print("It's working");
                    hitInfo.transform.Rotate(0, 60, 0, Space.Self);
                    flag = 1;
                }
                else
                {
                    print("Else");
                    hitInfo.transform.Rotate(0,-60, 0, Space.Self);
                    flag = 0;
                }
            }
        }
    }
}
