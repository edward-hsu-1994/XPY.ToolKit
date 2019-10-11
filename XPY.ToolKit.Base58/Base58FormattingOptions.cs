namespace XPY.ToolKit.Base58
{
    public enum Base58FormattingOptions
    {
        /// <summary>
        /// Does not insert line breaks after every 76 characters in the string representation.
        /// </summary>        
        None = 0,
        /// <summary>
        /// Inserts line breaks after every 76 characters in the string representation.
        /// </summary>
        InsertLineBreaks = 1
    }
}