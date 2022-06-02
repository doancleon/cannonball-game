using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonballWind : MonoBehaviour
{
    //Edwin Aguirre / Used a YouTube Tutorial for part of this!!

    private List<Rigidbody> CannonballsInWindZoneList = new List<Rigidbody>();

    [SerializeField]
    private Vector3 randomWindDirection;

    private Vector3 windDirection;

    [SerializeField]
    private float windStrength = 5f;

    [SerializeField]
    private Text windText;

    private bool isRandomButtonEnabled = false;

    [SerializeField]
    private GameObject NorthButtonHighlight;
    [SerializeField]
    private GameObject NorthEastButtonHighlight;
    [SerializeField]
    private GameObject EastButtonHighlight;
    [SerializeField]
    private GameObject SouthEastButtonHighlight;
    [SerializeField]
    private GameObject SouthButtonHighlight;
    [SerializeField]
    private GameObject SouthWestButtonHighlight;
    [SerializeField]
    private GameObject WestButtonHighlight;
    [SerializeField]
    private GameObject NorthWestButtonHighlight;
    [SerializeField]
    private GameObject randomButtonHighlight;

    private void Update() 
    {
        //Randomizes the values for the wind
        randomWindDirection = new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 0f), Random.Range(-5f, 5f));

        //Sets the wind strength to the text above slider
        windText.text = "Wind: " + windStrength + " mph";

        //This is so that when the random button is pressed, it continues to update the values
        if(isRandomButtonEnabled == true)
        {
            RandomWindDirection();
        }
    }

    //When the cannonball enters the trigger zone, wind will be applied.
    private void OnTriggerEnter(Collider other) 
    {
        Rigidbody cannonball = other.gameObject.GetComponent<Rigidbody>();

        if(cannonball != null)
        {
            CannonballsInWindZoneList.Add(cannonball);
        }
    }

    //When the cannonball exits the trigger zone, wind will not be applied.
    private void OnTriggerExit(Collider other) 
    {
        Rigidbody cannonball = other.gameObject.GetComponent<Rigidbody>();

        if(cannonball != null)
        {
            CannonballsInWindZoneList.Remove(cannonball);
        }
    }

    //Checks to see if a cannonball is inside the trigger zone
    private void FixedUpdate() 
    {
        if(CannonballsInWindZoneList.Count > 0)
        {
            foreach (Rigidbody rigidbody in CannonballsInWindZoneList)
            {
                    Debug.Log("cannon");
                    rigidbody.AddForce(windDirection * windStrength);
              
            }
        }
    }

    //Changes the wind strength based on the slider value
    public void AdjustWind(float newWind)
    {
        windStrength = newWind;
    }

    //Random Wind Button
    public void RandomWindDirection()
    {
        windDirection = randomWindDirection;
        isRandomButtonEnabled = true;
        randomButtonHighlight.SetActive(true);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //North Wind Button
    public void NorthWindDirection()
    {
        windDirection = Vector3.forward;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(true);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //North East Wind Button
    public void NorthEastWindDirection()
    {
        windDirection = Vector3.forward + Vector3.right;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(true);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //East Wind Button
    public void EastWindDirection()
    {
        windDirection = Vector3.right;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(true);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //South East Wind Button
    public void SouthEastWindDirection()
    {
        windDirection = Vector3.back + Vector3.right;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(true);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //South Wind Button
    public void SouthWindDirection()
    {
        windDirection = Vector3.back;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(true);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //South West Wind Button
    public void SouthWestWindDirection()
    {
        windDirection = Vector3.back + Vector3.left;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(true);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(false);
    }

    //West Wind Button
    public void WestWindDirection()
    {
        windDirection = Vector3.left;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(true);
        NorthWestButtonHighlight.SetActive(false);
    }

    //North West Wind Button
    public void NorthWestWindDirection()
    {
        windDirection =  Vector3.forward + Vector3.left;
        isRandomButtonEnabled = false;
        randomButtonHighlight.SetActive(false);
        NorthButtonHighlight.SetActive(false);
        NorthEastButtonHighlight.SetActive(false);
        EastButtonHighlight.SetActive(false);
        SouthEastButtonHighlight.SetActive(false);
        SouthButtonHighlight.SetActive(false);
        SouthWestButtonHighlight.SetActive(false);
        WestButtonHighlight.SetActive(false);
        NorthWestButtonHighlight.SetActive(true);
    }
}
