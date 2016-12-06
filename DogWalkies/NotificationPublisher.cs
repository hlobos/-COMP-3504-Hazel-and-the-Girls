using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DogWalkies
{
    [BroadcastReceiver]
    public class NotificationPublisher : BroadcastReceiver
    {
        public NotificationPublisher()
        {
            
        }

        public override void OnReceive(Context context, Intent intent)
        {
            NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            Intent resultIntent = new Intent(context, typeof(MainActivity));
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(context);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
            stackBuilder.AddNextIntent(resultIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);

            Notification.Builder builder = new Notification.Builder(context);
            builder.SetAutoCancel(true);
            builder.SetContentIntent(resultPendingIntent);
            builder.SetContentTitle("DogWalkies Walk Reminder");
            builder.SetContentText("Don't forget to walk your pooch soon!");
            builder.SetSmallIcon(Resource.Drawable.Icon);
            builder.SetDefaults(NotificationDefaults.Vibrate | NotificationDefaults.Lights);

            notificationManager.Notify(100, builder.Build());
        }
    }
}