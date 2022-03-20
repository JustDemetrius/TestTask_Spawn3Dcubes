using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UiController : MonoBehaviour
{
    [SerializeField] private CubeController cube;

    [Space]
    [SerializeField] private UiInputWindow spawnTimeSetter;
    [SerializeField] private TMP_InputField setterInputField;
    [SerializeField] private TextMeshProUGUI currentSpawnTime;

    [Space]
    [SerializeField] private Button spawnTimeButton;
    [SerializeField] private Button checkButton;

    [Space]
    [SerializeField] private Slider SpeedSlider;
    [SerializeField] private Slider DistanceSlider;


    private void Awake()
    {
        spawnTimeButton.onClick.AddListener(spawnTimeSetter.Show);
        checkButton.onClick.AddListener(ChangeSpawnTime);
    }
    private void Start()
    {
        SpeedSlider.value = cube.Speed;
        DistanceSlider.value = cube.Distance;
    }
    private void Update()
    {
        cube.Speed = SpeedSlider.value;
        cube.Distance = DistanceSlider.value;
    }
    private void ChangeSpawnTime()
    {
        Convert.ToInt32(setterInputField.text);
        if (Convert.ToUInt32(setterInputField.text) != 0)
        {
            cube.SpawnTimer = Convert.ToUInt32(setterInputField.text);
        }
        else
        {
            Debug.Log("Бесконечность не предел?");
        }

        currentSpawnTime.text = $"Cube every {cube.SpawnTimer} sec.";
        spawnTimeSetter.Hide();
    }
}
