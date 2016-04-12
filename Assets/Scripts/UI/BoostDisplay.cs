using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BoostDisplay : MonoBehaviour {

    [SerializeField] private PlayerControl playerControl;
    private float boostLeft;
    [SerializeField] private List<Sprite> sprites;
    private Image boostImage;


    // Use this for initialization
    void Start () {
        boostImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        boostLeft = playerControl.BoostLeft;
        int boostValueInt = (int)boostLeft;
        switch (boostValueInt)
        {
            case 1:
                boostImage.sprite = sprites[1];
                break;
            case 2:
                boostImage.sprite = sprites[2];
                break;
            case 3:
                boostImage.sprite = sprites[3];
                break;
            case 4:
                boostImage.sprite = sprites[4];
                break;
            case 5:
                boostImage.sprite = sprites[5];
                break;
            default:
                boostImage.sprite = sprites[0];
                break;
        }
	}
}
