using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOutlineController : MonoBehaviour
{
    Material outlineMaterial;

    private void Awake()
    {
        outlineMaterial = Resources.Load<Material>("Materials/OutlineMat");
        gameObject.GetComponent<Renderer>().material = outlineMaterial;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.U))
        {
            SetOutline(Random.ColorHSV(), 0.01f);
        }
    }

    public void SetOutline(Color outlineColor,float outlineWidth)
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("_outlineOffset", outlineWidth);
        gameObject.GetComponent<Renderer>().material.SetColor("_outlineColor", outlineColor);
    }
}
