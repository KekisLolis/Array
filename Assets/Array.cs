using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Array : MonoBehaviour
{
    public TMP_InputField result;
    public TMP_InputField input;
    public Button addButton;
    public Button generateButton;
    public Button maxButton;
    public Button minButton;
    public Button negativeSumButton;
    public Button clearButton;
    
    private List<int> numbers = new();
    void Start()
    {
        addButton.onClick.AddListener(AddToList);
        generateButton.onClick.AddListener(GenerateList);
        maxButton.onClick.AddListener(FindMaxValue);
        minButton.onClick.AddListener(FindMinEven);
        negativeSumButton.onClick.AddListener(FindNegativeSum);
        clearButton.onClick.AddListener(ClearList);
    }
    
    private void UpdateResult()
    {
        result.text = "";
        foreach (int number in numbers)
        {
            result.text += number + ", ";
        }
    }
    
    private void AddToList()
    {
        int number = int.Parse(input.text);
        numbers.Add(number);
        input.text = "";
        UpdateResult();
    }
    
    private void GenerateList()
    {
        int size;
        if (int.TryParse(input.text, out size))
        {
            for (int i = 0; i < size; i++)
            {
                int number = Random.Range(-100, 100);
                numbers.Add(number);
            }
        }
        input.text = "";
        UpdateResult();
    }
    
    private void FindMaxValue()
    {
        int max = int.MinValue;
        int maxIndex = -1;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
                maxIndex = i;
            }
        }
        
        if (maxIndex != -1)
        {
            result.text = "Max: " + max + ", index: " + maxIndex;
        }
        else
        {
            result.text = "No max value found.";
        }
    }
    
    private void FindMinEven()
    {
        int minEven = int.MaxValue;
        int minIndex = -1;
        
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0 && numbers[i] < minEven)
            {
                minEven = numbers[i];
                minIndex = i;
            }
        }
        
        if (minIndex != -1)
        {
            result.text = "Min Even: " + minEven + ", index: " + minIndex;
        }
        else
        {
            result.text = "No min even numbers found.";
        }
    }
    
    private void FindNegativeSum()
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            if (number < 0)
            {
                sum += number;
            }
        }
        result.text = "Negative sum: " + sum;
    }
    
    private void ClearList()
    {
        input.text = "";
        numbers.Clear();
        UpdateResult();
    }
}
