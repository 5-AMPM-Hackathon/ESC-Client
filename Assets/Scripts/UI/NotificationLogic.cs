using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationLogic : MonoBehaviour
{
    public void runNotifi()
    {

        // ä�� ���
        var c = new AndroidNotificationChannel()
        {

            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",

        };

        AndroidNotificationCenter.RegisterNotificationChannel(c);

        // �˸� ����
        var notification = new AndroidNotification();

        notification.Title = "�α� ȭ�� �߻�";
        notification.Text = "�ѽ� �� ���ĵ� : " + WorldVar.lore;
        notification.FireTime = System.DateTime.Now.AddSeconds(1);

        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "channel_id");

    }
}
