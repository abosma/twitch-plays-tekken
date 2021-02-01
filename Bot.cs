using System;
using System.Collections.Generic;
using System.Linq;
using WindowsInput;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwitchPlaysGames
{
    internal class Bot
    {
        private readonly TwitchClient _client;
        
        private readonly InputSimulator _inputSimulator = new InputSimulator();
        private readonly InputManager _inputManager = new InputManager();
        private readonly SpecialManagerPaul _specialManagerPaul = new SpecialManagerPaul();

        public Bot()
        {
            DotNetEnv.Env.TraversePath().Load();

            var OAUTH = DotNetEnv.Env.GetString("OAUTH");
            var Credentials = new ConnectionCredentials("atilla_bot", OAUTH);
            
            _client = new TwitchClient();
            _client.Initialize(Credentials, "AtillaBosma");

            _client.OnLog += Client_OnLog;
            _client.OnConnected += Client_OnConnected;
            _client.OnJoinedChannel += Client_OnJoinedChannel;
            _client.OnMessageReceived += Client_OnMessageReceived;

            _client.Connect();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine($"Connected to {e.Channel}");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var ChatMessage = e.ChatMessage.Message.ToLower();

            if (ChatMessage.Equals("!controls") || ChatMessage.Equals("!help"))
            {
                _client.SendMessage(e.ChatMessage.Channel, $"Hello {e.ChatMessage.Username}, you can find the instructions here: https://discordjs.moe/q31bQ9m3xx.png");
                return;
            }
            
            var InputList = new List<string>();

            if (ChatMessage.Contains(","))
            {
                InputList = ChatMessage.Split(",").ToList();
            }
            else if (ChatMessage.Contains(" "))
            {
                InputList = ChatMessage.Split(" ").ToList();
            }
            else
            {
                InputList.Add(ChatMessage);
            }

            if (InputList.Count > 5)
            {
                return;
            }

            try
            {
                HandleInputs(InputList);
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception);
            }
        }

        /// <summary>
        /// First attempts to perform special moves, if it does and it still has a remaining input, perform the rest of the input.
        /// If it doesn't, just throw the input at MovePerformer.
        /// </summary>
        /// <param name="inputList"></param>
        private void HandleInputs(List<string> inputList)
        {
            MoveWriter.WriteMoveIfValid(inputList);

            foreach (var Input in inputList)
            {
                var ToPerformInput = Input.Trim();
                var ToAttemptRemainingKeys = _specialManagerPaul.AttemptSpecial(ToPerformInput, _inputSimulator, _inputManager);
                var ToInputKeys = _inputManager.GetKeyCode(ToAttemptRemainingKeys);

                MovePerformer.PerformMoves(ToInputKeys);
            }
        }
    }
}
