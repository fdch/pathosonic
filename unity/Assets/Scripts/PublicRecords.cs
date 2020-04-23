using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicRecords : MonoBehaviour
{
    public Vector3[] storedPositions;   // points on the line
    public int[] cubeIDs;               // Id of each cube
    public int numPoints;               // how many points the line has
    

    public void UpdatePositions(Vector3[] newPositions)
    {
        storedPositions = newPositions;
        numPoints = newPositions.Length;
    }
    public void UpdateCubeIDs(int[] newID)
    {
        cubeIDs = newID;
    }
}
