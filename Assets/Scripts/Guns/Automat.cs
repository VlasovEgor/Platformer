using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{ [Space(15)]
    public int NumberOfBullets;
    public Text BulletText;
    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        base.Shot();
        NumberOfBullets--;
        UpdateText();
        if (NumberOfBullets==0)  PlayerArmory.TakeGunByIndex(0);
    }
    public override void Activate()
    {
        base.Activate();
        UpdateText();
        BulletText.enabled = true;
    }
    public override void Deactivete()
    {
        base.Deactivete();
        BulletText.enabled = false;
    }

    void UpdateText()
    {
        BulletText.text = "Пули: " + NumberOfBullets.ToString();
    }

    public override void AddBullets(int nubmerOfBullets)
    {
        base.AddBullets(nubmerOfBullets);
        NumberOfBullets += nubmerOfBullets;
        UpdateText();
        PlayerArmory.TakeGunByIndex(1);
    }
}
