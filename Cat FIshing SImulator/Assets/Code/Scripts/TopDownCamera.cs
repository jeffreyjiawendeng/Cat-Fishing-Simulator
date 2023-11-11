using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Quaternion.AngleAxis(transform.rotation.y, Vector3.up) * Vector3.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Quaternion.AngleAxis(transform.rotation.y - 90, Vector3.up) * Vector3.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Quaternion.AngleAxis(transform.rotation.y + 180, Vector3.up) * Vector3.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Quaternion.AngleAxis(transform.rotation.y + 90, Vector3.up) * Vector3.forward * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.down * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Rotate(new Vector3(-cameraSpeed * 2 * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Rotate(new Vector3(cameraSpeed * 2 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camera.transform.Rotate(new Vector3(0, -cameraSpeed * 2 * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camera.transform.Rotate(new Vector3(0, cameraSpeed * 2 * Time.deltaTime, 0));
        }
    }
}
