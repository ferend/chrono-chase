using UnityEngine;

namespace _Project.Scripts.Runner.Game.Input
{
    [CreateAssetMenu(menuName = "Events/ Generic Event Channel", fileName = "GestureEventChannel")]

    public class GestureEventChannel : GenericEventChannel<Swipe.GestureData>
    {

    }
}