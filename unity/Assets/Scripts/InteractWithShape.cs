using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithShape : MonoBehaviour
{
    #region Variables

    //Shape and Color Buttons
    public Button UpdateX, UpdateY, UpdateZ;
    public Button ChangeR, ChangeG, ChangeB;

    // Button Colors
    private ColorBlock Xcol, Ycol, Zcol, Rcol, Gcol, Bcol;

    //Access the TimbreIDShape scripts
    public TimbreIDLine timbreIDshape;

    //Mallets
    private GameObject lHand, rHand;

    //UI
    public GameObject GlobalUI;


    //Shape Buttons Distance
    private float lXdist, lYdist, lZdist;
    private float rXdist, rYdist, rZdist;

    //Color Buttons Distance
    private float lRdist, lGdist, lBdist;
    private float rRdist, rGdist, rBdist;

    //Distance Treshhold
    public float distTreshhold = 0.1f;

    //Booleans
    private bool Xchanged = false;
    private bool Ychanged = false;
    private bool Zchanged = false;
    private bool Rchanged = false;
    private bool Gchanged = false;
    private bool Bchanged = false;
    private bool ToggleUI = true;

    //Controllers
    public OVRInput.Controller Rcontroller;
    public OVRInput.Controller Lcontroller;

    private Text XFeat,YFeat,ZFeat;
    #endregion


    #region Start

    void Start()
    {


        UpdateX.onClick.AddListener(OnXclick);
        UpdateY.onClick.AddListener(OnYclick);
        UpdateZ.onClick.AddListener(OnZclick);

        ChangeR.onClick.AddListener(OnRclick);
        ChangeG.onClick.AddListener(OnGclick);
        ChangeB.onClick.AddListener(OnBclick);

        Rcontroller = (OVRInput.Controller.RTouch);
        Rcontroller = (OVRInput.Controller.LTouch);

        rHand = GameObject.FindGameObjectWithTag("RHAND");
        lHand = GameObject.FindGameObjectWithTag("LHAND");

    }

    #endregion

    #region Toggle UI
    private void ToggleInterface()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown("o"))
        {

            ToggleUI = !ToggleUI;

            if (!ToggleUI)
            {
                GlobalUI.SetActive(false);
            } else
            {
                GlobalUI.SetActive(true);
            }
            
        }

        
    }
    #endregion
    #region Update Function

    private void Update()
    {
        if (GlobalUI.activeSelf)
        {
            //Get distance of Left and Right Mullet from Shape Buttons
            rXdist = Vector3.Distance(rHand.transform.position, UpdateX.transform.position);
            lXdist = Vector3.Distance(lHand.transform.position, UpdateX.transform.position);

            rYdist = Vector3.Distance(rHand.transform.position, UpdateY.transform.position);
            lYdist = Vector3.Distance(lHand.transform.position, UpdateY.transform.position);

            rZdist = Vector3.Distance(rHand.transform.position, UpdateZ.transform.position);
            lZdist = Vector3.Distance(lHand.transform.position, UpdateZ.transform.position);

            //Get distance of Left and Right Mullet from Color Buttons
            rRdist = Vector3.Distance(rHand.transform.position, ChangeR.transform.position);
            lRdist = Vector3.Distance(lHand.transform.position, ChangeR.transform.position);

            rGdist = Vector3.Distance(rHand.transform.position, ChangeG.transform.position);
            lGdist = Vector3.Distance(lHand.transform.position, ChangeG.transform.position);

            rBdist = Vector3.Distance(rHand.transform.position, ChangeB.transform.position);
            lBdist = Vector3.Distance(lHand.transform.position, ChangeB.transform.position);

            //Check and Run Shapes Functions
            OnXclick();
            OnYclick();
            OnZclick();

            //Check and Run Colors Functions
            OnRclick();
            OnGclick();
            OnBclick();
        }
        //Toggle UI
        ToggleInterface();
    }

    #endregion


    #region Shapes Functions

    public void OnXclick()
    { 
        Text textX = UpdateX.GetComponentInChildren<Text>();

        if (rXdist <= distTreshhold || lXdist <= distTreshhold)
        {
            Xcol = UpdateX.colors;
            Xcol.normalColor = Color.blue;
            UpdateX.colors = Xcol;
            textX.color = Color.white;

            if (!Xchanged)
            {
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pXplot, ref timbreIDshape.Xplot);
                
                Xchanged = true;
                UpdateX.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Xcol = UpdateX.colors;
            Xcol.normalColor = Color.white;
            UpdateX.colors = Xcol;
            textX.color = Color.black;

            Xchanged = false;
        }
    }

    public void OnYclick()
    {
        Text textY = UpdateY.GetComponentInChildren<Text>();

        if (rYdist <= distTreshhold || lYdist <= distTreshhold)
        {
            Ycol = UpdateY.colors;
            Ycol.normalColor = Color.blue;
            UpdateY.colors = Ycol;
            textY.color = Color.white;

            if (!Ychanged)
            {
                int curr=timbreIDshape.UpdateIt(ref timbreIDshape.pYplot, ref timbreIDshape.Yplot);
                Ychanged = true;
                UpdateY.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];

                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Ycol = UpdateY.colors;
            Ycol.normalColor = Color.white;
            UpdateY.colors = Ycol;
            textY.color = Color.black;

            Ychanged = false;
        }
    }

    public void OnZclick()
    {
        Text textZ = UpdateZ.GetComponentInChildren<Text>();

        if (rZdist <= distTreshhold || lZdist <= distTreshhold)
        {
            Zcol = UpdateZ.colors;
            Zcol.normalColor = Color.blue;
            UpdateZ.colors = Zcol;
            textZ.color = Color.white;

            if (!Zchanged)
            {
                int curr=timbreIDshape.UpdateIt(ref timbreIDshape.pZplot, ref timbreIDshape.Zplot);
                Zchanged = true;
                UpdateZ.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Zcol = UpdateZ.colors;
            Zcol.normalColor = Color.white;
            UpdateZ.colors = Zcol;
            textZ.color = Color.black;

            Zchanged = false;
        }
    }

    #endregion


    #region Color Functions

    public void OnRclick()
    {
        Text textR = ChangeR.GetComponentInChildren<Text>();

        if (rRdist <= distTreshhold || lRdist <= distTreshhold)
        {
            Rcol = ChangeR.colors;
            Rcol.normalColor = Color.blue;
            ChangeR.colors = Rcol;
            textR.color = Color.white;

            if (!Rchanged)
            {
               int curr= timbreIDshape.UpdateIt(ref timbreIDshape.pRplot, ref timbreIDshape.Rplot);
                Rchanged = true;
                ChangeR.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];

                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Rcol = ChangeR.colors;
            Rcol.normalColor = Color.white;
            ChangeR.colors = Rcol;
            textR.color = Color.black;

            Rchanged = false;
        }
    }

    public void OnGclick()
    {
        Text textG = ChangeG.GetComponentInChildren<Text>();

        if (rGdist <= distTreshhold || lGdist <= distTreshhold)
        {
            Gcol = ChangeG.colors;
            Gcol.normalColor = Color.blue;
            ChangeG.colors = Gcol;
            textG.color = Color.white;

            if (!Gchanged)
            {
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pGplot, ref timbreIDshape.Gplot);
                Gchanged = true;
                ChangeG.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];

                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Gcol = ChangeG.colors;
            Gcol.normalColor = Color.white;
            ChangeG.colors = Gcol;
            Gchanged = false;
            textG.color = Color.black;
        }
    }

    public void OnBclick()
    {
        Text textB = ChangeB.GetComponentInChildren<Text>();

        if (rBdist <= distTreshhold || lBdist <= distTreshhold)
        {
            Bcol = ChangeB.colors;
            Bcol.normalColor = Color.blue;
            ChangeB.colors = Bcol;
            textB.color = Color.white;

            if (!Bchanged)
            {
                int curr= timbreIDshape.UpdateIt(ref timbreIDshape.pBplot, ref timbreIDshape.Bplot);
                Bchanged = true;
                ChangeB.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];

                OVRInput.SetControllerVibration(1f, 1f, Rcontroller);
                OVRInput.SetControllerVibration(1f, 1f, Lcontroller);
            }
        }
        else
        {
            Bcol = ChangeB.colors;
            Bcol.normalColor = Color.white;
            ChangeB.colors = Bcol;
            textB.color = Color.black;

            Bchanged = false;
        }
    }
    

    #endregion
    public void InitializeFeatureText()
    {
        UpdateX.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Xplot];
        UpdateY.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Yplot];
        UpdateZ.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Zplot];
        ChangeR.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Rplot];
        ChangeG.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Gplot];
        ChangeB.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[timbreIDshape.Bplot];
    }

}
