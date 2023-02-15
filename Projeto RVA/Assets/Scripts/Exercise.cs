using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Exercise : MonoBehaviour
{
    public GameObject Gate;

    private GameObject button_input0;
    private GameObject button_input1;
    private GameObject button_input2;
    private Text text_input0;
    private Text text_input1;
    private Text text_input2;
    private Text text_output0;
    private Text text_output1;
    private Text text_output2;

    // Start is called before the first frame update
    void Start()
    {
        // Create all objects
        // Create buttons' listeners
        button_input0 = Gate.transform.Find("input0/Button").gameObject;
        button_input0.GetComponent<Button>().onClick.AddListener(input0_OnClick);

        button_input1 = Gate.transform.Find("input1/Button").gameObject;
        button_input1.GetComponent<Button>().onClick.AddListener(input1_OnClick);

        button_input2 = Gate.transform.Find("input2/Button").gameObject;
        button_input2.GetComponent<Button>().onClick.AddListener(input2_OnClick);

        // Get Texts' references
        GameObject t_input0 = Gate.transform.Find("input0/Button/Text").gameObject;
        text_input0 = t_input0.GetComponent<Text>();

        GameObject t_input1 = Gate.transform.Find("input1/Button/Text").gameObject;
        text_input1 = t_input1.GetComponent<Text>();

        GameObject t_input2 = Gate.transform.Find("input2/Button/Text").gameObject;
        text_input2 = t_input2.GetComponent<Text>();

        GameObject t_output0 = Gate.transform.Find("output0/Text").gameObject;
        text_output0 = t_output0.GetComponent<Text>();

        GameObject t_output1 = Gate.transform.Find("output1/Text").gameObject;
        text_output1 = t_output1.GetComponent<Text>();

        GameObject t_output2 = Gate.transform.Find("output2/Text").gameObject;
        text_output2 = t_output2.GetComponent<Text>();
    }

     public void input0_OnClick()
    {
        Debug.Log("ENTREI0");
        if (text_input0.text.Equals("0"))
        {
            text_input0.text = "1";
        }
        else
        {
            text_input0.text = "0";
        }
    }

    public void input1_OnClick()
    {
        Debug.Log("ENTREI1");
        if (text_input1.text.Equals("0"))
        {
            text_input1.text = "1";
        }
        else
        {
            text_input1.text = "0";
        }
    }

    public void input2_OnClick()
    {
        Debug.Log("ENTREI2");
        if (text_input2.text.Equals("0"))
        {
            text_input2.text = "1";
        }
        else
        {
            text_input2.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate output
        string A_and_B = (int.Parse(text_input0.text) * int.Parse(text_input1.text)).ToString();
        Debug.Log("A_and_B=" + A_and_B);
        Debug.Log("C=" + text_input2.text);
        string output; 
        
        if (!A_and_B.Equals(text_input2.text))
        {
            output = "1";
        }
        else
        {
            output = "0";
        }

        text_output0.text = output;
        text_output1.text = output;
        text_output2.text = output;
    }
}


