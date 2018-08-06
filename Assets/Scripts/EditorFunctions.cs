using SFB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using UnityEngine.UI;

public class EditorFunctions : MonoBehaviour {


    public Transform list;
    public Text sceneNameText;
    public MeshRenderer m;
    public string imagePath;
    public string sceneName;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeTexture()
    {
        string[] path = StandaloneFileBrowser.OpenFilePanel("360 Image", @"C:\", "", false);
        imagePath = path[0];
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Texture2D newTexture = new Texture2D(2, 2);
        newTexture.LoadImage(imageBytes);
        m.material.mainTexture = newTexture;


    }
    public void SaveScene()
    {
        sceneName = sceneNameText.text;

        string tempPath = @"%appdata%\TourApp\"+sceneName+@"\";
        if (Directory.Exists(tempPath))
            Directory.Delete(tempPath,true);
        
        Directory.CreateDirectory(tempPath);
        InterestPoint[] points =list.gameObject.GetComponentsInChildren<InterestPoint>();



        using (StreamWriter sw = File.CreateText(tempPath+"point list.txt"))
        {
            foreach (InterestPoint p in points)
            {

                sw.WriteLine(p.position);
                sw.WriteLine(p.stringText);
            }
            sw.Dispose();
            sw.Close();
        }
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        Texture2D newTexture = new Texture2D(2, 2);
        newTexture.LoadImage(imageBytes);
        FileStream s = File.Create(tempPath + "image.png");
        s.Dispose();
        s.Close();
        File.WriteAllBytes(tempPath + "image.png", newTexture.EncodeToPNG());

        string path = StandaloneFileBrowser.SaveFilePanel("Save Scene","C:",sceneName,"zip");
        FastZip fZip = new FastZip();
        fZip.CreateZip(path,tempPath, true, "");
        Debug.Log(path);
    }


}
