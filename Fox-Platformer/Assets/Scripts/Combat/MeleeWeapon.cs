using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class MeleeWeapon : MonoBehaviour
{
    public int damage;
    public bool ranged;
    public Collider2D collider2d;
    public float cooldown = .2f;
    bool hasSlashed = false;
    bool canAttack = true;

    private void Awake()
    {
        //set stats based off scriptable object
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsPointerOverObject() == false && canAttack == true)
        {
            //set collider to true
            collider2d.enabled = true;
            //play animation
            this.GetComponent<Animator>().SetBool("isSlashing", true);
            //play sound
            this.GetComponent<AudioSource>().Play();
            //start coroutine to set collider back to false after the animation is finished
            StartCoroutine(SetFalse());
            FindObjectOfType<AudioManager>().Play("SwordSwing");
            canAttack = false;
            StartCoroutine(CooldownCharge());
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Enemy" || other.tag == "Boss" && hasSlashed == false)
        {
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            hasSlashed = true;
        }
    }

    public IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(cooldown);
        this.GetComponent<Animator>().SetBool("isSlashing", false);
        collider2d.enabled = false;
        hasSlashed = false;
    }

    public bool IsPointerOverObject()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == true)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public IEnumerator CooldownCharge ()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
