using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonRaycaster : MonoBehaviour {

    public float maxDistance;
    public InterestPoint current;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray,out hit);

        if(hit.transform != null)
        if (hit.transform.gameObject.GetComponent<Button>() && (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) || OVRInput.Get(OVRInput.Button.One))
            hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();


        InterestPoint temp = hit.transform.gameObject.GetComponent<InterestPoint>();
        if (temp)
        {
            current = temp;
            current.DisplayText();
        } 
        else if( !temp && current)
        {
            current.HideText();
        }



        Debug.DrawRay(transform.position, transform.forward, Color.red);
	}
}
