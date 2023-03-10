using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AND2 : MonoBehaviour
{
    public Controller Controller;
    public GameObject AND;

    private GameObject button_input0_c;
    private GameObject button_input1_c;
    private GameObject button_output_c;
    private GameObject button_input0;
    private GameObject button_input1;
    private Text text_input0;
    private Text text_input1;
    private Text text_output0;

    // Start is called before the first frame update
    void Start()
    {
        // Create all objects
        // Create buttons' listeners
        button_input0 = AND.transform.Find("input0/Button").gameObject;
        button_input0.GetComponent<Button>().onClick.AddListener(input0_OnClick);

        button_input1 = AND.transform.Find("input1/Button").gameObject;
        button_input1.GetComponent<Button>().onClick.AddListener(input1_OnClick);

        button_input0_c = AND.transform.Find("input0_c/Button").gameObject;
        button_input0_c.GetComponent<Button>().onClick.AddListener(input0_c_OnOnClick);

        button_input1_c = AND.transform.Find("input1_c/Button").gameObject;
        button_input1_c.GetComponent<Button>().onClick.AddListener(input1_c_OnOnClick);

        button_output_c = AND.transform.Find("output_c/Button").gameObject;
        button_output_c.GetComponent<Button>().onClick.AddListener(output_c_OnOnClick);

        // Get Texts' references
        GameObject t_input0 = AND.transform.Find("input0/Button/Text").gameObject;
        text_input0 = t_input0.GetComponent<Text>();

        GameObject t_input1 = AND.transform.Find("input1/Button/Text").gameObject;
        text_input1 = t_input1.GetComponent<Text>();

        GameObject t_output0 = AND.transform.Find("output/Text").gameObject;
        text_output0 = t_output0.GetComponent<Text>();
    }

    // Click functions to add a new reference
    public void input0_c_OnOnClick()
    {
        Controller.add_new("AND2_input0", "in");
    }

    public void input1_c_OnOnClick()
    {
        Controller.add_new("AND2_input1", "in");
    }

    public void output_c_OnOnClick()
    {
        Controller.add_new("AND2_output", "out");
    }

    public void input0_OnClick()
    {
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
        if (text_input1.text.Equals("0"))
        {
            text_input1.text = "1";
        }
        else
        {
            text_input1.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate output
        string output = (int.Parse(text_input0.text) * int.Parse(text_input1.text)).ToString();

        text_output0.text = output;
    }
}


