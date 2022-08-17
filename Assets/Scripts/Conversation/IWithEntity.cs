using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Unity;
using Articy.Unity.Interfaces;

public interface IWithEntity
{
    //public ArticyRef givenEntity { get; set; }

    public IArticyObject entity { get; set; }
    public string entityName { get; set; }
}
