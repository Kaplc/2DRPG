using UnityEngine;

namespace App.View.Generic.Animation
{
    public class AnimationTriggers : MonoBehaviour
    {
        public Player player;
        
        public void AnimationFinishTrigger()
        {
            player.AnimationFinishTrigger();
        }
    }
}

