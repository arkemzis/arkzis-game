using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Радиус взаимодействия")]
    public float interactRange = 3f;

    [Header("Кнопка взаимодействия")]
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        if (!Input.GetKeyDown(interactKey)) return;

        if (DialogUI.Instance != null && DialogUI.Instance.IsOpen)
        {
            DialogUI.Instance.NextLine();
            return;
        }

        NPC nearest = FindNearestNpc();
        if (nearest != null && DialogUI.Instance != null)
        {
            DialogUI.Instance.StartDialog(nearest);
        }
    }

    NPC FindNearestNpc()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactRange);
        NPC best = null;
        float bestDist = float.MaxValue;

        foreach (var hit in hits)
        {
            NPC npc = hit.GetComponentInParent<NPC>();
            if (npc == null) continue;

            float d = Vector3.Distance(transform.position, npc.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                best = npc;
            }
        }
        return best;
    }
}