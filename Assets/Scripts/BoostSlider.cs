using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostSlider : MonoBehaviour
{
    public Movement movement;
    public Image fillImage;
    private float maxBoost;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        maxBoost = movement.boostAmount; 
    }

    private void Update()
    {
        float fillValue = movement.boostAmount / maxBoost;
        slider.value = fillValue;
    }
}
