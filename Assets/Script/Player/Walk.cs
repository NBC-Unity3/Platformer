using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public void PlayWalkSound()
    {
        SoundManager.Instance.PlaySFX("Walk");
    }
}
