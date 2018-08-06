using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterestPointManager : MonoBehaviour {

    public bool isViewing;
    InterestPoint selectedPoint;
    public LayerMask interest;

    public LayerMask sphereLayer;
    public GameObject reticule, obj;
    public float scale = 1;

    public Text text;

    public Transform list;
    public int current;


    public void SelectPrevious()
    {
        if (current == 0)
            current = list.childCount - 1;
        else
            current--;
        transform.LookAt(list.GetChild(current));
    }

    public void SelectNext()
    {
        if (current == list.childCount-1)
            current = 0;
        else
            current++;
        transform.LookAt(list.GetChild(current));
    }



    public void CreatePoint()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f, sphereLayer);

        GameObject p = Instantiate(obj, hit.point + hit.normal * scale, Quaternion.identity);
        p.transform.SetParent(list.transform);
        p.transform.LookAt(transform);

        InterestPoint ip = p.GetComponent<InterestPoint>();
        ip.position = hit.point + hit.normal * scale;
        ip.stringText = text.text;
        current = list.childCount - 1;
        ip.Setup();
    }


    public void DeletePoint()
    {
        list.GetChild(current).GetComponent<InterestPoint>().Delete();
    }

    public void Update()
    {
        if (!isViewing)
            CreateMode();
        else
            ViewMode();
      }

    public void CreateMode()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100f, sphereLayer);
        if (hit.collider.tag == "Sphere")
        {
            reticule.transform.position = hit.point + hit.normal * scale;
            reticule.transform.LookAt(transform);
        }
    }

    public void ViewMode()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        bool result = Physics.Raycast(ray, out hitInfo, 100f, interest);

        InterestPoint obj;
        if (result)
        {
            obj = hitInfo.collider.gameObject.GetComponent<InterestPoint>();
            if (obj != null)
                if (selectedPoint != obj)
                {
                    if (selectedPoint != null)
                    {
                        selectedPoint.HideText();
                        selectedPoint = obj;
                        selectedPoint.DisplayText();
                    }

                }
        }


    }
}

