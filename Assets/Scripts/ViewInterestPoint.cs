using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewInterestPoint : MonoBehaviour
{

    InterestPoint current;
    public LayerMask interest;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        bool result = Physics.Raycast(ray, out hitInfo, 100f, interest);

        InterestPoint obj;
        if (result)
        {
            obj = hitInfo.collider.gameObject.GetComponent<InterestPoint>();
            if(obj!=null)
                if (current != obj)
                {
                    if (current != null)
                    {
                        current.HideText();
                        current = obj;
                        current.DisplayText();
                    }

                }
        }


    }

}
