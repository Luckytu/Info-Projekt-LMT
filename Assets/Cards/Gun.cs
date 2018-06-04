using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Card
{
    private InputManager inputManager;

    private float range = 10f;
    private int damage = 50;

    private void Start()
    {
        unit = GetComponent<UnitController>();

        active = true;
        passive = false;

        actionPointCost = 4;

        inputManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<InputManager>();
    }

    private void Update()
    {
        activeBehaviour();
    }

    public override void startActiveBehaviour()
    {
        activeBehaviourActivated = !activeBehaviourActivated;
    }

    public override void activeBehaviour()
    {
        if(inputManager.getTargetUnit() != null)
        {
            float rangeToTarget = Vector3.Distance(unit.transform.position, inputManager.getTargetUnit().transform.position);

            if (activeBehaviourActivated && Input.GetMouseButtonDown(1) && rangeToTarget <= range)
            {
                inputManager.getTargetUnit().GetComponent<UnitController>().updateHealthPoints(-damage);
                unit.updateActionPoints(-actionPointCost);
                startActiveBehaviour();
                inputManager.getTargetUnit().unMarkThisUnitAsTarget();
                inputManager.setCardSelected(false);
            }
        }
    }

    public override void passiveBehaviour()
    {
        throw new System.NotImplementedException();
    }
}