using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDN_Teleport : MonoBehaviour {

    // Target Object
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Reticle;

    [SerializeField] private RectTransform GuiReticle;

    //Sprite
    protected Sprite UIfeet, UITargetReticle, UIReticle;

    //Image
    [SerializeField] public Image uiReticle;
    [SerializeField] public Image uiSelectionBar;
    [SerializeField] public Image uiBackground;

    private void Start()
    {
        //Load  Passport Images
        UIfeet = Resources.Load<Sprite>("UIassets/UIfeet");
        UIReticle = Resources.Load<Sprite>("UIassets/UIReticle");
        UITargetReticle = Resources.Load<Sprite>("UIassets/UITargetReticle");
    }

    private void Update()
    {
    }

    public void changeLocation()
    {
        Player.transform.position = new Vector3(Reticle.transform.position.x, Player.transform.position.y, Reticle.transform.position.z);
    }

    public void RotateReticle()
    {
        GuiReticle.eulerAngles = new Vector3(90, 0, 0);
    }

    public void FeetUI()
    {
        uiReticle.color = new Color (0, 0, 0, 0);
        uiSelectionBar.color = new Color(0, 0, 0, 0);
        uiBackground.sprite = UIfeet;
        uiBackground.color = new Color(0, 0, 0, 1);
    }

    public void ResetUI()
    {
        uiReticle.color = new Color(0, 0, 0, 0.8f);
        uiSelectionBar.color = new Color(0, 0, 0, 1);
        uiBackground.sprite = UIReticle;
        uiBackground.color = new Color(0, 0, 0, 0.8f);
    }
}

