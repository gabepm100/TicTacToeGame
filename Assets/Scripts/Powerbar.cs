using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour
{
    public Slider slider;

    // Update is called once per frame

    public void SetHealth(float health) => slider.value = health;
}
