using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Card
{
    private InputManager inputManager;

    private float range = 10f;
    private int damage = 6;

    private void Start()
    {
        active = true;
        passive = false;

        //inputManager = GameObject.Find("GameManger").GetComponent<InputManager>();
    }

    private void Update()
    {
        
    }

    public override void activeBehaviour()
    {
        Vector3 origin = unit.GetComponentInChildren<BoxCollider>().transform.position;
        Vector3 hit = inputManager.getTargetUnit().transform.position;
    }

    public override void passiveBehaviour()
    {
        throw new System.NotImplementedException();
    }
}