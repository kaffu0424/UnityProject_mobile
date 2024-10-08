using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modoium.Service.Editor {
    internal static class MDMUrlHandler {
        public static string AndroidAppURL = "https://play.google.com/store/apps/details?id=com.modoium.client.app";
        public static string iOSAppURL = "https://apps.apple.com/app/id6587558465";
        public static string UserGuideURL = "https://clickedcorp.notion.site/Modoium-User-Guide-b3e19e05c69b465395b8d534cf7f774b?pvs=4";
        public static string ImportantNotesURL = "https://clickedcorp.notion.site/Important-Notes-16f7711b0c8843cd9f660dd2bd66aa52?pvs=4";
        public static string TroubleshootingURL = "https://clickedcorp.notion.site/Troubleshooting-fd4cc9d678e9457784186ba5dfa75e98?pvs=4";

        public static void Open(string url) {
            if (string.IsNullOrEmpty(url)) { return; }

            System.Diagnostics.Process.Start(url);
        }
    }
}
