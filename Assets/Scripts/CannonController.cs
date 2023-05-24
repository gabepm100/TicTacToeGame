using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;
    float maxPower = 30;
    float chargeSpeed = 5;
    bool spaceHeldDown = false;
    public GameObject Cannonball;
    public Transform ShotPoint;
    public GameManager Other;
    public float power=10;
    public Powerbar powerbar;
    public bool increase=true;
    void Start()
    {
        powerbar.SetHealth(0);
    }

    void Update()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = Input.GetAxis("Vertical");
        VerticalRotation=Mathf.Clamp(VerticalRotation, -90, 90);
        HorizontalRotation = Mathf.Clamp(HorizontalRotation, -90, 90);
        

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(-(VerticalRotation * rotationSpeed), HorizontalRotation * rotationSpeed, 0));
        if ((Input.GetKey(KeyCode.Space) && power <= maxPower)&&(increase==false))
        {
            
            spaceHeldDown = true;
            power += Time.deltaTime * chargeSpeed;
            powerbar.SetHealth(power);

            if (power > maxPower-1)
            {
                increase = true;
            }
        }
        else if((Input.GetKey(KeyCode.Space)&& power >= 0.1) && (increase==true)){
            power -= Time.deltaTime * chargeSpeed;
            spaceHeldDown = true;
            powerbar.SetHealth(power);
            if (power < 10)
            {
                increase = false;
            }
        }
        else if (spaceHeldDown)
        {
            launch();
            spaceHeldDown = false;
        }

    }
    public void HoldButton()
    {
        spaceHeldDown = true;
    }
    public void launch()
    {

        GameObject newCannonBall = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);

        newCannonBall.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * power;
        Other.NextTurn();

        spaceHeldDown = false;
        power = 10f;
    }
}
