using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.GridBrushBase;
using static UnityEngine.UI.Image;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField]
    private float cameraSpeed;
    [SerializeField]
    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        if (Input.GetKey(KeyCode.W))
        {
            ////transform.Translate(transform.forward * cameraSpeed * Time.deltaTime);
            //print(transform.eulerAngles.y);
            //transform.Translate(Quaternion.AngleAxis(transform.eulerAngles.y * -1, Vector3.up) * Vector3.forward * cameraSpeed * Time.deltaTime);
            transform.Translate(transform.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * cameraSpeed * Time.deltaTime);
        }
        // Vertical Movement
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        // Camera Rotation
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Rotate(new Vector3(-cameraSpeed * 2 * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Rotate(new Vector3(cameraSpeed * 2 * Time.deltaTime, 0, 0));
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Rotate(Vector3.up * -2 * cameraSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Rotate(Vector3.up * 2 * cameraSpeed * Time.deltaTime);
        //}
    }
}
