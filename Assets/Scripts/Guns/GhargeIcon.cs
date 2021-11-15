using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhargeIcon : MonoBehaviour
{
    public Image BackGround;
    public Image ForeGround;
    public Text Text;

    public void StartCharge()
    {
        BackGround.color = new Color(1, 1, 1, 0.2f);
        ForeGround.enabled = true;
        Text.enabled = true;
    }
    public void StopCharge()
    {
        BackGround.color = new Color(1, 1, 1, 1);
        ForeGround.enabled = false;
        Text.enabled = false;
    }
    public void SetChargeValue(float currentCharge,float maxCharge)
    {
        ForeGround.fillAmount = currentCharge / maxCharge;
        Text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}
