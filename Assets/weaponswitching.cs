using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class weaponswitching : MonoBehaviour
{
    public int weapon = 0;
    // Start is called before the first frame update
    void Start()
    {

        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int prevweapon = weapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weapon >= transform.childCount - 1)
            {
                weapon = 0;
            }
            else
                weapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (weapon <= 0)
            {
                weapon = transform.childCount - 1;
            }
            else
                weapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapon = 3;
        }


        if (prevweapon == weapon && !gunbehaviour.reloadflag)
        {
           
            SelectWeapon();
        }
        

    }
    void SelectWeapon()
    {
       // gunbehaviour.shotsfired = 0;
        int i = 0;
        foreach (Transform Weapon in transform)
        {
           
            if (i == weapon)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
                Weapon.gameObject.SetActive(false);
            i++;
        }
    }

}
