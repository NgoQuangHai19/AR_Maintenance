using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DisplayComponentController : MonoBehaviour
{
    public GameObject form;
    public GameObject MaintenanceInstruction;
    public MaintenanceInstructionController maintenanceInstructionController;
    public GameObject CreateButton;
    public GameObject EditButton;
    public GameObject DisplayButton;

    void Start() {
        DataControler.RootTracked += RootTracked;
        form.SetActive(false);
        MaintenanceInstruction.SetActive(false);
        CreateButton.SetActive(false);
        EditButton.SetActive(false);
        DisplayButton.SetActive(false);
    }

    void Update()
    {
        
    }

    private void RootTracked() {
        DisplayButton.SetActive(true);
    }

    public void DisplayButtonOnclick() {
        maintenanceInstructionController.OnDataReady();
        MaintenanceInstruction.SetActive(true);
        CreateButton.SetActive(true);
        EditButton.SetActive(true);
        DisplayButton.SetActive(false);
    }



}