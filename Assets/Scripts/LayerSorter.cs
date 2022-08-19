using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerSorter : MonoBehaviour,IInit
{
    public static LayerSorter instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Init()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer item in renderers)
        {
            DefineLayer(item);
        }
    }

    public void DefineLayer(Renderer renderer)
    {
        SpriteRenderer mspriteRenderer = renderer as SpriteRenderer;
        if(mspriteRenderer != null)
        {
            mspriteRenderer.sortingOrder = Mathf.RoundToInt(mspriteRenderer.transform.position.y * -1000);
            return;
        }
        TilemapRenderer tileRenderer = renderer as TilemapRenderer;
        if (tileRenderer != null)
        {
            tileRenderer.sortingOrder = Mathf.RoundToInt(tileRenderer.transform.position.y * -1000);
            return;
        }
    }
}
