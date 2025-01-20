using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueBlockScript : MonoBehaviour
{
    float rotationScale = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if( gameObject.name.ContainsInsensitive("plank"))
        {
            rotationScale = 50.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Quaternion.AngleAxis(Time.time * rotationScale, transform.forward);
    }
}
