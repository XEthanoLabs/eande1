using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speedScale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z); // keep the camera z at the same spot, but follow the player

        Vector3 currentPos = transform.position;
        currentPos += transform.right * (Time.deltaTime * speedScale);

        Vector3 delta = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            delta = -transform.up;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            delta = transform.up;
        }
        currentPos += delta;
        transform.position = currentPos;
    }
}
