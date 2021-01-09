using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZadrCharacter : Character
{
    public override int playerID => 2;

    public bool isSleeping = false;
    public void Sleep()
    {
        isSleeping = true;



        isSleeping = false;
    }
}
