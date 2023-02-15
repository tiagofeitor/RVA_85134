# RVA_85134
Project from Virtual and Augmented Reality class

Images used for Vuforia markers are in ProjetoRVA/Assets/Editor/Vuforia/ImageTargetTextures/VuforiaMarkers
Main controller C# script Projeto RVA\Assets\Scripts

This project lets users build a simple logic circuit and connect the gates between themselves and change the inputs to see how the outputs change.
This app uses a limited amount of logical gates (AND, OR and NOT) so the user can mount a simple logical circuit.

When the phone camera detects a marker it creates a simple 3D model of it, rendering it using Unity and adding the respective buttons to the inputs and letting the user connect the gates between themselves with the circuit being left to right orientation.
After the gates being connected with lines, the user can change the inputs on the gates (0 or 1) to change the output shown. The user can reset the circuit to delete the lines and start over.

