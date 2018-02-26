namespace BashSoft.StaticData
{
    internal static class Constants
    {
        //error messages
        public const string InvalidCommandErrorMessage = "Invalid command {0}!";

        public const string DirectoryCannotOpenErrorMessage = "Cannot open directory {0}!"; //cd
        public const string CannotCreateDirectoryErrorMessage = "Cannot create directory {0}!"; //mkdir
        public const string FileCannotOpenErrorMessage = "Cannot open file {0}!"; //open
        //success messages
        public const string DiretoryChangedSuccessMessage = "Directory changed to: {0}"; //cd
        public const string DirectoryCreatedSuccessMessage = "Directory {0} created successfully!"; //mkdir
        public const string FileOpenedSuccessMessage = "File {0} opened successfully!"; //open
        //string constants
        public const string QuitCommand = "quit";
    }
}