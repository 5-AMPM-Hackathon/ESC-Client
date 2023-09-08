using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationLogic : MonoBehaviour
{
    public void runNotifi()
    {

        // 채널 등록
        var c = new AndroidNotificationChannel()
        {

            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",

        };

        AndroidNotificationCenter.RegisterNotificationChannel(c);

        // 알림 생성
        var notification = new AndroidNotification();

        notification.Title = "인근 화재 발생";
        notification.Text = "한신 휴 아파드 : " + WorldVar.lore;
        notification.FireTime = System.DateTime.Now.AddSeconds(1);

        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }
}
