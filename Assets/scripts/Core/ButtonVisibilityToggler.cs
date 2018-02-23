using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class ButtonVisibilityToggler : MonoBehaviour, IInteractInteraction
    {
        public GameObject PauseButton;
        public GameObject PlayButton;
        public bool PlayVisible = true;

        public void OnToggle()
        {
            PlayVisible = !PlayVisible;

            if (!PlayVisible)
            {
                PlayButton.GetComponent<IVisibilityInteraction>().Hide();
                PauseButton.GetComponent<IVisibilityInteraction>().Show();
            }
            else
            {
                PlayButton.GetComponent<IVisibilityInteraction>().Show();
                PauseButton.GetComponent<IVisibilityInteraction>().Hide();
            }
        }

        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void DeActivate()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            PlayVisible = true;

            PlayButton.GetComponent<IVisibilityInteraction>().Show();
            PauseButton.GetComponent<IVisibilityInteraction>().Hide();
        }
    }
}