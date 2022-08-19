using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;

public interface IMyFlowPlayer : IArticyFlowPlayerCallbacks
{
    public ArticyFlowPlayer flowPlayer { get; set; }
    public List<SmartEntity> speakers{get;set;}
}
