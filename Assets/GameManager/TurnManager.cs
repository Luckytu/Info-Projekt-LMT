using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private bool[] teamsAlive;
    private int teamCount;
    private List<UnitController> units;

	// Use this for initialization
	void Start ()
    {
        teamsAlive = new bool[1];

		for(int i = 0; i < teamsAlive.Length; i++)
        {
            teamsAlive[i] = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startNextTurn()
    {
        for(int i = 0; i < units.Count; i++)
        {
            units[i].resetActionPoints();
        }
    }

    public void addUnit(UnitController unit)
    {
        if(units == null)
        {
            units = new List<UnitController>();
        }

        units.Add(unit);
    } 

    public void killUnit(int unitID)
    {
        for(int i = 0; i < units.Count; i++)
        {
            if(units[i].getUnitID() == i)
            {
                units.RemoveAt(i);
                checkIfTeamIsDead(units[i].getTeam());
            }
        }
    }

    private void checkIfTeamIsDead(int teamID)
    {
        bool IsTeamDead = true;

        for(int i = 0; i < units.Count; i++)
        {
            if(units[i].getTeam() == teamID)
            {
                IsTeamDead = false;
            }
        }

        if(IsTeamDead)
        {
            teamCount--;
            if(teamCount <= 0)
            {
                checkWinner();
            }
        }
    }

    private void checkWinner()
    {
        for(int i = 0; i < teamsAlive.Length; i++)
        {
            if(teamsAlive[i] == true)
            {
                print("Player " + i + " wins");
            }
        }
    }
}