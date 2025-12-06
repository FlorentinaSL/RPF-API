using LabApi.Features.Wrappers;
using UnityEngine;

namespace RPF_API.API.CustomPet;

public class behavior : MonoBehaviour
{
    public Player targetPlayer;      
    public float followSpeed = 5f;   
    public float followHeight = 1.5f;
    private Vector3 _velocity = Vector3.zero;
    private void Update()
    {
        if (targetPlayer == null)
            return;

        Vector3 targetPos = new Vector3(
            targetPlayer.Position.x,
            targetPlayer.Position.y + followHeight,
            targetPlayer.Position.z
        );
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, 0.2f);
        transform.LookAt(targetPlayer.Position);
    }
}