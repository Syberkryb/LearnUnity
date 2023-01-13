using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileAnimal : Animal, IHostileAnimal
{
    public override string GetName()
    {
        return _name;
    }
}
