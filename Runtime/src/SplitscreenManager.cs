using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AnsibleEvents;
using Splitscreen.Events;

namespace Splitscreen
{
    public class SplitscreenManager : MonoBehaviour
    {
        private Camera[] cameras = new Camera[8];

        private void OnEnable()
        {
            Ansible.Get<ControllerConnectEvent>().Subscribe(OnControllerConnect);
            Ansible.Get<ControllerDisconnectEvent>().Subscribe(OnControllerDisconnect);
            Ansible.Get<CameraUpdateEvent>().Subscribe(OnCameraUpdate);
        }

        private void OnDisable()
        {
            Ansible.Get<ControllerConnectEvent>().Unsubscribe(OnControllerConnect);
            Ansible.Get<ControllerDisconnectEvent>().Unsubscribe(OnControllerDisconnect);
            Ansible.Get<CameraUpdateEvent>().Unsubscribe(OnCameraUpdate);
        }

        private void OnControllerConnect(int id, Camera camera)
        {
            this.cameras[id] = camera;
            OrganizeCameras();
        }

        private void OnControllerDisconnect(int id)
        {
            this.cameras[id].rect = new Rect();
            this.cameras[id] = null;
            OrganizeCameras();
        }

        private void OnCameraUpdate(int id, Camera camera)
        {
            this.cameras[id] = camera;
            OrganizeCameras();
        }

        private void OrganizeCameras()
        {
            var activeCameras = this.cameras.Where(x => x != null).ToArray();
            var screenSplits = SplitscreenRects.GetScreenSplits(activeCameras.Length);
            for (int i = 0; i < activeCameras.Length && i < screenSplits.Length; i++)
            {
                activeCameras[i].rect = screenSplits[i];
            }
        }
    }
}