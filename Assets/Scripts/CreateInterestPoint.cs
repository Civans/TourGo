using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreateInterestPoint : MonoBehaviour {

    public LayerMask sphereLayer;
    public GameObject reticule,obj,list;
    public float scale = 1;

    public Text text;
    public void CreatePoint()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f, sphereLayer);

        GameObject p = Instantiate(obj, hit.point+hit.normal*scale, Quaternion.identity);
        p.transform.SetParent(list.transform);
        p.transform.LookAt(transform);

        InterestPoint ip = p.GetComponent<InterestPoint>();
        ip.stringText = text.text;
    }

    public void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f, sphereLayer);
        if(hit.collider.tag == "Sphere")
        {
            reticule.transform.position = hit.point + hit.normal*scale;
            reticule.transform.LookAt(transform);
        }


    }


}
