using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float cadencia;
    public float damage;
    public enum typeweapon
    {
        Pistol,
        Rifle,
    }
    public typeweapon type;
}
