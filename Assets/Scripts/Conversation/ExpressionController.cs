using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionController : MonoBehaviour
{
    public GameObject angry;
    public GameObject amazed;

    public void PlayExpression(string expression)
    {
        switch(expression)
        {
            case "Angry":
                {
                    angry.SetActive(true);
                    break;
                }
            case "Amazed":
                {
                    amazed.SetActive(true);
                    break;
                }
        }
    }
}
