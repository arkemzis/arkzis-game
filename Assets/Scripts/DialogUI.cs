using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    public static DialogUI Instance;

    [Header("UI элементы")]
    public GameObject panel;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI lineText;

    private NPC currentNpc;
    private int currentLineIndex = 0;

    public bool IsOpen => currentNpc != null;

    void Awake()
    {
        Instance = this;
        if (panel != null) panel.SetActive(false);
    }

    public void StartDialog(NPC npc)
    {
        if (npc == null || npc.dialogueLines == null || npc.dialogueLines.Length == 0)
            return;

        currentNpc = npc;
        currentLineIndex = 0;
        if (panel != null) panel.SetActive(true);
        ShowCurrentLine();
    }

    public void NextLine()
    {
        if (currentNpc == null) return;

        currentLineIndex++;
        if (currentLineIndex >= currentNpc.dialogueLines.Length)
        {
            CloseDialog();
        }
        else
        {
            ShowCurrentLine();
        }
    }

    public void CloseDialog()
    {
        currentNpc = null;
        currentLineIndex = 0;
        if (panel != null) panel.SetActive(false);
    }

    void ShowCurrentLine()
    {
        if (nameText != null) nameText.text = currentNpc.npcName;
        if (lineText != null) lineText.text = currentNpc.dialogueLines[currentLineIndex];
    }
}