using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PathFinder pathFinder;
    
    private TileSelect targetTile;
    public UnitMovement markedUnit;
    public UnitMovement targetUnit;

    public bool unitSelected = false;
    public bool cardSelected = false;
    private bool pathResetable = false;
    private bool pathSelected = false;
    private bool firstTileSelected = false;

    // Use this for initialization
    void Start ()
    {
        pathFinder = GetComponent<PathFinder>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pathResetable && Input.GetMouseButtonDown(0))
        {
            pathFinder.resetPath();
            unitSelected = false;
            cardSelected = false;
            markedUnit.GetComponent<UnitController>().deActivateAllCards();
            targetUnit = null;
            markedUnit = null;
        }

        if (pathSelected)
        {
            pathResetable = true;
        }

        if (Input.GetMouseButtonDown(1) && !markedUnit.isStillMoving() && targetUnit == null && !cardSelected)
        {
            unitSelected = false;
            StartCoroutine(markedUnit.moveUnit());
            markedUnit = null;
        }
        
        if (unitSelected)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 1)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 2)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 3)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 4)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(3);
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 5)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(4);
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) && markedUnit.GetComponent<UnitController>().getActiveCardCount() >= 6)
            {
                cardSelected = true;
                markedUnit.GetComponent<UnitController>().deActivateAllCards();
                markedUnit.GetComponent<UnitController>().useCard(5);
            }
        }
    }

    public void setTargetTile(TileSelect targetTile) { this.targetTile = targetTile; }
    public TileSelect getTargetTile() { return targetTile; }

    public void setMarkedUnit(UnitMovement markedUnit) { this.markedUnit = markedUnit; }
    public UnitMovement getMarkedUnit() { return markedUnit; }

    public void setTargetUnit(UnitMovement targetUnit) { this.targetUnit = targetUnit; }
    public UnitMovement getTargetUnit() { return targetUnit; }

    public void setUnitSelected(bool unitSelected) { this.unitSelected = unitSelected; }
    public void setCardSelected(bool cardSelected) { this.cardSelected = cardSelected; }
    public void setPathResetable(bool pathResetable) { this.pathResetable = pathResetable; }
    public void setPathSelected(bool pathSelected) { this.pathSelected = pathSelected; }
    public void setFirstTileSelected(bool firstTileSelected) { this.firstTileSelected = firstTileSelected; }

    public bool isUnitSelected() { return unitSelected; }
    public bool isCardSelected() { return cardSelected; }
    public bool isPathResetable() { return pathResetable; }
    public bool isPathSelected() { return pathSelected; }
    public bool isFirstTileSelected() { return firstTileSelected; }
}