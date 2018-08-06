using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TourSelector : MonoBehaviour {
    List<GameObject> buttons;
    Canvas canvas;
    Text t;
    public GameObject prefabButton;
	// Use this for initialization
	void Start () {
        t = GetComponentInChildren<Text>();
        canvas = GetComponent<Canvas>();
        string path = Application.persistentDataPath+@"/tours";
        t.text = path + "\n";
        DirectoryInfo tours = new DirectoryInfo(path);
        Debug.Log(t.text);
        for(int i =0; i<tours.GetDirectories().Length; i++)
        {
            Debug.Log(tours.GetDirectories()[i]);
            GameObject button = Instantiate(prefabButton, transform);
            button.GetComponentInChildren<Text>().text = tours.GetDirectories()[i].Name;
            button.GetComponentInChildren<Text>().resizeTextForBestFit = true;
            button.GetComponent<TourLoader>().tourPath = path+@"/"+tours.GetDirectories()[i].Name;
            t.text+= path + @"\" + tours.GetDirectories()[i].Name+"\n";
            button.transform.localPosition = new Vector3(0,i * -50, 0);

        }
        t.text += "DEBUG_@Loader";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
