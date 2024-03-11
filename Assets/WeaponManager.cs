using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int currentIndex;
    public GameObject[] weapons;
    public bool inactive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (inactive== true)
        {
            //return nos servirá para cortar la ejecución aquí siempre y cuando inactive sea true
            return;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0) { 
            ChangeWeapon(scroll);
        }
    }
    public void ChangeWeapon(float scrollDirection)
    {
        if (scrollDirection > 0) {

            currentIndex++;

            if (currentIndex >= weapons.Length) { 

                currentIndex = 0;
            }
        }
        
        else if (scrollDirection < 0) {


            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = weapons.Length-1;
            }


        }
        ActivateWeapon(currentIndex);
    }
    public void ActivateWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i==index);
        }
    }
}
