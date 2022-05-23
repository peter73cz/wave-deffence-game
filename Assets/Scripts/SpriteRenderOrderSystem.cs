using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpriteRenderOrderSystem : MonoBehaviour
{
    public void Update()
    {
        SpriteRenderer[] renders = FindObjectsOfType<SpriteRenderer>();    
        foreach(SpriteRenderer renderer in renders)
        {
            if (renderer.sortingLayerName == "Objects")
            {
                renderer.sortingOrder = (int)(renderer.transform.position.y * -100);
            }
        }

        SortingGroup[] groups = FindObjectsOfType<SortingGroup>();
        foreach (SortingGroup group in groups)
        {
            if (group.sortingLayerName == "Objects")
            {
                group.sortingOrder = (int)(group.transform.position.y * -100);
            }
        }
    }

}
