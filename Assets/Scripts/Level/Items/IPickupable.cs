using System;
using UnityEngine;

public interface IPickupable
{
    bool isPickuped { get; set; }
    bool canPickup { get; }
    Transform transform { get; }
    event Action wakeUp;
}
