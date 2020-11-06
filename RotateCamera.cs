using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float sensivity = 10;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float MouseX = 0.0f;
    private float MouseY = 0.0f;

    public Vector3 playerX {get; private set;}
    [SerializeField] private GameObject player;

    void Update()
    {
        MouseX += speedH * Time.fixedDeltaTime * Input.GetAxis("Mouse X");
        MouseY -= speedV * Time.fixedDeltaTime * Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(Mathf.Clamp(MouseY , -90 , 90) , 0f , 0f);
        playerX = new Vector3(0 , MouseX , 0);
        
        player.transform.eulerAngles = playerX;
        
        if (MouseX == 0 | MouseY == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
