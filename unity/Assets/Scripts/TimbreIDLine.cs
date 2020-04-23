using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TimbreIDLine : MonoBehaviour
{

    #region Variables

    private TextAsset textFile, featText;            // drop your file here in inspector
    public string[] lines = { }, feats= { };       // the array holding each line of text, and each feature
    public int Xplot, Yplot, Zplot, triRes;         // the user-defined choice for each axis
    public int Rplot, Gplot, Bplot, Aplot;          // the user-defined choice for each color
    public int pRplot, pGplot, pBplot, pAplot;      // 
    public int pXplot, pYplot, pZplot, ptriRes;    // so that we dont update on unnecessary plots
    private int plotSize; 
     public int maxLines = 5;
    private GameObject[] o_O;                 // the empty objects for proximity triggering 
    public GameObject[] o_Seq;  // and the array of sequencer dummies
    public GameObject sndFrame, sequencer;           // the prefab sphere to plot as each frame and the line rendering dummy
    public float scale;                             // optional scale
    private float pscale;                           // same here
    public float xof,yof,zof;                       // apply some offsets

    public int[] lineIndexArray;                    //arrary storing line lengths
    public int currPoints=0, prevPoints=0;

    public Vector3[] storedPositions; //positions of accessed cubes 
    public float[] storedObjIDs;
    
    // in here we store all lines to be created by user
    //public List<CubeSelector>[] cubeSelectArray;
    public bool pressedR, pressedL, enableList=true;
    public int cubeSelectArrayLength=0;
    private GameObject CubeTest;

    public Material gM;
    private Vector3[] vertices;


    #endregion


    #region Start

    void Start()
    {
        
        storedPositions = new Vector3[currPoints];
        storedObjIDs = new float[currPoints];
        Xplot = 1;
        Yplot = 2;
        Zplot = 3;
        Rplot = 4;
        Gplot = 5;
        Bplot = 6;
        Aplot = 7;
        scale = 2f;
        triRes = 3;
        yof = -2.8f;
        xof = 7.5f;
        zof = -1.5f;


        textFile = Resources.Load<TextAsset>("bird10");
        featText = Resources.Load<TextAsset>("feature_index");

        // read the lines of the text into a private array of strings
        lines = textFile.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        feats = featText.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        plotSize = (lines[0].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries)).Length;
        // Initialize object's mesh filter, renderer, and place a new mesh that we can edit afterwards
        
        //gameObject.AddComponent<LineRenderer>();
        //var lr = gameObject.GetComponent<LineRenderer>();
        //lr.material = gM;
        //lr.widthMultiplier = 0.02f;
        //lr.positionCount = lines.Length;
        
         
        gameObject.transform.position = new Vector3(0,0,0);
       // CubeTest = GameObject.FindGameObjectWithTag("cubetest");
        // CubeTest.GetComponent<Text>().text = ("yes");
       o_Seq = new GameObject[maxLines];
       lineIndexArray = new int[maxLines];

        // The last thing Start does is instantiate Prefabas... please dont add anything after!
        InstantiatePrefabs();
    }

    #endregion


#region Update
#if true
    void Update()
    {
        // only update if user changed some value
        if (Xplot != pXplot || Yplot != pYplot ||
            Zplot != pZplot || scale != pscale || triRes != ptriRes || 
            Rplot != pRplot || Gplot != pGplot || Bplot != pBplot || Aplot != pAplot)
        {
            UpdateShape();
            pXplot = Xplot;
            pYplot = Yplot;
            pZplot = Zplot;
            pRplot = Rplot;
            pGplot = Gplot;
            pBplot = Bplot;
            pAplot = Aplot;
        }
        
        
        pressedR = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
        //pressedL = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        //if (pressedR || pressedL)
        //{
        //    CubeTest.GetComponent<Renderer>().material.color = new Color(1f, 0, 0, 1f);
        //}
        //else
        //{
        //    CubeTest.GetComponent<Renderer>().material.color = new Color(0, 0, 1f, 1f);

        //}
        
         
         //pressedR = Input.GetKey("e");

        //if the previous length of position array is different than the new one
        // set the position of the line lr.SetPositions(vertices);



        if (pressedR && cubeSelectArrayLength < maxLines)
        {
            if (enableList)
            { 
                enableList = false;
                // create just one

                //GameObject rHand = GameObject.FindGameObjectWithTag("RHAND");
                //cubeSelectArray[cubeSelectArrayLength] = new List<CubeSelector>();
                storedPositions = new Vector3[0];
                storedObjIDs = new float[0];
                currPoints = prevPoints = 0;
                o_Seq[cubeSelectArrayLength] = Instantiate(sequencer, new Vector3(0f, 0f, 0f), Quaternion.identity);
                

                //CubeTest.GetComponent<Text>().text = cubeSelectArrayLength.ToString();
                cubeSelectArrayLength++;
            
               // Debug.Log(o_Seq);
               // Debug.Log("I have created o_Seq");
            }
        }
        else
        {
            enableList = true;
            // only when i release it enable a new one to be 
            // and update position array and object/cube id array
            if (cubeSelectArrayLength > 0)
            {
                listings lst = (listings)o_Seq[cubeSelectArrayLength - 1].GetComponent(typeof(listings));
                lst.UpdatePositions(storedPositions);
                lst.UpdateCubeIDs(storedObjIDs);
            }
        }

        if (currPoints != prevPoints && cubeSelectArrayLength>0)
        {
            //update Line Renderer with the new line points (graphical)
            listings lst = (listings)o_Seq[cubeSelectArrayLength-1].GetComponent(typeof (listings));
            lst.UpdateLine(storedPositions);

            // make them equal
            prevPoints = currPoints;
            Debug.Log(o_Seq);
        }

    }
#endif
#endregion
    public int UpdateIt(ref int current, ref int prev)
    {
        int temp = prev;
        int curr = (temp + 1) % plotSize;
        current = curr;
        UnityPD.SendBang("test_bang");
        prev = curr;
        return curr;
    }

    public float[] GetValues(int i)
    {
        float[] vals = new float[8];
        // split the line (v) in fields using a space as separator
        string[] l = lines[i].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
        // position
        vals[0]= ((float.Parse(l[Xplot])) - 0.5f ) * 2f;
        vals[1]= ( float.Parse(l[Yplot])) * 1.5f + 0.5f;
        vals[2]= ((float.Parse(l[Zplot])) - 0.5f ) * 2f;
        // color
        vals[3]=   float.Parse(l[Rplot]);
        vals[4]=   float.Parse(l[Gplot]);
        vals[5]=   float.Parse(l[Bplot]);
        vals[6]=   float.Parse(l[Aplot]);
        // ID
        vals[7] =  float.Parse(l[1]);
        
        return vals;
    }

#region UpdateShape

    void UpdateShape()
    {
        //LineRenderer lr = GetComponent<LineRenderer>();
        vertices = new Vector3[lines.Length];
        float[] objIDs = new float[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            float[] vals = GetValues(i);
            vertices[i] = new Vector3(vals[0], vals[1], vals[2]);
            o_O[i].transform.position = vertices[i];
            DistanceTrigger cpm = (DistanceTrigger)o_O[i].GetComponent(typeof (DistanceTrigger));
            cpm.UpdatePosition();
            cpm.UpdateColor(new Color(vals[3], vals[4], vals[5], vals[6]));
            objIDs[i] = cpm.GetID();
        }
        if(cubeSelectArrayLength>0)
        {
           for(int i=0; i<cubeSelectArrayLength; i++)
            {
                listings lst = (listings)o_Seq[i].GetComponent(typeof (listings));
                Vector3[] sP = lst.storedPositions;
                float[] sO = lst.cubeIDs;
                Vector3[] newPositions = new Vector3[lst.storedPositions.Length];
                //for all cubes in the sO array (cube ID)
                for (int j=0; j<sO.Length; j++)
                {
                    int objIndex = System.Array.IndexOf(objIDs, sO[j]);
                    DistanceTrigger cpm = (DistanceTrigger)o_O[objIndex].GetComponent(typeof (DistanceTrigger));
                    newPositions[j] = cpm.GetPosition();
                }
                lst.UpdatePositions(newPositions);
                lst.UpdateLine(newPositions);
                //store new position of the cube

                //update line array with new cube position

            }
        }
        //lr.SetPositions(vertices);
    }

#endregion


#region InstantiatePrefabs
    void InstantiatePrefabs()
    {
        //LineRenderer lr = GetComponent<LineRenderer>();
        
        o_O = new GameObject[lines.Length];
        vertices = new Vector3[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            float[] vals = GetValues(i);
            vertices[i] = new Vector3(vals[0], vals[1], vals[2]);
            o_O[i] = Instantiate(sndFrame, vertices[i], Quaternion.identity);
            DistanceTrigger cpm = (DistanceTrigger)o_O[i].GetComponent(typeof (DistanceTrigger));
            cpm.UpdateColor(new Color(vals[3], vals[4], vals[5], vals[6]));
            cpm.SetId(vals[7], i);
        }
        //lr.SetPositions(vertices);
    }

#endregion

}
