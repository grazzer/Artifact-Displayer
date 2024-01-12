using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserRotation : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    float xPointer;
    float yPointer;
    public float xMapped;
    public float yMapped;
    public bool dragging = false;
    public bool rotatedHome = true; 

    void Start()
    {
        
    }

    void Update()
    {
        if (dragging == false){
            if (rotatedHome == false){
                rotateHome();
            }
        }    
    }

    void rotateHome(){
        Quaternion target = Quaternion.Euler(0, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 12.0f);
        if (this.transform.eulerAngles.y < 0.01f & this.transform.eulerAngles.x < 0.01f & this.transform.eulerAngles.z < 0.01f){
            rotatedHome = true;
        }
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {  
        dragging = true;
        rotatedHome = false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.dragging)
        {
            // Y = this.transform.eulerAngles.y;
            // YMapped = map(Y, 0,  360,  -180, 180);


            xPointer = data.position.x;
            yPointer = data.position.y;
            xMapped = map(xPointer, 20,  1057,  80, -80);
            yMapped = map(yPointer, 0,  1894,  -80, 80);

            Quaternion target = Quaternion.Euler(yMapped, (xMapped), 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 6.0f);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
