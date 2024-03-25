﻿namespace Notes.Models
{
    public class About
    {
        public string Title => AppInfo.Name;

        public string Version => AppInfo.VersionString;

        public string MoreInfoUrl => "https://github.com/GyuntekAhmed/Notes/tree/master/Notes";

        public string Message => "This app is written in XAML and C# with .NET MAUI.";
    }
}