using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSettings : MonoBehaviour
{

    [SerializeField]
    private GameObject cannonSettings;

    private bool isCannonSettingsEnaled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isCannonSettingsEnaled == true)
            {
                CannonSettingsDisabled();
            }
            else if(isCannonSettingsEnaled == false)
            {
                CannonSettingsEnabled();
            }
        }
    }

    void CannonSettingsDisabled()
    {
        cannonSettings.SetActive(false);
        isCannonSettingsEnaled = false;
    }

    void CannonSettingsEnabled()
    {
        cannonSettings.SetActive(true);
        isCannonSettingsEnaled = true;
    }
}
