﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Card[] cards;

    public int team;
    private int unitID;

    private int level;
    private int experiencePoints;
    private int healthPoints;
    public int actionPoints;
    public int maxActionPoints;
    private int cardPoints;
    public float maxHeight;

	// Use this for initialization
	void Start ()
    {
        cards = new Card[6];

        gameObject.AddComponent<Armour>();
        gameObject.AddComponent<Gun>();

        cards = gameObject.GetComponents<Card>();

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].setUnit(this);

            if (cards[i].isPassive())
            {
                cards[i].passiveBehaviour();
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void resetActionPoints()
    {
        actionPoints = maxActionPoints;
    }

    public void updateActionPoints(int actionPoints)
    {
        this.actionPoints += actionPoints; 
    }

    public void updateHealthPoints(int healthPoints)
    {
        this.healthPoints += healthPoints;

        if(this.healthPoints <= 0)
        {

        }
    }

    public void setTeam(int team) { this.team = team; }
    public int getTeam() { return team; }

    public void setUnitID(int unitID) { this.unitID = unitID; }
    public int getUnitID() { return unitID; }

    public void addHealthPoints(int healthPoints) { this.healthPoints += healthPoints; }

    public int getActionPoints() { return actionPoints; }
    public float getMaxHeight() { return maxHeight; }
}
