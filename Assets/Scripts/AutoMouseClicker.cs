using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AutoMouseClicker : MonoBehaviour
{
    public Button startBtn, stopBtn;
    public TMP_InputField interval;
    // Start is called before the first frame update
    void Start()
    {
        //interval.text = 5.ToString();
        interval.interactable = true;
        startBtn.interactable = true;
        stopBtn.interactable = false;
    }
    public void StartAutoClick()
    {
        interval.interactable = false;
        startBtn.interactable = false;
        stopBtn.interactable = true;
        InvokeRepeating("ScreenAwake", 1, float.Parse(interval.text));
    }
    private void ScreenAwake()
    {
        print("Auto Mouse clicked!!!");
        SimulateMouseClick();
    }
    private void SimulateMouseClick()
    {
        WindowsInput.Tests.InputSimulatorExamples a = new WindowsInput.Tests.InputSimulatorExamples();
        a.SimulateMouseClick();
    }
    public void Stop()
    {
        CancelInvoke("ScreenAwake");
        interval.interactable = true;
        startBtn.interactable = true;
        stopBtn.interactable = false;
    }

    public void Quit()
    {
        print("application quit");
        CancelInvoke("ScreenAwake");
        Application.Quit();
    }
    private void OnApplicationQuit()
    {
        print("application quit");
        CancelInvoke("ScreenAwake");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (interval.interactable)
        {
            if (interval.text == "")
            {
                startBtn.interactable = false;
            }
            else
            {
                startBtn.interactable = true;
            }
        }
    }
}
