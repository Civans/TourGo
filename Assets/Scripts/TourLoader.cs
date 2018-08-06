using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TourLoader : MonoBehaviour {
    public string tourPath;
    public string fileType;

    public GameObject sphere,ip;
    public Texture2D sphereImage;
    public List<GameObject> ips;
    public Material mat;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadTour()
    {
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = Camera.main.transform.position;
        sphere.transform.localScale = new Vector3( 5, 5, 5);
        sphere.AddComponent<ReverseNormals>();
        string imagePath = tourPath + "/image.png";
        WWW www = new WWW(imagePath);
        while (!www.isDone) ;
        byte[] temp = File.ReadAllBytes(imagePath);

        DirectoryInfo f = new DirectoryInfo(tourPath);
        Debug.Log(f.GetFiles()[0] + "\n" + f.GetFiles()[1]);
        Debug.Log("f" + f.GetFiles().Length);
        Debug.Log("f" + f.GetDirectories().Length);
        sphereImage = new Texture2D(2, 2);
        sphereImage.LoadImage(temp);
        sphere.GetComponent<MeshRenderer>().material = mat;
        sphere.GetComponent<MeshRenderer>().material.mainTexture = sphereImage;
        string pointPath = tourPath + "/point list.txt";
        StreamReader text = File.OpenText(pointPath);
        while (!text.EndOfStream)
        {
            string coords = text.ReadLine();
            string pointText = text.ReadLine();

            GameObject point = Instantiate(ip,transform);
            point.GetComponent<InterestPoint>().position = StringToVector3(coords);
            point.GetComponent<InterestPoint>().stringText = pointText;
            point.GetComponent<InterestPoint>().Setup();
            ips.Add(point);
        }

    }

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }

}
