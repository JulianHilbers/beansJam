using UnityEngine;
using System.Collections.Generic;

public class StreetScoller : MonoBehaviour
{
    public int visibleObjects;

    public GameObject streetObject;
    public List<Sprite> streetSprites;

    private List<GameObject> streets;

    void Start()
    {
        BoxCollider2D streetCollider = streetObject.GetComponent<BoxCollider2D>();
        float verticalLength = streetCollider.size.y * streetObject.transform.localScale.y;
        float lastPos = 0;

        for (int i = 0; i < visibleObjects; i++)
        {
            GameObject sClone = Instantiate(streetObject, transform);
            sClone.GetComponent<SpriteRenderer>().sprite = streetSprites[i];

            BackgroundLoop bl = sClone.GetComponent<BackgroundLoop>();
            bl.VerticalLength = verticalLength * visibleObjects / 2;
            bl.sprites = streetSprites;

            sClone.transform.position = new Vector3(0, lastPos, 1);

            lastPos -= verticalLength;
        }
    }
}
