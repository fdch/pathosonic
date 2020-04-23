using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listings : MonoBehaviour
{
    public Vector3[] storedPositions;   // points on the line
    public float[] cubeIDs;               // Id of each cube
    public int numPoints;               // how many points the line has
    public Material lM;
    public LineRenderer lr; 
    public float linewidth=0.02f;
    public TimbreIDLine timbreIDLine;

    private void Start()
    {
        timbreIDLine = GameObject.FindGameObjectWithTag("LineBase").GetComponent<TimbreIDLine>();
        lM = timbreIDLine.gM; 
        lr = GetComponent<LineRenderer>();
        lr.material = lM;
        lr.widthMultiplier = 0.02f;
    }
    public void UpdateLine(Vector3[] points)
    {        
        lr.positionCount = points.Length;
        lr.SetPositions(points);
        storedPositions = points;
    }
    public void UpdatePositions(Vector3[] newPositions)
    {
        storedPositions = newPositions;
        numPoints = newPositions.Length;
    }
    public void UpdateCubeIDs(float[] newID)
    {
        cubeIDs = newID;
    }
}