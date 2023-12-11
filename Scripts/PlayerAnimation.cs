using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string IS_WALKING = "isWalking";

    [SerializeField] private Player player;

    private Animator animator;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        
        // Jika player tidak diinisialisasi, coba mencarinya secara otomatis
        if (player == null)
        {
            player = GetComponentInParent<Player>(); // Gantilah dengan metode yang sesuai jika diperlukan
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Periksa apakah player null sebelum menggunakan IsWalking
        if (player != null)
        {
            animator.SetBool(IS_WALKING, player.IsWalking());
        }
        else
        {
            Debug.LogWarning("Player reference is null in PlayerAnimation.");
        }
    }
}
