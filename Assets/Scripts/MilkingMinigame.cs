using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class MilkingMinigame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject miniGame;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject keyA;   // A-Taste GameObject (leuchtet auf)
    [SerializeField] private GameObject keyD;   // D-Taste GameObject (leuchtet auf)
    AudioManager audioManager;

    [Header("Settings")]
    [SerializeField] private float inputWindow = 1.5f;  // Sekunden um die Taste zu drücken

    private bool expectingA = true;
    public bool active = true;
    private bool isFinished = false;
    private float windowTimer = 0f;
    private int finishedMilk = 0;
    private GoatDayBehaviour goatDayBehaviour;

    void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
        goatDayBehaviour = FindFirstObjectByType<GoatDayBehaviour>();
        if (goatDayBehaviour == null)
            Debug.LogError("No GoatDayBehaviour found in parent");
    } 

    void Start()
    {
        Reset();
    }

    void OnEnable()
    {
        if (text != null)
            Reset();
    }

    private void Reset()
    {
        isFinished = false;
        active = true;
        finishedMilk = 0;
        UpdateText();
        ShowNextKey();
    }

    void Update()
    {
        if (!active) return;

        // Timer pro Tastenfenster
        windowTimer -= Time.deltaTime;
        if (windowTimer <= 0f)
        {
            // Zeit abgelaufen → Fehler
            HandleWrongPress();
            return;
        }

        // Input prüfen
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            Debug.Log("A gedrückt");
            if (expectingA) HandleCorrectPress();
            else            HandleWrongPress();
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            Debug.Log("D gedrückt");
            if (!expectingA) HandleCorrectPress();
            else             HandleWrongPress();
        }
    }

    private void HandleCorrectPress()
    {
        audioManager.PlaySFX(audioManager.milking);
        finishedMilk += 20;
        UpdateText();

        if (finishedMilk >= 100)
        {
            EndGame();
            return;
        }

        expectingA = !expectingA;
        ShowNextKey();
    }

    private void HandleWrongPress()
    {
        finishedMilk = Mathf.Max(0, finishedMilk - 20);
        UpdateText();
        PauseMovement(8f);
    }

    private void ShowNextKey()
    {
        windowTimer = inputWindow;
        keyA.SetActive(expectingA);
        keyD.SetActive(!expectingA);
    }

    private void HideAllKeys()
    {
        keyA.SetActive(false);
        keyD.SetActive(false);
    }

    private void UpdateText()
    {
        text.text = $"Milch: {finishedMilk}% / 100%";
    }

    private void EndGame()
    {
        active = false;
        isFinished = true;
        HideAllKeys();
        text.text = "🥛 Fertig gemolken!";
        miniGame.SetActive(false);
        goatDayBehaviour.OnMilkingFinished();
    }

    public void PauseMovement(float durationSeconds)
    {
        if (durationSeconds <= 0f) return;
        StopAllCoroutines();
        StartCoroutine(PauseCoroutine(durationSeconds));
    }

    private IEnumerator PauseCoroutine(float duration)
    {
        active = false;
        HideAllKeys();
        yield return new WaitForSeconds(duration);
        active = true;
        ShowNextKey();
    }

    public bool GetStatus()
    {
        return isFinished;
    }
}
