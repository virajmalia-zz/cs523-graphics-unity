using System;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour {

    #region Enums

    public enum TOGGLE_MODE : int {
        TARGET_CAMERA = KeyCode.F1
    }

    public enum KEYBOARD_INPUT : int {
        SPEED_MODIFIER = KeyCode.LeftShift,
        SPACE_MODIFIER = KeyCode.F2,
        FORWARD = KeyCode.W,
        BACKWARDS = KeyCode.S,
        LEFT_STRAFE = KeyCode.A,
        RIGHT_STRAFE = KeyCode.D,
        LEFT_ROTATE = KeyCode.Q,
        RIGHT_ROTATE = KeyCode.E,
        VERT_POS = KeyCode.R,
        VERT_NEG = KeyCode.F
    }

    public enum MOUSE_INPUT : int {
		PITCH_MOUSE = KeyCode.Mouse1,
		YAW_MOUSE = KeyCode.Mouse1
    }

    #endregion

    #region Members

    [Range(1f, 20f)] public float ObjectRotationSpeed = 5f;
    [Range(1f, 20f)] public float CameraRotationThreshold = 0.5f;
    public bool InvertCameraAxis = false;
    private TOGGLE_MODE ToggleMode = TOGGLE_MODE.TARGET_CAMERA;
    
    private Transform g_Camera;

    private Space g_SpaceTarget = Space.World;

    private Vector2 g_LastMousePosition;

    #endregion

    #region Unity_Functions

    public void Start() {
        g_Camera = Camera.main.transform;
    }
    
    // Update is called once per frame
    void Update () {

        float speedMod = Input.GetKey((KeyCode)KEYBOARD_INPUT.SPEED_MODIFIER) ? 30f : 15f;

        if(Input.GetKeyDown((KeyCode)KEYBOARD_INPUT.SPACE_MODIFIER)) {
            if (g_SpaceTarget == Space.World) {
                g_SpaceTarget = Space.Self;
                Debug.Log("Space::Self");
            } else {
                g_SpaceTarget = Space.World;
                Debug.Log("Space::World");
            }
        }

        // Hanlde Mouse

        foreach(MOUSE_INPUT mi in Enum.GetValues(typeof(MOUSE_INPUT))) {
            if(Input.GetKey((KeyCode)mi)) {
                float horDelta = g_LastMousePosition.x - Input.mousePosition.x;
                float verDelta = g_LastMousePosition.y - Input.mousePosition.y;
                if (Mathf.Abs(horDelta) > CameraRotationThreshold) {
                    int horDir = horDelta > 0 ? (InvertCameraAxis ? 1 : -1) : (InvertCameraAxis ? -1 : 1);
                    g_Camera.Rotate(Vector3.up, horDir * speedMod * ObjectRotationSpeed * Time.deltaTime, Space.World);
                }
                if (Mathf.Abs(verDelta) > CameraRotationThreshold) {
                    int verDir = verDelta > 0 ? (InvertCameraAxis ? -1 : 1) : (InvertCameraAxis ? 1 : -1);
                    g_Camera.Rotate(g_Camera.right, verDir * speedMod * ObjectRotationSpeed * Time.deltaTime, Space.World);
                }

            }
        }


        // Handle Keyboard

    if (ToggleMode == TOGGLE_MODE.TARGET_CAMERA && g_Camera != null) {
            foreach (KEYBOARD_INPUT val in Enum.GetValues(typeof(KEYBOARD_INPUT))) {
                if(Input.GetKey((KeyCode) val)) {
                    switch(val) {
                        case KEYBOARD_INPUT.FORWARD:
                            g_Camera.position += (g_Camera.forward * Time.deltaTime * speedMod);
                            break;
                        case KEYBOARD_INPUT.BACKWARDS:
                            g_Camera.position -= (g_Camera.forward * Time.deltaTime * speedMod);
                            break;
                        case KEYBOARD_INPUT.LEFT_STRAFE:
                            g_Camera.position -= (g_Camera.right * Time.deltaTime * speedMod);
                            break;
                        case KEYBOARD_INPUT.RIGHT_STRAFE:
                            g_Camera.position += (g_Camera.right * Time.deltaTime * speedMod);
                            break;
                        case KEYBOARD_INPUT.LEFT_ROTATE:
                            g_Camera.Rotate(Vector3.up, -(speedMod * Time.deltaTime * ObjectRotationSpeed), Space.World);
                            break;
                        case KEYBOARD_INPUT.RIGHT_ROTATE:
                            g_Camera.Rotate(Vector3.up, speedMod * Time.deltaTime * ObjectRotationSpeed, Space.World);
                            break;
                        case KEYBOARD_INPUT.VERT_POS:
                            g_Camera.position += (g_Camera.up * Time.deltaTime * speedMod);
                            break;
                        case KEYBOARD_INPUT.VERT_NEG:
                            g_Camera.position -= (g_Camera.up * Time.deltaTime * speedMod);
                            break;
                    }
                }
            }
        }

        g_LastMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    }

    #endregion


}
