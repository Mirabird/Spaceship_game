using System;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Image damageEffect;
    public float damageAlpha = 0.25f;

    public static UIController instance;
    private void Awake()
    {
        instance = this;
    }
    
    public void ShowDamage()
    {
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, damageAlpha);
    }
}
