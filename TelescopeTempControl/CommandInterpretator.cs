using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelescopeTempControl
{
    public class CommandInterpretator
    {
        public Dictionary<string, Func<string[],string>> Commands = new Dictionary<string, Func<string[], string>>();

        public CommandInterpretator()
        {
            //Commands = PassedCommands;
        }


        /// <summary>
        /// Base method which returns command output 
        /// 1. Split command for COMMAND and its PARAMETERS (e.g."SET_FAN 10")
        /// 2. Checks if COMMAND exists
        /// 3. Run command (based on dictionary list)
        /// </summary>
        /// <param name="CommandString">Command string</param>
        /// <param name="cmd_output">OUT - command output</param>
        /// <returns>false if command doesn't exist</returns>
        public bool ParseSingleCommand(string CommandString, out string cmd_output)
        {
            bool ret = true;
            string CommandString_pure = "";
            string[] CommandString_param_arr = new string[0];

            //1. Split command string into COMMAND and PARAMETERS
            if (CommandString.Contains(" "))
            {
                //Split
                string[] CommandString_arr = CommandString.Split(' ');
                CommandString_pure = CommandString_arr[0];
                CommandString_param_arr = CommandString_arr.Skip(1).ToArray();
            }
            else {
                CommandString_pure = CommandString;
            }

            //2. Check if COMMAND exists
            if (!Commands.ContainsKey(CommandString_pure))
            {
                Logging.AddLog("Команды [" + CommandString_pure + "] не существует", 0, Highlight.Error);
                cmd_output = "";
                ret = false;
            }
            else
            {
                //3. Run COMMAND
                cmd_output = Commands[CommandString_pure](CommandString_param_arr);
            }
            return ret;
        }


        /// <summary>
        /// Method override which doesn't return command output 
        /// </summary>
        /// <param name="CommandString">command</param>
        /// <returns>false if command doesn't exist</returns>
        public bool ParseSingleCommand(string CommandString)
        {
            string cmd_output_dummy = "";
            return ParseSingleCommand(CommandString, out cmd_output_dummy);
        }


        /// <summary>
        /// List all commands
        /// </summary>
        /// <returns>string list of commands</returns>
        public string ListCommands()
        {
            string st = "";

            foreach (KeyValuePair<string, Func<string[],string>> entry in Commands)
            {
                st += entry.Key + ";";
            }

            return st;
        }
    }

}
