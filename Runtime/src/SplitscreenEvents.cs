using UnityEngine;
using AnsibleEvents.Events;

namespace Splitscreen.Events
{
    public class ControllerConnectEvent : AnsibleEventSync<int, Camera> { }
    public class ControllerDisconnectEvent : AnsibleEventSync<int> { }
    public class CameraUpdateEvent : AnsibleEventSync<int, Camera> { }
}
