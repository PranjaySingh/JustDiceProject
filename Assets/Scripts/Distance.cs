using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Distance : MonoBehaviour
{
    public GameObject player;

    int distanceText;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        distanceText = (int)player.transform.position.z;
        text.text = distanceText.ToString();                        //set distance text in run time
    }
}
