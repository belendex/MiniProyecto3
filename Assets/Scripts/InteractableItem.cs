using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    public GameObject ObjetoEncendido;

   
    public enum typeItem
    {
        Gun,
        SoldierTuto,
        PCtuto,
        EndGame,
        Nave,
    }
    
     public typeItem item;
   
    
}
