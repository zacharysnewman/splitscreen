using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnsibleEvents;
using Splitscreen.Events;

namespace Splitscreen.Tests
{
    public class SplitscreenTests : MonoBehaviour
    {
        public int waitTime = 1;
        public Camera[] cameras;

        // Update 3

        public IEnumerator Tests()
        {
            yield return Test1();
            yield return Test2();
            yield return Test3();
            yield return Test4();
        }

        private IEnumerator Test1()
        {
            Debug.Log("Test1: 1");
            Ansible.Get<ControllerConnectEvent>().Publish(0, this.cameras[0]);
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Test1: 0");
            Ansible.Get<ControllerDisconnectEvent>().Publish(0);
            yield return new WaitForSeconds(waitTime);
        }

        private IEnumerator Test2()
        {
            Debug.Log("Test2: 2");
            Ansible.Get<ControllerConnectEvent>().Publish(0, this.cameras[0]);
            Ansible.Get<ControllerConnectEvent>().Publish(1, this.cameras[1]);
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Test2: 1");
            Ansible.Get<ControllerDisconnectEvent>().Publish(1);
            yield return new WaitForSeconds(waitTime);

            // Cleanup
            Ansible.Get<ControllerDisconnectEvent>().Publish(0);
        }

        private IEnumerator Test3()
        {
            Debug.Log("Test3: 3");
            for(int i = 0; i < 3; i++)
            {
                Ansible.Get<ControllerConnectEvent>().Publish(i, this.cameras[i]);
            }
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Test3: 2");
            Ansible.Get<ControllerDisconnectEvent>().Publish(1);
            yield return new WaitForSeconds(waitTime);

            // Cleanup
            Ansible.Get<ControllerDisconnectEvent>().Publish(0);
            Ansible.Get<ControllerDisconnectEvent>().Publish(2);
        }

        private IEnumerator Test4()
        {
            Debug.Log("Test3: 8 Incremental");
            for(int i = 0; i < 8; i++)
            {
                Ansible.Get<ControllerConnectEvent>().Publish(i, this.cameras[i]);
                yield return new WaitForSeconds(waitTime);
            }

            // Cleanup
            for(int i = 0; i < 8; i++)
            {
                Ansible.Get<ControllerDisconnectEvent>().Publish(i);
            }
        }


        public void Run()
        {
            StartCoroutine(Tests());
        }
    }
}

