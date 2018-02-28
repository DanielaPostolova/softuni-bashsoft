namespace BashSoft.StaticData
{
    internal static class Constants
    {
        //error messages
        public const string InvalidCommandErrorMessage = "Invalid command!";

        public const string DirectoryCannotOpenErrorMessage = "Cannot open directory {0}!"; //cd
        public const string CannotCreateDirectoryErrorMessage = "Cannot create directory {0}!"; //mkdir
        public const string FileCannotOpenErrorMessage = "Cannot open file {0}!"; //open
        public const string CannotTraverseDirectoryErrorMessage = "Cannot traverse directory {0}!"; //ls
        public const string CannotClearConsoleErrorMessage = "Invalid operation! Output is redirected to a file!"; //clear

        public const string InvalidCommandParametersErrorMessage = "Command parameters are invalid!";
        //success messages
        public const string DiretoryChangedSuccessMessage = "Directory changed to: {0}"; //cd
        public const string DirectoryCreatedSuccessMessage = "Directory {0} created successfully!"; //mkdir
        public const string FileOpenedSuccessMessage = "File {0} opened successfully!"; //open
        public const string TraverseDirectorySuccessMessage = "Directory {0} successfully traversed!"; //ls
        //string constants
        public const string QuitCommand = "quit";
    }
}