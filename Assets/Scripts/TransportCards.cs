using System.Collections;
using UnityEngine;

namespace Assets
{
    public class TransportCards : MonoBehaviour
    {
        public void OnClick()
        {
            Transport.Initial.TransportButtons(gameObject);
        }
    }
}