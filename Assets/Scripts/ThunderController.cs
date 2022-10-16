using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    Light thunder;
    float thunderTime = 1.0f;
    bool isThunderOk = true;

    private void Awake()
    {
        thunder = GetComponent<Light>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(thunderTime>0.06f)
        {
            thunderTime -= 0.02f;
        }
        else if(isThunderOk&&thunderTime>0.02f)
        {
            thunderTime -= 0.02f;
            thunder.intensity = 1.2f;
        }
    }
}
