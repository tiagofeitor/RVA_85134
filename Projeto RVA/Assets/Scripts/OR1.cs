using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OR1 : MonoBehaviour
{
    public Controller Controller;
    public GameObject OR;

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
        button_input0 = OR.transform.Find("input0/Button").gameObject;
        button_input0.GetComponent<Button>().onClick.AddListener(input0_OnClick);

        button_input1 = OR.transform.Find("input1/Button").gameObject;
        button_input1.GetComponent<Button>().onClick.AddListener(input1_OnClick);

        button_input0_c = OR.transform.Find("input0_c/Button").gameObject;
        button_input0_c.GetComponent<Button>().onClick.AddListener(input0_c_OnOnClick);

        button_input1_c = OR.transform.Find("input1_c/Button").gameObject;
        button_input1_c.GetComponent<Button>().onClick.AddListener(input1_c_OnOnClick);

        button_output_c = OR.transform.Find("output_c/Button").gameObject;
        button_output_c.GetComponent<Button>().onClick.AddListener(output_c_OnOnClick);

        // Get Texts' references
        GameObject t_input0 = OR.transform.Find("input0/Button/Text").gameObject;
        text_input0 = t_input0.GetComponent<Text>();

        GameObject t_input1 = OR.transform.Find("input1/Button/Text").gameObject;
        text_input1 = t_input1.GetComponent<Text>();

        GameObject t_output0 = OR.transform.Find("output/Text").gameObject;
        text_output0 = t_output0.GetComponent<Text>();
    }

    // Click functions to add a new reference
    public void input0_c_OnOnClick()
    {
        Controller.add_new("OR1_input0", "in");
    }

    public void input1_c_OnOnClick()
    {
        Controller.add_new("OR1_input1", "in");
    }

    public void output_c_OnOnClick()
    {
        Controller.add_new("OR1_output", "out");
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
        if (text_input0.text.Equals("1") || text_input1.text.Equals("1"))
        {
            text_output0.text = "1";
        }
        else 
        {
            text_output0.text = "0";
        }
    }
}


