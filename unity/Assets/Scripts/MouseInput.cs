using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput : MonoBehaviour
{
    #region Variables

    //Shape and Color Buttons
    public Button UpdateX, UpdateY, UpdateZ;
    public Button ChangeR, ChangeG, ChangeB;

    //Access the TimbreIDShape scripts
    public TimbreIDLine timbreIDshape;

    //UI
    public GameObject GlobalUI;

    private bool ToggleUI = true;

    private Text XFeat, YFeat, ZFeat;
    #endregion


    #region Start

    void Start()
    {

    }

    #endregion

    #region Toggle UI
     void Update()
    {
        if (Input.GetKeyDown("o"))
        {

            ToggleUI = !ToggleUI;

            if (!ToggleUI)
            {
                GlobalUI.SetActive(false);
            }
            else
            {
                GlobalUI.SetActive(true);
            }

        }


    }
    #endregion
    
    #region Shapes Functions

    public void OnXclick()
    {
        Text textX = UpdateX.GetComponentInChildren<Text>();
            int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pXplot, ref timbreIDshape.Xplot);
                UpdateX.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
        
    }

    public void OnYclick()
    {
        Text textY = UpdateY.GetComponentInChildren<Text>();
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pYplot, ref timbreIDshape.Yplot);
                UpdateY.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
    }

    public void OnZclick()
    {
        Text textZ = UpdateZ.GetComponentInChildren<Text>();
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pZplot, ref timbreIDshape.Zplot);
                UpdateZ.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
 
    }

    #endregion


    #region Color Functions

    public void OnRclick()
    {
        Text textR = ChangeR.GetComponentInChildren<Text>();
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pRplot, ref timbreIDshape.Rplot);
                ChangeR.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
           
    }

    public void OnGclick()
    {
        Text textG = ChangeG.GetComponentInChildren<Text>();
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pGplot, ref timbreIDshape.Gplot);
                ChangeG.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
         
    }

    public void OnBclick()
    {
        Text textB = ChangeB.GetComponentInChildren<Text>();
                int curr = timbreIDshape.UpdateIt(ref timbreIDshape.pBplot, ref timbreIDshape.Bplot);
                ChangeB.GetComponentsInChildren<Text>()[1].text = timbreIDshape.feats[curr];
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
