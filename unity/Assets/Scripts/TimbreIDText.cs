using UnityEngine;
using System.Linq;

public class TimbreIDText : MonoBehaviour
{
    public TextAsset textFile;      // drop your file here in inspector
    //public GameObject sndFrame;      // the prefab sphere to plot as each frame
    Mesh mesh;
    public Vector3[] vertices;
    private int[] startTimes; // the start times of the playback
                              /// public Renderer[] o_R;            // the renderers
                              /// public Material[] o_M;            // the materials
    private string[] lines = { };    // the array holding each line of text
    /// <summary>
    /// These are indices to the feature space array
    /// User needs to define these by clicking or selecting
    /// </summary>
    public int Xplot, Yplot, Zplot; // the user-defined choice for each axis
    //public int Rplot, Gplot, Bplot, Aplot; // the user-defined choice of RGBA
    //public int Psize;              // the user-defined choice of size

    private float timer;
    private double sampleRate = 0.0F;
    private double startTick = 0.0F;
    public float scale;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        startTick = AudioSettings.dspTime;
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        Xplot = 2;
        Yplot = 3;
        Zplot = 4;
        scale = 10.0f;
        //float halfs = scale / 2f;
        // split the text in lines using the newline separator
        lines = textFile.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < vertices.Length; i++)
        {
            if (i == 0)
            {
                vertices[i] = new Vector3(scale*-1f, 0f, scale);
            } else if (i ==10)
            {
                vertices[i] = new Vector3(scale, 0f, scale);
            }
            else if (i == 110)
            {
                vertices[i] = new Vector3(scale * -1f, 0f, scale* -1f);
            }
            else if (i == 120)
            {
                vertices[i] = new Vector3(scale, 0f, scale * -1f);

            }
            else
            {
                // split the line (v) in fields using a space as separator
                string[] l = lines[i].Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
                // position
                float x = float.Parse(l[Xplot]);
                float y = float.Parse(l[Yplot]);
                float z = float.Parse(l[Zplot]);
                //Debug.Log(x +" "+ y+ " " + z);
                vertices[i] = new Vector3(x * scale, y * scale, z * scale);
            }


        }
        Vector3[] sortvertices = vertices.OrderBy(v => v.y).ToArray<Vector3>();
        mesh.vertices = sortvertices;
        mesh.RecalculateBounds();
    }
    void Update()
    {


    }
}


