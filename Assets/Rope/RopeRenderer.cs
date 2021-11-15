using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public int Segments = 10;

    public void Draw(Vector3 A, Vector3 B,float Lenght)
    {
        LineRenderer.enabled = true; 

        float interpolant = Vector3.Distance(A, B) / Lenght;
        float offset = Mathf.Lerp((Lenght / 2f), 0, interpolant);

       Vector3 ADown= A + Vector3.down * offset;
       Vector3 BDown = B + Vector3.down * offset;


        LineRenderer.positionCount = Segments+1;
        for (int i = 0; i < Segments+1; i++)
        {
            LineRenderer.SetPosition(i, Bezier.GetPoint(A, ADown, BDown, B, (float)i / Segments));
        }
    }

    public void Hide()
    {
        LineRenderer.enabled = false;
    }
}
