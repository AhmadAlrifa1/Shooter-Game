using System;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine;

public class UIFriend : MonoBehaviour
{
    [SerializeField] private Text friendNameText;
    [SerializeField] private FriendInfo friend;

    public static Action<string> OnRemoveFriend = delegate { };

    public void Initialize(FriendInfo friend)
    {
        this.friend = friend;
        friendNameText.text = this.friend.UserId;
    }
    public void RemoveFriend()
    {
        OnRemoveFriend?.Invoke(friend.UserId);
    }
}
