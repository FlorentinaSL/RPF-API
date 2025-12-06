using LabApi.Features.Wrappers;
using ProjectMER.Features.Objects;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace RPF_API.API._035Event;

public class behavior : MonoBehaviour
{
    public SchematicObject maskRoot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ReferenceHub hub))
        {
            Player player = Player.Get(hub);
            if (player != null)
            {
                Logger.Info($"[RPF - API Schematic]: {player.Nickname} ha toccato scp-035!, mettendo la maschera in faccia...");
                player.SendHint("Hai indossato SCP-035!", 10);
                if (maskRoot != null)
                {
                    maskRoot.Destroy();
                    maskRoot = null;
                }
                Transform head = player.GameObject.transform.Find("PlayerCamera");
                if (head == null) return;
                foreach (var block in EventMask.CurrentMask.AttachedBlocks)
                {
                    var go = block.gameObject;
                    go.transform.SetParent(head);
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localRotation = Quaternion.identity;
                }
            }
        }
    }
}