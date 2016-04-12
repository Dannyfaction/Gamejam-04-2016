using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SpeedDisplay : MonoBehaviour {

    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private Text speedText;
    private float speed;

    void Update () {
        speed = playerControl.Speed;
        speedText.text = speed + " KPH";
    }
}
