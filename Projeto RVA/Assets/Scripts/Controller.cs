using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    // References from the objects (gates)
    public GameObject AND1;
    public GameObject AND2;
    public GameObject AND3;
    public GameObject OR1;
    public GameObject OR2;
    public GameObject OR3;
    public GameObject NOT1;
    public GameObject NOT2;
    public GameObject NOT3;

    // Reset flag
    private bool toReset = false;

    // Used when a new line is to be added
    static string newInputText = "";
    static string newInputGate = "";
    static string newOutputText = "";
    static string newOutputGate = "";

    // List containing information about the existing lines and connections
    List<Line> listOfLines = new List<Line>();

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        // Deletes every line in case toReset flag is set to true
        if (toReset)
        {
            foreach (var line in listOfLines)
            {
                // Makes all texts' visible and destroys each line's object
                line.inputText.enabled = true;
                line.outputText.enabled = true;
                Destroy(line.line);
            }

            newInputText = "";
            newOutputText = "";
            newInputGate = "";
            newOutputGate = "";

            listOfLines = new List<Line>();
            toReset = false;
        }

        // Check if there are any new lines to add
        // Only adds a connection between an input and an output (never between 2 inputs or 2 outputs)
        // And doesn't add the connection inside the same gate 
        // (i.e. you can't connect one of the gate's input to its own output and vice-versa)
        if (!newInputText.Equals("") && !newOutputText.Equals("") && !newInputGate.Equals(newOutputGate))
        {            
            // Create new line object
            GameObject newLine = new GameObject();
            newLine.AddComponent<LineRenderer>();
            LineRenderer lr = newLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.material.color = new Color32(255, 178, 102, 255);                   
            lr.startWidth = 0.005f;
            lr.endWidth = 0.005f;

            Line auxLine = new Line();
            auxLine.line = newLine;

            // Get references for the objects
            string[] auxLocation = newInputText.Split('_');
            PairTextButton auxPair = getGate(auxLocation[0], auxLocation[1]);
   
            auxLine.inputText = auxPair.text;
            auxLine.inputButton = auxPair.button; 

            auxLocation = newOutputText.Split('_');
            auxPair = getGate(auxLocation[0], auxLocation[1]);

            auxLine.outputText = auxPair.text;
            auxLine.outputButton = auxPair.button;

            // Makes texts' invisible
            auxLine.inputText.enabled = false;
            auxLine.outputText.enabled = false;

            listOfLines.Add(auxLine);

            newInputText = "";
            newOutputText = "";
            newInputGate = "";
            newOutputGate = "";
        }

        // Iterate every line/connection
        foreach (var line in listOfLines)
        {
            // Update each line's position
            GameObject auxLine = line.line;
            LineRenderer lr = auxLine.GetComponent<LineRenderer>();        
            lr.SetPosition(0, line.inputButton.transform.position);
            lr.SetPosition(1, line.outputButton.transform.position);

            // Update connection's values            
            line.inputText.text = line.outputText.text;
        }      
    }


    // Add new connection (input or output)
    // It doesn't allow connections between 2 inputs or 2 outputs
    public void add_new(string location, string type)
    {
        // Get gate's name
        string[] locationSplit = location.Split('_');

        if (type.Equals("in"))
        {
            newInputText = location;
            newInputGate = locationSplit[0];
        }
        else
        {
            newOutputText = location;
            newOutputGate = locationSplit[0];
        }
    }

    // This functions gets references for the gates and connections needed
    private PairTextButton getGate(string gate, string connection)
    {
        GameObject returnObject;
        // Gets the reference for the correct gate
        switch(gate)
        {
            case "AND1":
                returnObject = AND1;                
                break;
            case "AND2":
                returnObject = AND2;
                break;
            case "AND3":
                returnObject = AND3;
                break;
            case "OR1":
                returnObject = OR1;
                break;
            case "OR2":
                returnObject = OR2;
                break;
            case "OR3":
                returnObject = OR3;
                break;
            case "NOT1":
                returnObject = NOT1;
                break;
            case "NOT2":
                returnObject = NOT2;
                break;
            case "NOT3":
                returnObject = NOT3;
                break;
            default:
                Debug.Log("ERRO!");
                return new PairTextButton();
        }

        // Gets the correct input/output for the gate referenced above
        switch (connection)
        {
            case "input0":
                PairTextButton input0_auxReturn = new PairTextButton();

                GameObject t_input0 = returnObject.transform.Find("input0/Button/Text").gameObject;
                input0_auxReturn.text = t_input0.GetComponent<Text>();

                GameObject button_input0_c = returnObject.transform.Find("input0_c/Button").gameObject;
                input0_auxReturn.button = button_input0_c.GetComponent<Button>();

                return input0_auxReturn;
            case "input1":
                PairTextButton input1_auxReturn = new PairTextButton();

                GameObject t_input1 = returnObject.transform.Find("input1/Button/Text").gameObject;
                input1_auxReturn.text = t_input1.GetComponent<Text>();

                GameObject button_input1_c = returnObject.transform.Find("input1_c/Button").gameObject;
                input1_auxReturn.button = button_input1_c.GetComponent<Button>();

                return input1_auxReturn;
            case "output":
                PairTextButton output_auxReturn = new PairTextButton();

                GameObject t_output = returnObject.transform.Find("output/Text").gameObject;
                output_auxReturn.text = t_output.GetComponent<Text>();

                GameObject button_output_c = returnObject.transform.Find("output_c/Button").gameObject;
                output_auxReturn.button = button_output_c.GetComponent<Button>();

                return output_auxReturn;
            default:
                Debug.Log("ERRO!");
                return new PairTextButton();
        }
    }

    // Sets the reset flag as true so it resets every line in the next Update() call
    public void reset()
    {
        toReset = true;
    }
}

// Class used to store each line in the list of existing lines
public class Line
{
    public GameObject line;
    public Text inputText;
    public Text outputText;
    public Button inputButton;
    public Button outputButton;

    public Line() {}
}

// Class used in the getGate functions to return a Button reference and its respective Text
public class PairTextButton
{
    public Button button;
    public Text text;

    public PairTextButton() {}
}
