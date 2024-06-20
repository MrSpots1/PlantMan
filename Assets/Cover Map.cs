using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverMap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public RectTransform canvas;
    [SerializeField] public RectTransform Image;
    [SerializeField] public int OriginalHight;
    [SerializeField] public int OriginalWidth;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Image.localScale = new Vector2(canvas.rect.width, (canvas.rect.width * OriginalHight) / OriginalWidth);

    }
}
