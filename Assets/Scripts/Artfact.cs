using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artfact : MonoBehaviour
{
    // reference variables
    public bool homePos; 
    public GameObject parent;
    UserRotation userRotation;
    Rigidbody m_Rigidbody;

    // rotation variables 
    float baseRotationSpeed = 0.15f;
    float rotationSpeed = 0.0f;
    float maxRotationSpeed = 3.5f;
    float speedDV;

    // bounce variables 
    public bool clicked = false;
    float height = 1.5f;
    int force = 15;

    GameObject artifactPF;
    public GameObject m_pPrefab;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        userRotation = parent.GetComponentInParent<UserRotation>();

        artifactPF = Instantiate(m_pPrefab, new Vector3(0,1,0), Quaternion.identity) as GameObject;
        artifactPF.transform.parent=transform;
        this.transform.GetChild(0).transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
        if (userRotation != null)
        {
            homePos = userRotation.rotatedHome;
            if (homePos == true){
                rotate();
            }
        }
        
    }
     void rotate (){
         // rotate reduce to max
        if (rotationSpeed > maxRotationSpeed)
        { 
            rotationSpeed = maxRotationSpeed; 
        }
        // rotate de/increase speed
        if (rotationSpeed != baseRotationSpeed)
        {
             rotationSpeed = Mathf.SmoothDamp(rotationSpeed, baseRotationSpeed, ref speedDV, 4.0f);
        }
        this.transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }
    void bounce (){
        if (clicked == true & this.transform.position.y < height)
        {
            m_Rigidbody.AddForce(transform.up * force);
        }
        if(this.transform.position.y > height)
        {
            clicked = false;
        }        
    }
}
