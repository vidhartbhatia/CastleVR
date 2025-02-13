﻿//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class handAction : MonoBehaviour
    {
        public SteamVR_Action_Boolean action;

        public Hand hand;
        public int globalScaleOnTeleport;
        public GameObject PlayerRoot;
        public Transform godPosition;
        public GameObject teleporter;

        private void Start()
        {
            Something();
        }

        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (action == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned");
                return;
            }

            action.AddOnChangeListener(OnActionChange, hand.handType);
        }

        private void OnDisable()
        {
            if (action != null)
                action.RemoveOnChangeListener(OnActionChange, hand.handType);
        }

        private void OnActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
        {
            if (newValue)
            {
                Something();
            }
        }

        public void Something()
        {
            // zoom out to original position
            //PlayerRoot.transform.localPosition = godPosition.localPosition;
            //PlayerRoot.transform.localScale = godPosition.localScale;

            //teleport to god point
            Teleport t = teleporter.GetComponent<Teleport>();
            t.TryTeleportPlayerToGodPosition();
           
        }

     
    }
}