using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;


public class MortgageCalculator : MonoBehaviour
{
    [SerializeField] TMP_InputField homePriceInput;
    [SerializeField] TMP_InputField downPaymentInput;
    [SerializeField] TextMeshProUGUI downPercentText;
    [SerializeField] TextMeshProUGUI PMIText;
    [SerializeField] TMP_InputField propertyTaxInput;
    [SerializeField] Slider aprRateSlider;
    [SerializeField] TextMeshProUGUI aprOutputText;
    [SerializeField] TextMeshProUGUI monthlyPaymentOutput;
    float homePrice;
    float downPayment;
    int loanTermMonths;
    int loanTermYears;

    public void CalculateDownPercent()
    {
        homePrice = float.Parse(homePriceInput.text);
        downPayment = float.Parse(downPaymentInput.text);
        float downpaymentPercent = downPayment / homePrice * 100;
        Debug.Log(downpaymentPercent);
        downPercentText.text = (Math.Floor(downpaymentPercent* 100 ) / 100).ToString("00.00")+  "% Down Payment";

        if (downpaymentPercent < 20f)
        {
            PMIText.text = "PMI Required";
        }
        else
        {
            PMIText.text = "PMI Not Required";
        }
    }

    public void SetApr()
    {
        aprOutputText.text = (aprRateSlider.value * .05f).ToString("0.00") + "%";
    }

    public void SetTerm(int termOption)
    {
        loanTermYears = termOption * 15;
        loanTermMonths = loanTermYears * 12;
    }

    public void CalculatePayments()
    {
        float monthlyTaxes = 0;
        float aprDecimal = aprRateSlider.value * .05f / 100;
        float monthlyInterest = aprDecimal / 12;
        

        if (!String.IsNullOrWhiteSpace(downPaymentInput.text))
        {
           downPayment = float.Parse(downPaymentInput.text);
        }

        if (!String.IsNullOrWhiteSpace(propertyTaxInput.text))
        {
            monthlyTaxes = float.Parse(propertyTaxInput.text) / 12;
        }

        double monthlyPayment = (homePrice - downPayment) *
            (monthlyInterest * (Math.Pow(1 + monthlyInterest, loanTermMonths) /
            (Math.Pow(1 + monthlyInterest, loanTermMonths) - 1))) + monthlyTaxes;
        monthlyPaymentOutput.text = monthlyPayment.ToString("C2", CultureInfo.CurrentCulture);
    }
}
