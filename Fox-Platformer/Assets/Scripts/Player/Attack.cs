using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //DONT USE
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
            //set collider to true
            weapon.GetComponent<MeleeWeapon>().GetComponent<Collider>().enabled = true;
            //play animation

            //start coroutine to set collider back to false after the animation is finished
            StartCoroutine(SetFalse());
        }
    }

    public IEnumerator SetFalse ()
    {
        yield return new WaitForSeconds(.75f);
        weapon.GetComponent<MeleeWeapon>().GetComponent<Collider>().enabled = false;
    }
}
