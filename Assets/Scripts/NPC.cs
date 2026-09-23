using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Имя NPC")]
    public string npcName = "Незнакомец";

    [Header("Цвет кубика (плейсхолдер)")]
    public Color npcColor = Color.cyan;

    [Header("Строки диалога (по одной)")]
    [TextArea(2, 4)]
    public string[] dialogueLines = new string[]
    {
        "Привет...",
        "Я тебя помню."
    };

    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = npcColor;
        }
    }
}