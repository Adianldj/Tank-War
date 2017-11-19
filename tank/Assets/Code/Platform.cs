using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code
{
    public enum PlatformType
    {
        Windows,
        Mac,
        Linux,
    }

    public static class Platform
    {
        //Platform platform;
        public static PlatformType GetPlatform()
        {

            if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                return PlatformType.Windows;
            }
            else if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                return PlatformType.Mac;
            }
            else
            {
                return PlatformType.Linux;
            }


        }

        public static string GetFireAxis()
        {
            return GetPlatform() == PlatformType.Windows ? "FireWindows" : "FireMac";
        }

    }

}