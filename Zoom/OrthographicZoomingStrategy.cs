using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicZoomingStrategy : IZoomStrategy
{
    public OrthographicZoomingStrategy(Camera cam, float startingZoom)
    {
        cam.orthographicSize = startingZoom;
    }


    public void ZoomIn(Camera cam, float delta, float nearZoomLimit)
    {
        if (cam.orthographicSize == nearZoomLimit) return;
        cam.orthographicSize = Mathf.Max(cam.orthographicSize - delta, nearZoomLimit);
    }

    public void ZoomOut(Camera cam, float delta, float farZoomLimit)
    {
        if (cam.orthographicSize == farZoomLimit) return;
        cam.orthographicSize = Mathf.Min(cam.orthographicSize + delta, farZoomLimit);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
