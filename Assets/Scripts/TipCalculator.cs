using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;



public class TipCalculator : MonoBehaviour
{
    [SerializeField] TMP_InputField priceBeforeTip;
    [SerializeField] Toggle tenPercentTip;
    [SerializeField] Toggle fifteenPercentTip;
    [SerializeField] Toggle twentyPercentTip;
    [SerializeField] Slider customPercent;
    [SerializeField] TextMeshProUGUI customTipText;
    [SerializeField] TextMeshProUGUI tipAmountText;
    [SerializeField] float tipPercent;
    

    public void SetTipToTen()
    {
        if(tenPercentTip.isOn)
        {
            customPercent.value = 0;
            tipPercent = .10f;
            tenPercentTip.isOn = true;
            fifteenPercentTip.isOn = false;
            twentyPercentTip.isOn = false;
        }
    }

    public void SetTipToFifteen()
    {
        if (fifteenPercentTip.isOn)
        {
            customPercent.value = 0;
            tipPercent = .15f;
            tenPercentTip.isOn = false;
            fifteenPercentTip.isOn = true;
            twentyPercentTip.isOn = false;
        }
    }

    public void SetTipToTwenty()
    {
        if (twentyPercentTip.isOn)
        {
            customPercent.value = 0;
            tipPercent = .20f;
            tenPercentTip.isOn = false;
            fifteenPercentTip.isOn = false;
            twentyPercentTip.isOn = true;
        }
    }

    public void SetCustomTip(int sliderValue)
    {
        tenPercentTip.isOn = false;
        fifteenPercentTip.isOn = false;
        twentyPercentTip.isOn = false;
        customTipText.text = customPercent.value.ToString() + "%";
        tipPercent = customPercent.value / 100;
    }

    public void CalculateTip()
    {
        float tipAmount = float.Parse(priceBeforeTip.text) * tipPercent;
        tipAmountText.text = tipAmount.ToString("C2", CultureInfo.CurrentCulture);
    }
}
