using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlSmog(GameObject smog,int mode)
    {
       
        ParticleSystem ps =smog.GetComponent<ParticleSystem>();
        var main = ps.main;



        switch (mode)
        {
            case 0:
                ps.Stop();
                break;
            case 1:
                main.startColor = new Color((float)0.6603774, (float)0.6603774, (float)0.6603774, (float)0.6862745);
                break;
            case 2:
                main.startColor = new Color((float)0.2735849, (float)0.1535689, (float)0.1535689, (float)0.6862745);
                break;
            case 3:
                main.startColor = new Color((float)0.1226415, (float)0.08966714, (float)0.08966714, (float)0.6862745);
                break;
        }

    }

}
