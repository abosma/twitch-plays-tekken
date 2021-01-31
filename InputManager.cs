using System;
using System.Collections.Generic;
using System.Linq;
using WindowsInput.Native;

namespace TwitchPlaysGames
{
    class InputManager
    {
        private readonly Dictionary<string, VirtualKeyCode[]> _inputDictionary = new Dictionary<string, VirtualKeyCode[]>();

        public InputManager()
        {
            _inputDictionary.Add("df", new[] { VirtualKeyCode.DOWN, VirtualKeyCode.RIGHT });
            _inputDictionary.Add("db", new[] { VirtualKeyCode.DOWN, VirtualKeyCode.LEFT });
            _inputDictionary.Add("uf", new[] { VirtualKeyCode.UP, VirtualKeyCode.RIGHT });
            _inputDictionary.Add("ub", new[] { VirtualKeyCode.UP, VirtualKeyCode.LEFT });
            _inputDictionary.Add("u", new[] { VirtualKeyCode.UP });
            _inputDictionary.Add("d", new[] { VirtualKeyCode.DOWN });
            _inputDictionary.Add("f", new[] { VirtualKeyCode.RIGHT });
            _inputDictionary.Add("b", new[] { VirtualKeyCode.LEFT });
            _inputDictionary.Add("1+2", new[] { VirtualKeyCode.VK_S, VirtualKeyCode.VK_D });
            _inputDictionary.Add("3+4", new[] { VirtualKeyCode.VK_X, VirtualKeyCode.VK_C });
            _inputDictionary.Add("1+3", new[] { VirtualKeyCode.VK_S, VirtualKeyCode.VK_X });
            _inputDictionary.Add("2+4", new[] { VirtualKeyCode.VK_D, VirtualKeyCode.VK_C });
            _inputDictionary.Add("1+4", new[] { VirtualKeyCode.VK_S, VirtualKeyCode.VK_C });
            _inputDictionary.Add("2+3", new[] { VirtualKeyCode.VK_D, VirtualKeyCode.VK_X });
            _inputDictionary.Add("1", new[] { VirtualKeyCode.VK_S });
            _inputDictionary.Add("2", new[] { VirtualKeyCode.VK_D });
            _inputDictionary.Add("3", new[] { VirtualKeyCode.VK_X });
            _inputDictionary.Add("4", new[] { VirtualKeyCode.VK_C });
            _inputDictionary.Add("accept", new[] { VirtualKeyCode.VK_Z });
            _inputDictionary.Add("decline", new[] { VirtualKeyCode.VK_X });
            _inputDictionary.Add("ra", new[] { VirtualKeyCode.VK_Z });
        }

        public List<VirtualKeyCode[]> GetKeyCode(string input)
        {
            var DictionaryKeys = _inputDictionary.Keys.ToList();
            var ToReturnKeys = new List<VirtualKeyCode[]>();

            foreach (var Key in DictionaryKeys)
            {
                if (input.Contains(Key))
                {
                    string[] Inputs = input.Split(Key, StringSplitOptions.RemoveEmptyEntries);
                    var ToAddSpecialKey = _inputDictionary[Key];

                    ToReturnKeys.Add(ToAddSpecialKey);

                    foreach (var Input in Inputs)
                    {
                        var ToAddKey = _inputDictionary[Input];
                        ToReturnKeys.Add(ToAddKey);
                    }

                    break;
                }
            }

            return ToReturnKeys;
        }
    }
}
