using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTargets : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text targetStrength;
    [SerializeField] private float tStrength;

    [SerializeField] private Text massText;
    [SerializeField] private float cannonMass;
    [SerializeField] private Text powerText;
    [SerializeField] private float power;
    public Explosion prefab;
    void Start()
    {
        spawnTargets();
    }

    public void spawnTargets()
    {
        float y = 0;
        for (var x = 0; x < 5; x++)
        {
            y = x*5.0f;
            for (var i = 0; i < 10; i++)
            {
                Instantiate(prefab, new Vector3(i * 5.0f, y, 0), Quaternion.identity);
                prefab.targetStrength = targetStrength;
                prefab.tStrength = tStrength;
                prefab.massText = massText;
                prefab.cannonMass = cannonMass;
                prefab.powerText = powerText;
                prefab.power = power;
                prefab.speed = Random.Range(1f, 2f);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        targetStrength.text = "Target Strength: " + tStrength;

    }

    public void targetAdjust(float newStrength)
    {
        tStrength = newStrength;
    }
    public void powerAdjust(float newPower)
    {
        power = newPower;
    }
    public void massAdjust(float newMass)
    {
        cannonMass = newMass;
    }
}
