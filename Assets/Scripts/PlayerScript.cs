using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float speedScale = 1.0f;
    public GameObject ShieldPrefab;
    GameObject m_ActualShield;
    float m_ShieldStrength;
    float m_ShieldAngle;

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

        RotateShield();
    }

    void RotateShield()
    {
        if( m_ActualShield == null )
        {
            return;
        }

        m_ActualShield.transform.localPosition = Quaternion.Euler(0, 0, Time.time * 100.0f) * new Vector3(2f, 0, 0);
     }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");

        GameObject other = collision.gameObject;
        string who = collision.gameObject.name;
        if (who.Contains("Shield_block", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Destroy(other);
            TurnOnShield();
        }
    }

    void SetShieldFullStrength()
    {
        m_ShieldStrength = 1.0f;
    }

    void TurnOnShield()
    {
        if (m_ActualShield == null)
        {
            m_ActualShield = Instantiate(ShieldPrefab, this.transform);
            m_ActualShield.transform.localPosition = new Vector3(2f, 0, 0);
        }

        SetShieldFullStrength();
    }
}
