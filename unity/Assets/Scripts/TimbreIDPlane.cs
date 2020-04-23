using UnityEngine;

public class TimbreIDPlane : MonoBehaviour
{
    public TextAsset textFile;      // drop your file here in inspector
    public GameObject sndFrame;      // the prefab sphere to plot as each frame
    private GameObject[] o_O; // the objects
    private int[] startTimes; // the start times of the playback
                              /// public Renderer[] o_R;            // the renderers
                              /// public Material[] o_M;            // the materials
    private string[] lines = { };    // the array holding each line of text
    /// <summary>
    /// These are indices to the feature space array
    /// User needs to define these by clicking or selecting
    /// </summary>
    public int Xplot, Yplot, Zplot; // the user-defined choice for each axis
    private int pXplot, pYplot, pZplot; // the user-defined choice for each axis
    public int Rplot, Gplot, Bplot, Aplot; // the user-defined choice of RGBA
    private int pRplot, pGplot, pBplot, pAplot; // the user-defined choice of RGBA
    public int Psize;              // the user-defined choice of size
    private int pPsize;              // the user-defined choice of size

    private float timer;
    private double sampleRate = 0.0F;
    private double startTick = 0.0F;
    public float scale = 1.0f;
    private float pscale = 1.0f;


    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        startTick = AudioSettings.dspTime;
        
        Xplot = 2;
        Yplot = 3;
        Zplot = 4;
        Psize = 5;
        Rplot = 6;
        Gplot = 7;
        Bplot = 8;
        Aplot = 9;
        scale = 10.0f;
        
        // split the text in lines using the newline separator
        lines = textFile.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

        // string[] l = lines[0].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
        // clonedFrames[0] = Instantiate(sndFrame, new Vector3(float.Parse(l[Xplot]) * scale, float.Parse(l[Yplot]) * scale, float.Parse(l[Zplot])) * scale, Quaternion.identity);

        InstantiateFrames();

    }


    void Update()
    {
        // only update if user changed some value
        if (Xplot != pXplot || Yplot != pYplot || Zplot != pZplot || scale != pscale || Psize != pPsize || Aplot != pAplot || Rplot != pRplot || Gplot != pGplot || Bplot != pBplot)
        {
            InstantiateFrames();
            pXplot = Xplot;
            pYplot = Yplot;
            pZplot = Zplot;
            pPsize = Psize;
            pscale = scale;
        }  

    }


    /// <summary>
    /// This function instantiates all frames reading the file line by line
    /// It should be called on Start() but also
    /// every time user selects or modifies the indices ot the space array
    /// {X,Y,Z,R,G,B}plot and Psize
    /// </summary>
    void InstantiateFrames()
    {
        o_O = new GameObject[lines.Length];
        startTimes = new int[lines.Length];
        //Renderer[] o_R = new Renderer[lines.Length];
        //Material[] o_M = new Material[lines.Length];



        for (int i = 0; i < lines.Length; i++)
        {
            // split the line (v) in fields using a space as separator
            string[] l = lines[i].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
            // position
            float x = float.Parse(l[Xplot]);
            float y = float.Parse(l[Yplot]);
            float z = float.Parse(l[Zplot]);
            // colors
            float r = float.Parse(l[Rplot]);
            float g = float.Parse(l[Gplot]);
            float b = float.Parse(l[Bplot]);
            float a = float.Parse(l[Aplot]);
            // size
            float s = float.Parse(l[Psize]);

            startTimes[i] = Mathf.FloorToInt(float.Parse(l[0]));
            // float end = float.Parse(l[0]) * 2048f;

            //Debug.Log("X=" + xpos);
            //Debug.Log("Y=" + ypos);
            //Debug.Log("Z=" + zpos);
            //
            // TODO: change color and size of each prefab on instatiation...
            //
            o_O[i] = Instantiate(sndFrame, new Vector3(x * scale, y * scale, z * scale), Quaternion.identity);
            //o_R[i] = o_O[i].GetComponent<Renderer>();
            //o_M[i] = o_R[i].GetComponent<Material>();
            //o_R[i].material.color = new Color(r, g, b, a);
            //o_O[i].GetComponent<Renderer>().material.color = new Color(r, g, b, a);



        }
    }
}


