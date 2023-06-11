using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoatUIDamaged : MonoBehaviour
{
    [SerializeField] int damagedTime;
    [SerializeField] PlayerDeath playerDeath;
    [SerializeField] float rotateSpeed = 20;
    public bool damagedFlag;
    float damagedTimer;

    Image image;

    [SerializeField] Color32 normalColor;
    [SerializeField] Color32 damagedColor;
    void Start()
    {
        image = GetComponent<Image>();
        damagedTimer = 0;
        damagedFlag = false;
    }

    void Update()
    {
        if(damagedFlag)
        {
            damagedTimer += Time.deltaTime;
            if(damagedTimer >= damagedTime / 100.0f)
            {
                damagedTimer = 0;
                damagedFlag = false;
            }
        }
    }
	private void FixedUpdate()
	{
        if(playerDeath.deathFlag)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
        if(damagedFlag)
        {
            image.color = damagedColor;
        }
        else
        {
            image.color = normalColor;
        }
	}
}
