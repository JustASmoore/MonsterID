using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenTap : MonoBehaviour
{
    bool Selected = false;
    bool DeSelection = false;
    float selectionTimeOut = 2f;
    GameObject objectOfInterest;
    GameObject objectOfInterestARCHIVE;

    Color originalColor;
    Color originalColorARCHIVE;

    bool startUpFirstClick = false;



    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && Selected == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            print("hit: " + Input.touches);
          
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider != null)
                {
                    

                    originalColor = hit.collider.GetComponent<MeshRenderer>().material.color;


                    if (startUpFirstClick == false)
                    {
                        startUpFirstClick = true;
                        originalColor = hit.collider.GetComponent<MeshRenderer>().material.color;
                    }
                    Color newColor = new Color(1, 1, 1, 1.0f);
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    selectionTimeOut = 3f;

                    Selected = true;
                    print("selected: " + Selected);
                    print("timeout: " + selectionTimeOut);

                    objectOfInterestARCHIVE = objectOfInterest;
                    print("InterestArch: " + objectOfInterestARCHIVE);

                    objectOfInterest = hit.collider.gameObject;
                    print("Interest: " + objectOfInterest);
                }
            }
        }
        
        
        
    }
    private void Update()
    {
        if (Selected == true && selectionTimeOut > 0)
        {
            selectionTimeOut -= Time.deltaTime;
            if (selectionTimeOut <= 0)
            {
                objectOfInterest.GetComponent<MeshRenderer>().material.color = originalColor;
                Selected = false;
                print("selected: " + Selected);
                print("timeout: " + selectionTimeOut);
            }
        }

        if (objectOfInterestARCHIVE )
        {

        }
    }
}
