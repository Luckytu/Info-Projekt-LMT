﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePathFinder : TileBase {
    
    public GameObject previousTile;
    private int value;

    public int APCostFlat;

    // Use this for initialization
    void Start ()
    {
        getDataFromBase();
	}

    public int getAPCost(int adjacentTileID, float maxHeight)
    {
        float heightDifference = height - adjacentTilePathFinder[globalToLocalID(adjacentTileID)].height;

        if (heightDifference > maxHeight)
        {
            return int.MaxValue;
        }
        else
        {
            if (heightDifference == 0)
            {
                return APCostFlat;
            }
            else
            {
                if (heightDifference > 0)
                {
                    return (int)(heightDifference * 3);
                }
                else
                {
                    return (int)(heightDifference * -2);
                }
            }
        }
    }

    private int globalToLocalID(int globalID)
    {
        for (int i = 0; i < adjacentTilePathFinder.Length; i++)
        {
            if (adjacentTilePathFinder[i].getTileID() == globalID)
            {
                return i;
            }
        }

        return 0;
    }

    public void updateAdjacentTiles(float maxHeight)
    {
        if (adjacentTilePathFinder != null)
        {
            for (int i = 0; i < adjacentTilePathFinder.Length; i++)
            {
                int apCost = getAPCost(adjacentTilePathFinder[i].getTileID(), maxHeight);

                if ((adjacentTilePathFinder[i].getValue() > value + apCost) && (apCost != int.MaxValue))
                {
                    adjacentTilePathFinder[i].setValue(value + apCost);
                    adjacentTilePathFinder[i].setPreviousTile(gameObject);
                }
            }
        }
    }

    public GameObject getPreviousTile() { return previousTile; }
    public int getValue() { return value; }

    public void setPreviousTile(GameObject previousTile) { this.previousTile = previousTile; }
    public void setValue(int value) { this.value = value; }
}
