using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DependecyService.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(BatteryImplementation))]
namespace DependecyService.Droid
{
    class BatteryImplementation : IBattery
    {
        public int RemainingChargePercent {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged)) 
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter)) 
                        {
                            var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                            var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
                            return (int)Math.Floor(level * 100D / scale);
                        }   
                    }
                }
                catch 
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have adnroid.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public BatteryStatus Status 
        {
            get 
            {
                try 
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged)) 
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter)) 
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;
                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelesscharge = false;
                            wirelesscharge = chargePlug == (int)BatteryPlugged.Wireless;
                            isCharging = (usbCharge || acCharge || wirelesscharge);
                            System.Diagnostics.Debug.WriteLine(isCharging);
                            System.Diagnostics.Debug.WriteLine(status);
                            if (isCharging) 
                            {
                                return DependecyService.BatteryStatus.Charging;
                            }
                            switch (status) 
                            {
                                case (int)BatteryStatus.Charging:
                                    return DependecyService.BatteryStatus.Charging;
                                case (int)BatteryStatus.Discharging:
                                    return DependecyService.BatteryStatus.Discharging;
                                case (int)BatteryStatus.Full:
                                    return DependecyService.BatteryStatus.Full;
                                case (int)BatteryStatus.NotCharging:
                                    return DependecyService.BatteryStatus.NotCharging;
                                default:
                                    return DependecyService.BatteryStatus.Unknown;
                            }
                        }
                    }
                } catch 
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public PowerSource PowerSource 
        {
            get 
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged)) 
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter)) 
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)BatteryStatus.Charging || status == (int)BatteryStatus.Full;
                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelesCharge = false;
                            wirelesCharge = chargePlug == (int)BatteryPlugged.Wireless;
                            isCharging = (usbCharge || acCharge || wirelesCharge);
                            if (!isCharging)
                                return DependecyService.PowerSource.Battery;
                            else if (usbCharge)
                                return DependecyService.PowerSource.Usb;
                            else if (acCharge)
                                return DependecyService.PowerSource.Ac;
                            else if (wirelesCharge)
                                return DependecyService.PowerSource.Wireless;
                            else
                                return DependecyService.PowerSource.Other;
                        }
                    }
                }
                catch 
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }
    }
}