using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class PlaybackController : MonoBehaviour, IHoverInteraction, IInteractInteraction
    {
        public bool Activated;
        public List<AnimationSetting> AnimationSettings = new List<AnimationSetting>();
        private List<ExecuteDelayed.WaitController> controllers = new List<ExecuteDelayed.WaitController>();
        public bool ShouldUseClick;
        public bool ShouldUseHover;
        private List<AnimationSetting> WithoutDupes = new List<AnimationSetting>();

        public void OnHoverEnter()
        {
            if (ShouldUseHover)
            {
                StartPlayback();
            }
        }

        public void OnHoverExit()
        {
            if (ShouldUseHover)
            {
                PausePlayback();
            }
        }

        public void OnToggle()
        {
            Activated = !Activated;
            if (Activated)
            {
                StartPlayback();
            }
            else
            {
                PausePlayback();
            }
        }

        public void Activate()
        {
            StartPlayback();
        }

        public void DeActivate()
        {
            PausePlayback();
        }

        public void Reset()
        {
            Activated = false;
            WithoutDupes.ForEach(c => c.AnimationObject.GetComponent<IPlaybackControl>().Stop());
            controllers.ForEach(c => c.Pause = !Activated);
            controllers = GetControllers(AnimationSettings);

            controllers.ForEach(c => c.Pause = !Activated);
        }

        private List<ExecuteDelayed.WaitController> GetControllers(List<AnimationSetting> animSettings)
        {
            return animSettings.Select(
                a =>
                    a.PlaybackFunction == PlaybackFunction.Pause
                        ? a.AnimationObject.DoSomethingLater(
                            a.AnimationObject.GetComponent<IPlaybackControl>().Pause, a.StartTime)
                        : a.PlaybackFunction == PlaybackFunction.Start
                            ? a.AnimationObject.DoSomethingLater(
                                a.AnimationObject.GetComponent<IPlaybackControl>().Start, a.StartTime)
                            : a.PlaybackFunction == PlaybackFunction.Stop
                                ? a.AnimationObject.DoSomethingLater(
                                    a.AnimationObject.GetComponent<IPlaybackControl>().Stop, a.StartTime)
                                : null
                ).ToList();
        }

        // Use this for initialization
        private void Start()
        {
            controllers = GetControllers(AnimationSettings);
            controllers.ForEach(c => c.Pause = !Activated);
            WithoutDupes = AnimationSettings.GroupBy(e => e.AnimationObject).Select(o => o.FirstOrDefault()).ToList();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void StartPlayback()
        {
            Activated = true;
            WithoutDupes.ForEach(c => c.AnimationObject.GetComponent<IPlaybackControl>().ResumeLastState());
            controllers.ForEach(c => c.Pause = !Activated);
        }

        public void PausePlayback()
        {
            Activated = false;
            WithoutDupes.ForEach(c => c.AnimationObject.GetComponent<IPlaybackControl>().Pause());
            controllers.ForEach(c => c.Pause = !Activated);
        }
    }

    public enum PlaybackFunction
    {
        Start,
        Pause,
        Stop
    }

    [Serializable]
    public class AnimationSetting
    {
        public GameObject AnimationObject;
        public PlaybackFunction PlaybackFunction;
        public float StartTime;

        public AnimationSetting(float startTime, GameObject obj, PlaybackFunction sop)
        {
            StartTime = startTime;
            AnimationObject = obj;
            PlaybackFunction = sop;
        }
    }

    public class AnimationScript
    {
        public PlaybackFunction PlaybackFunction;
        public IPlaybackControl Script;
        public float StartTime;

        public AnimationScript(float startTime, IPlaybackControl script, PlaybackFunction sop)
        {
            StartTime = startTime;
            Script = script;
            PlaybackFunction = sop;
        }
    }
}