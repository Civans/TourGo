using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleInterestPoints : MonoBehaviour {

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
        if (current == list.childCount)
            current = 0;
        else
            current++;
        transform.LookAt(list.GetChild(current));
    }

}
