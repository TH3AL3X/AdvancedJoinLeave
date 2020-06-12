using System.Collections.Generic;
using System.Collections;
using SDG.Unturned;
using Steamworks;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using UnityEngine;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Rocket.Core.Plugins;
using Rocket.Core.Utils;
using Rocket.API;
using Rocket.Core;
using Rocket.Core.Extensions;
using Logger = Rocket.Core.Logging.Logger;
using Rocket.Unturned.Player;
using Rocket.Unturned;
using Rocket.API.Collections;

namespace Main
{
    public class Main : RocketPlugin<Configuration>
    {
        public static Main Instance;

        protected override void Load()
        {
            Instance = this;
            U.Events.OnPlayerConnected += OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    {"join", "(color=red){0}(/color) (color=grey)has been joined to the game(/color)"},
                    {"leave", "(color=red){0}(/color) (color=grey)has been left to the game(/color)"}
                };
            }
        }

        private void OnPlayerDisconnected(UnturnedPlayer player)
        {
            ChatManager.serverSendMessage(Translate("leave", player.CharacterName).Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.SAY, Main.Instance.Configuration.Instance.leaveicon, Main.Instance.Configuration.Instance.richleave);
        }

        private void OnPlayerConnected(UnturnedPlayer player)
        {
            ChatManager.serverSendMessage(Translate("join", player.CharacterName).Replace('(', '<').Replace(')', '>'), Color.white, null, null, EChatMode.SAY, Main.Instance.Configuration.Instance.joinicon, Main.Instance.Configuration.Instance.richjoin);
        }

   

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= OnPlayerConnected;
            U.Events.OnPlayerDisconnected += OnPlayerDisconnected;
        }
    }
}
