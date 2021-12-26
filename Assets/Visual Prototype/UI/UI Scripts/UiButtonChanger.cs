using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButtonChanger : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    public Sprite originalButtonImage;
    private bool isOriginal = true;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
	}

    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;

        button.image.sprite = originalButtonImage;

        if (isOriginal)
        {

            button.image.sprite = newButtonImage;
            isOriginal = false;

        }

        else
        {

            button.image.sprite = originalButtonImage;
            isOriginal = true;

        }
    }
}
