using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    protected UnitController unit;

    protected int actionPointCost;

    protected bool active;
    protected bool passive;
    
    protected bool activeBehaviourActivated = false;

    public abstract void activeBehaviour();
    public abstract void startActiveBehaviour();
    public abstract void passiveBehaviour();

    public void setUnit(UnitController unit)
    {
        this.unit = unit;
    }

    public bool isActiveBehaviourActivated() { return activeBehaviourActivated; }
    public bool isPassive() { return passive; }
    public bool isActive() { return active; }
}
