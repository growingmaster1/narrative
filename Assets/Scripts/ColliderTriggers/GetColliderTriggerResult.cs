using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColliderTriggerResult : MonoBehaviour
{
    public TeleBoothCon teleBoothCon;
    public FatherSonCon fatherSonCon;

    // Start is called before the first frame update


    public bool GetFatherSonColliderResult()
    {
        return fatherSonCon.isCollided;
    }

    public bool GetTeleBoothColliderResult()
    {
        return teleBoothCon.isCollided;
    }
}
