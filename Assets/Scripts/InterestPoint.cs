using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterestPoint : MonoBehaviour {

    public Vector3 position;
    public Vector3 forward;
    public string stringText;
    public GameObject textMeshObj;
    public TextMesh textMesh;
    [Range(0,1)]
    public float scale;
    public void Start()
    {
       
    }


    public void Setup()
    {
        transform.position = position;
        transform.LookAt(Camera.main.transform);
        textMeshObj = new GameObject("Interest Point Mesh");
        textMesh = textMeshObj.AddComponent<TextMesh>();
        textMesh.characterSize = 0.05f;
        textMesh.fontSize = 35;
        textMesh.transform.position = position + transform.forward * scale;
        textMesh.transform.LookAt(Camera.main.transform);
        textMesh.transform.localScale = new Vector3(-1, 1, 1);
        SetText(stringText);
        HideText();
    }
    public void DisplayText()
    {
        textMeshObj.SetActive(true);
    }

    public void HideText()
    {
        textMeshObj.SetActive(false);
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }


    public void Delete()
    {
        GameObject.Destroy(textMeshObj);
        GameObject.Destroy(this.gameObject);
    }
}
