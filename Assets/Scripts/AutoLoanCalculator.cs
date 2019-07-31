using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;


public class AutoLoanCalculator : MonoBehaviour
{
    [SerializeField] TMP_InputField vehiclePriceInput;
    [SerializeField] TMP_InputField downpaymentInput;
    [SerializeField] Slider taxSlider;
    [SerializeField] TextMeshProUGUI taxSliderOutput; 
    [SerializeField] Slider aprSlider;
    [SerializeField] TextMeshProUGUI aprSliderOutput;
    [SerializeField] TextMeshProUGUI monthlyPaymentOutput;
    [SerializeField] TextMeshProUGUI financeChargeOutput;
    [SerializeField] TextMeshProUGUI totalCostOutput;
    int loanTermMonths;
    int loanTermYears;

    public void SetSalesTax()
    {
        float taxSliderTemp = taxSlider.value * .1f;
        taxSliderOutput.text = taxSliderTemp.ToString("0.00") + "%";
    }

    public void SetApr()
    {
        float aprSliderTemp = aprSlider.value * .25f;
        aprSliderOutput.text = aprSliderTemp.ToString("0.00") + "%";
    }

    public void CalculatePayments()
    {
        float downPayment = 0;
        float taxDecimal = taxSlider.value * .1f / 100;
        float aprDecimal = aprSlider.value * .25f / 100;
        float vehiclePrice = float.Parse(vehiclePriceInput.text.Replace(",", "").Replace("$", ""));
        float monthlyInterest = aprDecimal / 12;
        Debug.Log(taxDecimal);
        Debug.Log(aprDecimal);
        Debug.Log(loanTermMonths);
        Debug.Log(loanTermYears);




        if (!String.IsNullOrWhiteSpace(downpaymentInput.text))
        {
            downPayment = float.Parse(downpaymentInput.text.Replace(",", "").Replace("$", ""));
        }

        double monthlyPayment = ((vehiclePrice * (1 + taxDecimal)) - downPayment) * 
            (monthlyInterest *(Math.Pow((1 + monthlyInterest), loanTermMonths) / 
            (Math.Pow((1 + monthlyInterest), loanTermMonths) - 1)));

        monthlyPaymentOutput.text = monthlyPayment.ToString("C2", CultureInfo.CurrentCulture);
        totalCostOutput.text = ((monthlyPayment * loanTermMonths) + downPayment).ToString("C2", CultureInfo.CurrentCulture);
        financeChargeOutput.text = ((monthlyPayment * loanTermMonths) - 
            (vehiclePrice * (1 + taxDecimal)) + downPayment).ToString("C2", CultureInfo.CurrentCulture);
    }

    public void SetTerm(int termOption)
    {
        loanTermMonths = termOption * 12;
        loanTermYears = termOption;
    }
    
        //Changes Input Fields into currenty when the edit is done.
   public void ChangeToCurrency(TMP_InputField inputField )
   {
        inputField.text = float.Parse(inputField.text).ToString("C2");
   }
}
