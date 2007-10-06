using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace FileSearch.Windows
{
   /// <summary>
   /// Parses and allocates command line arguments in a predefined way.
   /// 
   /// The following command line arguments are valid:
   /// [/spath="value"]       - Start Path
   /// [/stypes="value"]      - File Types
   /// [/stext="value"]       - Search Text
   /// [/local]               - Store config files in local directory
   /// [/e]                   - Use regular expressions
   /// [/c]                   - Case sensitive
   /// [/w]                   - Whole Word
   /// [/r]                   - Recursive search (search subfolders)
   /// [/n]                   - Negation
   /// [/l]                   - Line numbers
   /// [/f]                   - File names only
   /// [/cl="value"]          - Number of context lines
   /// [/sh]                  - Skip hidden files and folders
   /// [/ss]                  - Skip system files and directories
   /// [/s]                   - Start searching immediately
   /// </summary>
   /// <remarks>
   ///   FileSearch File Searching Utility. Written by Theodore L. Ward
   ///   Copyright (C) 2002 AstroComma Incorporated.
   ///   
   ///   This program is free software; you can redistribute it and/or
   ///   modify it under the terms of the GNU General Public License
   ///   as published by the Free Software Foundation; either version 2
   ///   of the License, or (at your option) any later version.
   ///   
   ///   This program is distributed in the hope that it will be useful,
   ///   but WITHOUT ANY WARRANTY; without even the implied warranty of
   ///   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   ///   GNU General Public License for more details.
   ///   
   ///   You should have received a copy of the GNU General Public License
   ///   along with this program; if not, write to the Free Software
   ///   Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
   /// 
   ///   The author may be contacted at:
   ///   ted@astrocomma.com or curtismbeard@gmail.com
   /// </remarks>
   /// <history>
   /// 	[Curtis_Beard]		07/25/2006	ADD: 1492221, command line parameters
   /// </history>
   public class CommandLineProcessing
   {
      /// <summary>
      /// Holds the parsed command line options.
      /// </summary>
      /// <history>
      /// [Curtis_Beard]		07/26/2006	Created
      /// </history>
      public struct CommandLineArguments
      {
         /// <summary></summary>
         public bool AnyArguments;
         /// <summary></summary>
         public string StartPath;
         /// <summary></summary>
         public bool IsValidStartPath;

         /// <summary></summary>
         public string ProjectFile;
         /// <summary></summary>
         public bool IsProjectFile;

         /// <summary></summary>
         public string FileTypes;
         /// <summary></summary>
         public bool IsValidFileTypes;

         /// <summary></summary>
         public string SearchText;
         /// <summary></summary>
         public bool IsValidSearchText;

         /// <summary></summary>
         public bool StartSearch;
         /// <summary></summary>
         public bool UseRegularExpressions;
         /// <summary></summary>
         public bool IsCaseSensitive;
         /// <summary></summary>
         public bool IsWholeWord;
         /// <summary></summary>
         public bool UseRecursion;
         /// <summary></summary>
         public bool IsNegation;
         /// <summary></summary>
         public bool UseLineNumbers;
         /// <summary></summary>
         public bool IsFileNamesOnly;
         /// <summary></summary>
         public int ContextLines;
         /// <summary></summary>
         public bool SkipHidden;
         /// <summary></summary>
         public bool SkipSystem;

         /// <summary></summary>
         public bool StoreDataLocal;
      }

      /// <summary>
      /// Parses the command line arguments for valid options and returns them.
      /// </summary>
      /// <param name="CommandLineArgs">Array of strings containing the command line arguments</param>
      /// <returns>CommandLineArguments structure holding the options from the command line</returns>
      /// <history>
      /// [Curtis_Beard]		07/26/2006	Created
      /// [Curtis_Beard]		05/08/2007	ADD: 1590157, support project file
      /// </history>
      public static CommandLineArguments Process(string[] CommandLineArgs)
      {
         // create the args structure and initialize it
         CommandLineArguments args = new CommandLineArguments();
         InitializeArgs(ref args);

         // process the command line
         Arguments myArgs = new Arguments(CommandLineArgs);

         // check for just a single directory / project file
         if (CommandLineArgs.Length == 2)
         {
            args.AnyArguments = true;

            // Check command line for a path to start at
            string arg1 = CommandLineArgs[1];

            // remove an extra quote if (a drive letter
            if (arg1.EndsWith("\""))
               arg1 = arg1.Substring(0, arg1.Length - 1);

            // check for a project file
            if (arg1.EndsWith(".agproj"))
            {
               args.ProjectFile = arg1;
               args.IsProjectFile = true;
            }

            // check for a directory
            if (!args.IsProjectFile && System.IO.Directory.Exists(arg1))
            {
               args.StartPath = arg1;
               args.IsValidStartPath = true;
            }
            
            // do this before setting defaults to prevent loading wrong config file.
            if (!args.IsValidStartPath && !args.IsProjectFile)
            {
               // check for some other single setting, such as /local
               ProcessFlags(myArgs, ref args);               
            }
         }
         else if (CommandLineArgs.Length > 1)
         {
            args.AnyArguments = true;

            ProcessFlags(myArgs, ref args);
         }

         return args;
      }

      /// <summary>
      /// Initializes values of the given CommandLineArguments structure.
      /// </summary>
      /// <param name="args">CommandLineArguments to initialize</param>
      /// <history>
      /// [Curtis_Beard]		07/26/2006	Created
      /// </history>
      private static void InitializeArgs(ref CommandLineArguments args)
      {
         args.AnyArguments = false;

         args.StartPath = string.Empty;
         args.IsValidStartPath = false;

         args.ProjectFile = string.Empty;
         args.IsProjectFile = false;

         args.FileTypes = string.Empty;
         args.IsValidFileTypes = false;

         args.SearchText = string.Empty;
         args.IsValidSearchText = false;

         args.StartSearch = false;

         // default to all turned off, user must specify each one, or use /d for defaults
         args.UseRegularExpressions = false;
         args.IsCaseSensitive = false;
         args.IsWholeWord = false;
         args.UseRecursion = false;
         args.IsNegation = false;
         args.UseLineNumbers = false;
         args.IsFileNamesOnly = false;
         args.ContextLines = -1;
         args.SkipHidden = false;
         args.SkipSystem = false;

         args.StoreDataLocal = false;
      }

      /// <summary>
      /// Parse the given string for valid command line option flags.
      /// </summary>
      /// <param name="myArgs">String containing potential options.</param>
      /// <param name="args">CommandLineArguments structure to hold found options.</param>
      /// <history>
      /// [Curtis_Beard]		07/26/2006	Created
      /// [Curtis_Beard]		05/18/2007	CHG: use new command line arguments
      /// </history>
      private static void ProcessFlags(Arguments myArgs, ref CommandLineArguments args)
      {
         if (myArgs["s"] != null)
            args.StartSearch = true;

         if (myArgs["e"] != null)
            args.UseRegularExpressions = true;

         if (myArgs["c"] != null)
            args.IsCaseSensitive = true;

         if (myArgs["w"] != null)
            args.IsWholeWord = true;

         if (myArgs["r"] != null)
            args.UseRecursion = true;

         if (myArgs["n"] != null)
            args.IsNegation = true;

         if (myArgs["l"] != null)
            args.UseLineNumbers = true;

         if (myArgs["f"] != null)
            args.IsFileNamesOnly = true;

         if (myArgs["cl"] != null)
         {
            try
            {
               int num = int.Parse(myArgs["cl"]);

               if (num >= 0 && num <= Constants.MAX_CONTEXT_LINES)
                  args.ContextLines = num;
            }
            catch {}
         }

         if (myArgs["sh"] != null)
            args.SkipHidden = true;

         if (myArgs["ss"] != null)
            args.SkipSystem = true;

         if (myArgs["spath"] != null)
         {
            if (System.IO.Directory.Exists(myArgs["spath"]))
            {
               args.IsValidStartPath = true;
               args.StartPath = myArgs["spath"];
            }
         }         

         if (myArgs["stypes"] != null)
         {
            args.IsValidFileTypes = true;
            args.FileTypes = myArgs["stypes"];
         }

         if (myArgs["stext"] != null)
         {
            args.IsValidSearchText = true;
            args.SearchText = myArgs["stext"];
         }

         if (myArgs["local"] != null)
         {
            args.StoreDataLocal = true;
            Core.Common.StoreDataLocal = true;
         }
      }
   }

   /// <summary>
   /// Arguments class
   /// </summary>
   internal class Arguments
   {
      // Variables
      private StringDictionary Parameters;

      // Constructor
      public Arguments(string[] Args)
      {
         Parameters=new StringDictionary();
         //Regex Spliter=new Regex(@"^-{1,2}|^/|=|:",RegexOptions.IgnoreCase|RegexOptions.Compiled);
         Regex Spliter=new Regex(@"^-{1,2}|^/|=",RegexOptions.IgnoreCase|RegexOptions.Compiled);
         Regex Remover= new Regex(@"^['""]?(.*?)['""]?$",RegexOptions.IgnoreCase|RegexOptions.Compiled);
         string Parameter=null;
         string[] Parts;

         // Valid parameters forms:
         // {-,/,--}param{ ,=,:}((",')value(",'))
         // Examples: -param1 value1 --param2 /param3:"Test-:-work" /param4=happy -param5 '--=nice=--'
         foreach(string Txt in Args)
         {
            // Look for new parameters (-,/ or --) and a possible enclosed value (=,:)
            Parts=Spliter.Split(Txt,3);
            switch(Parts.Length)
            {
                  // Found a value (for the last parameter found (space separator))
               case 1:
                  if(Parameter!=null)
                  {
                     if(!Parameters.ContainsKey(Parameter))
                     {
                        Parts[0]=Remover.Replace(Parts[0],"$1");
                        Parameters.Add(Parameter,Parts[0]);
                     }
                     Parameter=null;
                  }
                  // else Error: no parameter waiting for a value (skipped)
                  break;
                  // Found just a parameter
               case 2:
                  // The last parameter is still waiting. With no value, set it to true.
                  if(Parameter!=null)
                  {
                     if(!Parameters.ContainsKey(Parameter)) Parameters.Add(Parameter,"true");
                  }
                  Parameter=Parts[1];
                  break;
                  // Parameter with enclosed value
               case 3:
                  // The last parameter is still waiting. With no value, set it to true.
                  if(Parameter!=null)
                  {
                     if(!Parameters.ContainsKey(Parameter)) Parameters.Add(Parameter,"true");
                  }
                  Parameter=Parts[1];
                  // Remove possible enclosing characters (",')
                  if(!Parameters.ContainsKey(Parameter))
                  {
                     Parts[2]=Remover.Replace(Parts[2],"$1");
                     Parameters.Add(Parameter,Parts[2]);
                  }
                  Parameter=null;
                  break;
            }
         }
         // In case a parameter is still waiting
         if(Parameter!=null)
         {
            if(!Parameters.ContainsKey(Parameter)) Parameters.Add(Parameter,"true");
         }
      }

      // Retrieve a parameter value if it exists
      public string this [string Param]
      {
         get
         {
            return(Parameters[Param]);
         }
      }
   }
}
